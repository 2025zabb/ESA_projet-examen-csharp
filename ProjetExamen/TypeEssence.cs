namespace ProjetExamen;
/// <summary>
/// Represente les differents types de carburants disponible
/// </summary>

public enum NomCarburant
{
    // carbutant disel
    diesel,
    //essence sans plomb
    sp95,
    //essence sans plomb
    sp98,
    
}
/// <summary>
/// Represente un type d'essence avec son prix
/// </summary>
public class TypeEssence
{
    //  type de carburant (diesel,sp95...)
    public NomCarburant type { get; set; }

    // prix du carburant par litre
    public double prix_par_litre {
        get; set;
    }
    
    /// <summary>
    /// Constructeur permettant d'initialiser le type d'essence avec son prix
    /// </summary>
    /// <param name="type"></param>
    /// <param name="prix_par_litre"></param>
    public TypeEssence(NomCarburant type, double prix_par_litre)
    {
        this.type = type;
        this.prix_par_litre = prix_par_litre ;
        
    }
    /// <summary>
    /// Calculer le prix pour une quantite donnee
    /// </summary>
    /// <param name="litre"></param>
    /// <returns></returns>
    public double CalculerPrixParLitre(double litre)
    {
        double total = prix_par_litre * litre;
        return total;
    }
}