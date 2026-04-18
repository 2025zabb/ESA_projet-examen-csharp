using ProjetExamen.Interfaces;

namespace ProjetExamen.Models;

/// <summary>
/// Représente une pompe dans une station-service.
/// Une pompe contient plusieurs pistolets et permet de distribuer du carburant.
/// </summary>
public class Pompe : IStatut
{
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
    public bool Enpane { get; set; }

    /// <summary>
    /// Liste des pistolets associés à la pompe.
    /// </summary>
    public List<Pistolet> Pistolets { get; set; }

    /// <summary>
    /// Type de cuve associé (optionnel selon ton modèle).
    /// </summary>
    public string TypeCuve { get; set; }

    /// <summary>
    /// Constructeur de la pompe.
    /// Initialise le numéro et l'état par défaut.
    /// </summary>
    /// <param name="numeeroPompe">Numéro de la pompe</param>
    public Pompe(int numeeroPompe)
    {
        NumeeroPompe = numeeroPompe;
        Disponible = true;
        Enpane = false;
        Pistolets = new List<Pistolet>();
    }

    /// <summary>
    /// Retourne l'état actuel de la pompe.
    /// </summary>
    /// <returns>Une chaîne décrivant l'état de la pompe</returns>
    public string Status()
    {
        if (Enpane)
        {
            return "Pompe en panne";
        }

        if (!Disponible)
        {
            return "Pompe pas disponible";
        }

        return "Pompe disponible";
    }

    /// <summary>
    /// Permet à un client de faire le plein via un pistolet disponible.
    /// Crée une vente et l'enregistre dans la station.
    /// </summary>
    /// <param name="client">Client effectuant le plein</param>
    /// <param name="station">Station-service contenant les ventes</param>
    /// <param name="quantite">Quantité de carburant demandée</param>
    public void FaireLePlein(Client client, StationService station, double quantite)
    {
        if (Enpane)
        {
            Console.WriteLine("Pompe hors service");
            return;
        }

        double? prix = null;

        foreach (var pi in Pistolets)
        {
            if (pi.Disponible && !Enpane)
            {
                // Distribution via le pistolet
                prix = pi.Distribue(quantite);

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

                    // Ajout de la vente à la station (et sauvegarde BDD)
                    station.AjouterUneVente(vente1);
                }

                return;
            }
        }

        // Aucun pistolet disponible
        Console.WriteLine("Aucun pistolet disponible");
    }
}