namespace ProjetExamen.Models;

/// <summary>
/// Représente les différents types de carburants disponibles.
/// </summary>
public enum NomCarburant
{
    /// <summary>
    /// Carburant diesel.
    /// </summary>
    Diesel,

    /// <summary>
    /// Essence sans plomb 95.
    /// </summary>
    Sp95,

    /// <summary>
    /// Essence sans plomb 98.
    /// </summary>
    Sp98,
    
    Lpg,
    Melange2Temps,
}

/// <summary>
/// Représente un type de carburant avec son prix par litre.
/// </summary>
public class TypeEssence

{
    /// <summary>
    /// Type de carburant (Diesel, SP95, SP98...).
    /// </summary>
    public NomCarburant Type { get; set; }

    /// <summary>
    /// Prix du carburant par litre.
    /// </summary>
    private double PrixParLitre { get; set; }
    
    /// <summary>
    /// Constructeur permettant d'initialiser le type de carburant et son prix.
    /// </summary>
    /// <param name="type">Type de carburant</param>
    /// <param name="prixParLitre">Prix par litre</param>
    public TypeEssence(NomCarburant type, double prixParLitre)
    {
        Type = type;
        PrixParLitre = prixParLitre;
    }

    /// <summary>
    /// Calcule le prix total pour une quantité donnée.
    /// </summary>
    /// <param name="litre">Quantité en litres</param>
    /// <returns>Prix total</returns>
    public double CalculerPrixTotal(double litre)
    {
        return PrixParLitre * litre;
    }

    /// <summary>
    /// Permet de récupérer le prix par litre.
    /// </summary>
    /// <returns>Prix par litre</returns>
    public double GetPrixParLitre()
    {
        return PrixParLitre;
    }
}