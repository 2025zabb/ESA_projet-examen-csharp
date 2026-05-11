namespace ProjetExamen.Models;

/// <summary>
/// Représente un achat de carburant effectué pour une cuve.
/// </summary>
public class Achats
{
    /// <summary>
    /// Type de carburant acheté.
    /// </summary>
    public NomCarburant Carburant { get; set; }

    /// <summary>
    /// Quantité de carburant achetée.
    /// </summary>
    public double Quantite { get; set; }

    /// <summary>
    /// Prix du carburant par litre.
    /// </summary>
    public double Prix { get; set; }

    /// <summary>
    /// Jour où l’achat a été effectué.
    /// </summary>
    public DayOfWeek Jour { get; set; }

    /// <summary>
    /// Prix total de l’achat.
    /// </summary>
    public double Total { get; set; }

    /// <summary>
    /// Constructeur de la classe Achats.
    /// </summary>
    /// <param name="carburant">Type de carburant acheté.</param>
    /// <param name="quantite">Quantité achetée.</param>
    /// <param name="prix">Prix par litre.</param>
    /// <param name="jour">Jour de l’achat.</param>
    /// <param name="total">Montant total de l’achat.</param>
    public Achats(NomCarburant carburant, double quantite, double prix, DayOfWeek jour, double total)
    {
        Carburant = carburant;
        Quantite = quantite;
        Prix = prix;
        Jour = jour;
        Total = total;
    }
}