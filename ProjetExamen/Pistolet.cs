namespace ProjetExamen;

public class Pistolet : IStatut
{
    public int NumeeroPistole {get; set;}
    public bool Disponible {get; set;}
    public bool Enpanne {get; set;}
    public Cuve Cuve {get; set;}

    public Pistolet(int numeeroPistole, Cuve cuve)
    {
        this.NumeeroPistole = numeeroPistole;
        this.Cuve = cuve;
        this.Disponible = true;
        this.Enpanne = false;
    }

    public string Status()
    {
        if (Enpanne)
        {
            return "Le pistole est en panne";
        }

        if (!Disponible)
        {
            return "le pistole est deja utiliser";
        }

        return "le pistole est disponible";
    }

    public double? Distribue(double quantite)
    {
        if (Enpanne)
        {
            Console.WriteLine("Le pistole est en panne, pas de distribution");
            return null;
        }

        if (!Disponible)
        {
            Console.WriteLine("Le pistole est deja utiliser");
            return null;
        }
        
        Disponible = false;
        double? prix = Cuve.DistriEssence(quantite);
        
        Disponible = true;
        return prix;
       
    }
}
