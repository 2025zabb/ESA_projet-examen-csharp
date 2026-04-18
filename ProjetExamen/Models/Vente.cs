namespace ProjetExamen.Models;

/// <summary>
/// Représente une vente de carburant effectuée dans la station-service.
/// Contient les informations sur le type de carburant, la quantité, le prix et le jour.
/// </summary>
public class Vente
{
    /// <summary>
    /// Prix total de la vente.
    /// </summary>
    public double Prix { get; set; }

    /// <summary>
    /// Type de carburant vendu.
    /// </summary>
    public NomCarburant Essence { get; set; }

    /// <summary>
    /// Quantité de carburant vendue (en litres).
    /// </summary>
    public double Quantite { get; set; }

    /// <summary>
    /// Jour de la vente.
    /// </summary>
    public DayOfWeek Jour { get; set; }

    /// <summary>
    /// Constructeur de la classe Vente.
    /// Initialise les informations d'une vente.
    /// </summary>
    /// <param name="prix">Prix total de la vente</param>
    /// <param name="essence">Type de carburant vendu</param>
    /// <param name="quantite">Quantité vendue (en litres)</param>
    /// <param name="jour">Jour de la vente</param>
    public Vente(double prix, NomCarburant essence, double quantite, DayOfWeek jour)
    {
        Prix = prix;
        Essence = essence;
        Quantite = quantite;
        Jour = jour;
    }

}