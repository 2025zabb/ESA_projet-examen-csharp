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
    /// Initialise le numéro, la cuve associée et l'état par défaut.
    /// </summary>
    /// <param name="numeeroPistole">Numéro du pistolet</param>
    /// <param name="cuve">Cuve liée au pistolet</param>
    public Pistolet(int numeeroPistole, Cuve cuve)
    {
        NumeeroPistole = numeeroPistole;
        Cuve = cuve;
        Disponible = true;
        Enpanne = false;
    }

    /// <summary>
    /// Retourne l'état actuel du pistolet (disponible, utilisé ou en panne).
    /// </summary>
    /// <returns>Une chaîne décrivant l'état du pistolet</returns>
    public string Status()
    {
        if (Enpanne)
        {
            return "Le pistolet est en panne";
        }

        if (!Disponible)
        {
            return "Le pistolet est déjà utilisé";
        }

        return "Le pistolet est disponible";
    }

    /// <summary>
    /// Permet de distribuer une quantité de carburant depuis la cuve associée.
    /// </summary>
    /// <param name="quantite">Quantité de carburant demandée</param>
    /// <returns>Le prix total de la distribution ou null en cas d'erreur</returns>
    public double? Distribue(double quantite)
    {
        if (Enpanne)
        {
            Console.WriteLine("Le pistolet est en panne, pas de distribution");
            return null;
        }

        if (!Disponible)
        {
            Console.WriteLine("Le pistolet est déjà utilisé");
            return null;
        }

        // Le pistolet devient indisponible pendant la distribution
        Disponible = false;

        try
        {
            // Appel à la cuve pour distribuer le carburant et calculer le prix
            double? prix = Cuve.DistriEssence(quantite);
            return prix;
        }
        finally
        {
            // Le pistolet redevient disponible après utilisation
            Disponible = true;
        }


    }

    public void MettreEnPanne()
    {
        Enpanne = true;
    }

    public void Reparer()
    {
        Enpanne = false;
    }
    
    public void Occuper()
    {
        if (!Enpanne)
        {
            Disponible = false;
        }
    }
    
}

   