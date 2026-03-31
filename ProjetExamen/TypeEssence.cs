namespace ProjetExamen;


public enum NomCarburant
{
    diesel,
    sp95,
    sp98,
    
}
public class TypeEssence
{
    public NomCarburant type { get; set; }

    public double prix_par_litre {
        get; set;
    }
    
    public TypeEssence(NomCarburant type, double prix_par_litre)
    {
        this.type = type;
        this.prix_par_litre = prix_par_litre ;
        
    }
}