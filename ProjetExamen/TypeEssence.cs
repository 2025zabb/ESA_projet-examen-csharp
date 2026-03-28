namespace ProjetExamen;

public class TypeEssence
{
    public string type { get; set; }

    public double prix_par_litre {
        get; set;
    }
    
    public TypeEssence(string type, double prix_par_litre)
    {
        this.type = type;
        this.prix_par_litre = prix_par_litre ;
        
    }
}