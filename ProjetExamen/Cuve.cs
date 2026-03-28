namespace ProjetExamen;

public class Cuve
{
    public double capaciteActuelle {get; set;}
    public double capaciteMax {get; set;}
    public double capaciteMin {get; set;}
    public int numeeroCuve {get; set;}
    public TypeEssence carburant {get; set;}

    public Cuve(int numeeroCuve, TypeEssence carburant, double capaciteActuelle, double capaciteMax, double capaciteMin)
    {
        this.numeeroCuve = numeeroCuve;
        this.carburant = carburant;
        this.capaciteActuelle = capaciteActuelle;
        this.capaciteMax = capaciteMax;
        this.capaciteMin = capaciteMin;
        
    }

    public bool EstVide()
    {
        return capaciteActuelle == 0;
    }
    
    public bool EstPleine()
    {
        return capaciteActuelle >= capaciteMax;
    }

    public bool CommandEssenc()
    {
        return capaciteActuelle < capaciteMin;
    }

    public void Remplir(double quantite)
    {
        
    }

    public void DistriEssence(double quantite)
    {
        if (capaciteActuelle - quantite < capaciteMin)
        {
            Console.WriteLine("impossible de distribuer de l'essence");
        } 
        else if (capaciteActuelle - quantite > capaciteMin){
            Console.WriteLine(" c'est bon ");}
        
    }
    
    
}