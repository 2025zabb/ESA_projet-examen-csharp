using ProjetExamen.Interfaces;

namespace ProjetExamen.Models;



public enum Typepompes
{
    Velomoteur,
    CamionDebitRapide,
    AutresUsage,
}

/// <summary>
/// Représente une pompe dans une station-service.
/// Une pompe contient plusieurs pistolets et permet de distribuer du carburant.
/// </summary>
public class Pompe : IStatut

{
    public Typepompes TypePompe { get; set; }

    /// <summary>
    /// Numéro de la pompe.
    /// </summary>
    public int NumeeroPompe { get; set; }

    /// <summary>
    /// Indique si la pompe est disponible.
    /// </summary>
    public bool Disponible { get; set; }

    /// <summary>
    /// Indique si la pompe est en panne.
    /// </summary>
    public bool Enpanne { get; private set; }

    /// <summary>
    /// Liste des pistolets associés à la pompe.
    /// </summary>
    public List<Pistolet> Pistolets { get; set; }

    /// <summary>
    /// Type de cuve assoc
    /// </summary>
    public string? TypeCuve { get; set; }

    /// <summary>
    /// Constructeur de la pompe.
    /// Initialise le numéro et l'état par défaut.
    /// </summary>
    /// <param name="numeeroPompe">Numéro de la pompe</param>
    /// <param name="typePompe"></param>
    public Pompe(int numeeroPompe, Typepompes typePompe)
    {
        NumeeroPompe = numeeroPompe;
        Disponible = true;
        Enpanne = false;
        TypePompe = typePompe;
        Pistolets = new List<Pistolet>();
    }

    /// <summary>
    /// Retourne l'état actuel de la pompe.
    /// </summary>
    /// <returns>Une chaîne décrivant l'état de la pompe</returns>
    public string Status()
    {
        if (Enpanne)
        {
            return "Pompe en panne";
        }

        if (!Disponible)
        {
            return "Pompe pas disponible";
        }

        return "Pompe disponible";
    }
    
    
    
    public bool VerifierPompeEtVehicule(Vehicule vehicule)
    
    {
        
        if (TypePompe == Typepompes.AutresUsage)
        {
            
            return vehicule.Category == CategoryVéhicules.Moto ||
                   vehicule.Category == CategoryVéhicules.Voiture;  
            
        }

        if (TypePompe == Typepompes.CamionDebitRapide)
        {
            
            return vehicule.Category == CategoryVéhicules.Camion;
            
        }

        return false;
    }

    

    /// <summary>
    /// Permet à un client de faire le plein via un pistolet disponible.
    /// Crée une vente et l'enregistre dans la station.
    /// </summary>
    /// <param name="client">Client effectuant le plein</param>
    /// <param name="station">Station-service contenant les ventes</param>
    /// <param name="quantite">Quantité de carburant demandée</param>
    /// <param name="choixEssence"></param>
    public void FaireLePlein(Client client, StationService station, double quantite, NomCarburant choixEssence,Vehicule vehicule)
    {
        if (!VerifierPompeEtVehicule(vehicule))
        {
         Console.WriteLine("Ce véhicule n’est pas compatible avec la pompe");
         return ;
        }
        
        if (Enpanne)
        {
            Console.WriteLine("Pompe hors service");
            return;
        }

        bool pistoletAvecBonCarburant = false;
        bool pistoletAvecBonCarburantEnPanne = false;
        bool pistoletAvecBonCarburantPasDisponible = false;

        foreach (var pi in Pistolets)
        {
            if (pi.Cuve.Carburant.Type != choixEssence)
            {
                continue;
            }

            pistoletAvecBonCarburant = true;

            if (pi.Enpanne)
            {
                pistoletAvecBonCarburantEnPanne = true;
                continue;
            }

            if (!pi.Disponible)
            {
                pistoletAvecBonCarburantPasDisponible = true;
                continue;
            }

            double? prix = pi.Distribue(quantite);

            if (prix != null)
            {
                client.EffectuerLePaiement(prix.Value);

                Vente vente1 = new Vente(
                    prix.Value,
                    pi.Cuve.Carburant.Type,
                    quantite,
                    DateTime.Today.DayOfWeek
                );

                station.AjouterUneVente(vente1);
            }

            return;
        }

        if (!pistoletAvecBonCarburant) // IA ICI
        {
            Console.WriteLine("Le carburant demandé n’est pas servi ici");
        }
        else if (pistoletAvecBonCarburantEnPanne)
        {
            Console.WriteLine("Un pistolet du bon carburant est en panne");
        }
        else if (pistoletAvecBonCarburantPasDisponible)
        {
            Console.WriteLine("Un pistolet du bon carburant n’est pas disponible");
        }
        else
        {
            Console.WriteLine("Aucun pistolet disponible");
        }
    }

    public void MettreEnPanne()
    {
        Enpanne = true;
    }

    public void Repare()
    {
        Enpanne = false;
    }


    

}