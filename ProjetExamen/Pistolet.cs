namespace ProjetExamen;

public class Pistolet
{
    public int numeeroPistole {get; set;}
    public bool disponible {get; set;}
    public bool enpanne {get; set;}
    public Cuve cuve {get; set;}

    public Pistolet(int numeeroPistole, Cuve cuve)
    {
        this.numeeroPistole = numeeroPistole;
        this.cuve = cuve;
        disponible = true;
        enpanne = false;
    }
}