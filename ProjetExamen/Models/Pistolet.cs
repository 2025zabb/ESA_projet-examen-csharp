using ProjetExamen.Interfaces;

namespace ProjetExamen.Models;

/// <summary>
/// Représente un pistolet de distribution de carburant relié à une cuve.
/// Permet de distribuer du carburant et de vérifier son état.
/// </summary>
public class Pistolet : IStatut
{
    /// <summary>
    /// Numéro du pistolet.
    /// </summary>
    public int NumeeroPistole { get; set; }

    /// <summary>
    /// Indique si le pistolet est disponible.
    /// </summary>
    public bool Disponible { get; private set; }

    /// <summary>
    /// Indique si le pistolet est en panne.
    /// </summary>
    public bool Enpanne { get; private set; }

    /// <summary>
    /// Cuve associée au pistolet.
    /// </summary>
    public Cuve Cuve { get; set; }

    /// <summary>
    /// Constructeur du pistolet.
    /// Initialise le numéro, la cuve associée
    /// et l’état par défaut.
    /// </summary>
    /// <param name="numeeroPistole">Numéro du pistolet.</param>
    /// <param name="cuve">Cuve liée au pistolet.</param>
    public Pistolet(int numeeroPistole, Cuve cuve)
    {
        NumeeroPistole = numeeroPistole;
        Cuve = cuve;

        // Le pistolet est disponible au départ
        Disponible = true;

        // Le pistolet n’est pas en panne au départ
        Enpanne = false;
    }

    /// <summary>
    /// Retourne l’état actuel du pistolet.
    /// </summary>
    /// <returns>
    /// Une chaîne décrivant l’état du pistolet.
    /// </returns>
    public string Status()
    {
        // Vérifie si le pistolet est en panne
        if (Enpanne)
        {
            return "Le pistolet est en panne";
        }

        // Vérifie si le pistolet est déjà utilisé
        if (!Disponible)
        {
            return "Le pistolet est déjà utilisé";
        }

        // Sinon le pistolet est disponible
        return "Le pistolet est disponible";
    }

    /// <summary>
    /// Distribue une quantité de carburant
    /// depuis la cuve associée.
    /// </summary>
    /// <param name="quantite">
    /// Quantité de carburant demandée.
    /// </param>
    /// <returns>
    /// Le prix total ou null en cas d’erreur.
    /// </returns>
    public double? Distribue(double quantite)
    {
        // Vérifie si le pistolet est en panne
        if (Enpanne)
        {
            Console.WriteLine(
                "Le pistolet est en panne, "
                + "distribution impossible");

            return null;
        }

        // Vérifie si le pistolet est déjà utilisé
        if (!Disponible)
        {
            Console.WriteLine(
                "Le pistolet est déjà utilisé");

            return null;
        }

        // Le pistolet devient indisponible
        // pendant la distribution
        Disponible = false;

        try
        {
            // Demande à la cuve de distribuer le carburant
            // et récupère le prix total
            double? prix = Cuve.DistriEssence(quantite);

            return prix;
        }
        finally
        {
            // Le pistolet redevient disponible
            // après utilisation
            Disponible = true;
        }
    }

    /// <summary>
    /// Met le pistolet en panne.
    /// </summary>
    public void MettreEnPanne()
    {
        Enpanne = true;
    }

    /// <summary>
    /// Répare le pistolet.
    /// </summary>
    public void Reparer()
    {
        Enpanne = false;
    }

    /// <summary>
    /// Rend le pistolet occupé s’il n’est pas en panne.
    /// </summary>
    public void Occuper()
    {
        if (!Enpanne)
        {
            Disponible = false;
        }
    }
}