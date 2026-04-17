namespace ProjetExamen.Models;
/// <summary>
/// Represente les differents types de carburants disponible
/// </summary>

public enum NomCarburant
{
    // carbutant disel
    Diesel,
    //essence sans plomb
    Sp95,
    //essence sans plomb
    Sp98,
    
}
/// <summary>
/// Represente un type d'essence avec son prix
/// </summary>
public class TypeEssence
{
    //  type de carburant (diesel,sp95...)
    public NomCarburant Type { get; set; }

    // prix du carburant par litre
    private double PrixParlitre {
        get; set;
    }
    
    /// <summary>
    /// Constructeur permettant d'initialiser le type d'essence avec son prix
    /// </summary>
    /// <param name="type"></param>
    /// <param name="prixParlitre"></param>
    public TypeEssence(NomCarburant type, double prixParlitre)
    {
        this.Type = type;
        this.PrixParlitre = prixParlitre ;
        
    }
    /// <summary>
    /// Calculer le prix pour une quantite donnee
    /// </summary>
    /// <param name="litre"></param>
    /// <returns></returns>
    public double CalculerPrixParLitre(double litre)
    {
        double total = PrixParlitre * litre;
        return total;
    }
    /// <summary>
    /// Permet de récupérer le prix
    /// </summary>
    /// <returns> le prix</returns>
    public double GetPrixParLitre()
    {
        return PrixParlitre;
    }

   
}