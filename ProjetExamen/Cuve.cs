namespace ProjetExamen;

public class Cuve: InterfacCuve
{
    private double capaciteActuelle {get; set;}
    public double capaciteMax {get; set;}
    public double capaciteMin {get; set;}
    public int numeeroCuve {get; set;}
    public TypeEssence carburant {get; set;}
    public double seuilcapacite {get; set;}

    public Cuve(int numeeroCuve, TypeEssence carburant, double capaciteActuelle, double capaciteMax, double capaciteMin,double seuilcapacite)
    {
        this.numeeroCuve = numeeroCuve;
        this.carburant = carburant;
        this.capaciteActuelle = capaciteActuelle;
        this.capaciteMax = capaciteMax;
        this.capaciteMin = capaciteMin;
        this.seuilcapacite = seuilcapacite;
        
    }
    public bool EstVide()
    {
        return capaciteActuelle == 0;
    }

    public bool EstPleine()
    {
        return capaciteActuelle == capaciteMax;
    }

    public bool CommanderEssenc()
    {
       return capaciteActuelle <= capaciteMin;
    }
    
    public bool DonnerEssenc()
    {
        return !RemplissageEssenc && capaciteActuelle > seuilcapacite;
    }

    public bool RemplissageEssenc;
    
    public void Remplir(double quantite)
    {
     capaciteActuelle += quantite;
     if (capaciteActuelle > capaciteMax){
         capaciteActuelle = capaciteMax;}
    }

    public void CommanderEtRemplirCuve(double quantite)
    {
        if (CommanderEssenc())
        {
            Console.WriteLine("cuve " + numeeroCuve + " en remplissage");
            RemplissageEssenc = true;
            Remplir(quantite);
            
            RemplissageEssenc = false;
            Console.WriteLine("cuve " + numeeroCuve + "rempli");
        }
    }

    public void DistriEssence(double quantite)
    {
        if (!DonnerEssenc())
        {
            Console.WriteLine(" cuve ne peut distribution du carburant");
            return;
        }

        if (capaciteActuelle < quantite)
        {
            Console.WriteLine(" pas assez d'essence dans la cuve ");
            return;
        }
        capaciteActuelle -= quantite;
        Console.WriteLine(" distribution OK , " + quantite + " L distribué " );
    }

    public void EtatDeLaCuve(double quantite)
    {
        if (EstVide())
        {
            Console.WriteLine("nouvelle cuve " + numeeroCuve + " et vide ");
           
        } else if (EstPleine())
        {
            Console.WriteLine("la  cuve " + numeeroCuve + " pleine ");
        }
        else
        {
            Console.WriteLine(" la  cuve " + numeeroCuve + " en service ");
        }
    }

    public void RemplirCuveSiVide(double quantite)
    {
        if (EstVide())
        {
            CommanderEtRemplirCuve(quantite);
        }
    }
    
    public double GetcapaciteActuelle()
    {
        return capaciteActuelle;
    }
    
}