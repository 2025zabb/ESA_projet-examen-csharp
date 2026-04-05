namespace ProjetExamen;

public class Pistolet : IStatut
{
    public int numeeroPistole {get; set;}
    public bool disponible {get; set;}
    public bool enpanne {get; set;}
    public Cuve cuve {get; set;}

    public Pistolet(int numeeroPistole, Cuve cuve)
    {
        this.numeeroPistole = numeeroPistole;
        this.cuve = cuve;
        this.disponible = true;
        this.enpanne = false;
    }

    public string Status()
    {
        if (enpanne)
        {
            return "Le pistole est en panne";
        }

        if (!disponible)
        {
            return "le pistole est deja utiliser";
        }

        return "le pistole est disponible";
    }
}
