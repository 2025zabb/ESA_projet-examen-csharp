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

    public void Distribue(double quantite)
    {
        Cuve.DistriEssence(quantite);
        // pas finit
    }
}
