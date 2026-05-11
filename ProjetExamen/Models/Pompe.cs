using ProjetExamen.Interfaces;

namespace ProjetExamen.Models;

/// <summary>
/// Représente les différents types de pompes.
/// </summary>
public enum Typepompes
{
    /// <summary>
    /// Pompe pour vélomoteurs.
    /// </summary>
    Velomoteur,

    /// <summary>
    /// Pompe à débit rapide pour camions.
    /// </summary>
    CamionDebitRapide,

    /// <summary>
    /// Pompe pour autres usages.
    /// </summary>
    AutresUsage,
}

/// <summary>
/// Représente une pompe dans une station-service.
/// Une pompe contient plusieurs pistolets
/// et permet de distribuer du carburant.
/// </summary>
public class Pompe : IStatut
{
    /// <summary>
    /// Type de la pompe.
    /// </summary>
    public Typepompes TypePompe { get; set; }

    /// <summary>
    /// Numéro de la pompe.
    /// </summary>
    public int NumeeroPompe { get; set; }

    /// <summary>
    /// Indique si la pompe est disponible.
    /// </summary>
    public bool Disponible { get; private set; }

    /// <summary>
    /// Indique si la pompe est en panne.
    /// </summary>
    public bool Enpanne { get; private set; }

    /// <summary>
    /// Liste des pistolets associés à la pompe.
    /// </summary>
    public List<Pistolet> Pistolets { get; set; }

    /// <summary>
    /// Type de cuve associé à la pompe.
    /// </summary>
    public string? TypeCuve { get; set; }

    /// <summary>
    /// Constructeur de la pompe.
    /// Initialise le numéro et l’état par défaut.
    /// </summary>
    /// <param name="numeeroPompe">Numéro de la pompe.</param>
    /// <param name="typePompe">Type de la pompe.</param>
    public Pompe(int numeeroPompe, Typepompes typePompe)
    {
        NumeeroPompe = numeeroPompe;

        // La pompe est disponible au départ
        Disponible = true;

        // La pompe n’est pas en panne au départ
        Enpanne = false;

        TypePompe = typePompe;

        // Initialisation de la liste des pistolets
        Pistolets = new List<Pistolet>();
    }

    /// <summary>
    /// Retourne l’état actuel de la pompe.
    /// </summary>
    /// <returns>
    /// Une chaîne décrivant l’état de la pompe.
    /// </returns>
    public string Status()
    {
        // Vérifie si la pompe est en panne
        if (Enpanne)
        {
            return "Pompe en panne";
        }

        // Vérifie si la pompe est occupée
        if (!Disponible)
        {
            return "Pompe pas disponible";
        }

        // Sinon la pompe est disponible
        return "Pompe disponible";
    }

    /// <summary>
    /// Vérifie si le véhicule est compatible avec la pompe.
    /// </summary>
    /// <param name="vehicule">Véhicule à vérifier.</param>
    /// <returns>
    /// True si le véhicule est compatible.
    /// </returns>
    public bool VerifierPompeEtVehicule(Vehicule vehicule)
    {
        // Pompe classique pour voitures et motos
        if (TypePompe == Typepompes.AutresUsage)
        {
            return vehicule.Category == CategoryVéhicules.Moto
                   || vehicule.Category == CategoryVéhicules.Voiture;
        }

        // Pompe spéciale camion
        if (TypePompe == Typepompes.CamionDebitRapide)
        {
            return vehicule.Category == CategoryVéhicules.Camion;
        }

        return false;
    }

    /// <summary>
    /// Permet à un client de faire le plein
    /// via un pistolet disponible.
    /// </summary>
    /// <param name="client">
    /// Client effectuant le plein.
    /// </param>
    /// <param name="station">
    /// Station-service contenant les ventes.
    /// </param>
    /// <param name="quantite">
    /// Quantité demandée.
    /// </param>
    /// <param name="choixEssence">
    /// Type de carburant demandé.
    /// </param>
    /// <param name="vehicule">
    /// Véhicule du client.
    /// </param>
    public void FaireLePlein(
        Client client,
        StationService station,
        double quantite,
        NomCarburant choixEssence,
        Vehicule vehicule)
    {
        // Vérifie la compatibilité du véhicule
        if (!VerifierPompeEtVehicule(vehicule))
        {
            Console.WriteLine(
                "Ce véhicule n’est pas compatible avec la pompe");

            return;
        }

        // Vérifie si la pompe est en panne
        if (Enpanne)
        {
            Console.WriteLine("Pompe hors service");
            return;
        }

        bool pistoletAvecBonCarburant = false;
        bool pistoletAvecBonCarburantEnPanne = false;
        bool pistoletAvecBonCarburantPasDisponible = false;

        // Parcours des pistolets de la pompe
        foreach (var pi in Pistolets)
        {
            // Vérifie le type de carburant
            if (pi.Cuve.Carburant.Type != choixEssence)
            {
                continue;
            }

            pistoletAvecBonCarburant = true;

            // Vérifie si le pistolet est en panne
            if (pi.Enpanne)
            {
                pistoletAvecBonCarburantEnPanne = true;
                continue;
            }

            // Vérifie si le pistolet est disponible
            if (!pi.Disponible)
            {
                pistoletAvecBonCarburantPasDisponible = true;
                continue;
            }

            // Distribution du carburant
            double? prix = pi.Distribue(quantite);

            // Vérifie si la distribution a réussi
            if (prix != null)
            {
                // Paiement du client
                client.EffectuerLePaiement(prix.Value);

                // Création de la vente
                Vente vente1 = new Vente(
                    prix.Value,
                    pi.Cuve.Carburant.Type,
                    quantite,
                    DateTime.Today.DayOfWeek
                );

                // Ajout de la vente à la station
                station.AjouterUneVente(vente1);
            }

            return;
        }

        // Messages d’erreur selon le problème rencontré
        if (!pistoletAvecBonCarburant)
        {
            Console.WriteLine(
                "Le carburant demandé n’est pas servi ici");
        }
        else if (pistoletAvecBonCarburantEnPanne)
        {
            Console.WriteLine(
                "Un pistolet du bon carburant est en panne");
        }
        else if (pistoletAvecBonCarburantPasDisponible)
        {
            Console.WriteLine(
                "Un pistolet du bon carburant n’est pas disponible");
        }
        else
        {
            Console.WriteLine(
                "Aucun pistolet disponible");
        }
    }

    /// <summary>
    /// Met la pompe en panne.
    /// </summary>
    public void MettreEnPanne()
    {
        Enpanne = true;
    }

    /// <summary>
    /// Répare la pompe.
    /// </summary>
    public void Repare()
    {
        Enpanne = false;
    }

    /// <summary>
    /// Rend la pompe occupée si elle n’est pas en panne.
    /// </summary>
    public void Occuper()
    {
        if (!Enpanne)
        {
            Disponible = false;
        }
    }
}