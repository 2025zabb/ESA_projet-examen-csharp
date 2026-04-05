namespace ProjetExamen;
/// <summary>
/// Ca represente une cube de stokage de carburant, elle permet de remplire la cuve,
/// de voir son état , de distribue du carburant
/// </summary>
public class Cuve: INterfacCuve
{
    // represente la quantité actuelle du carburant dans la cuve en littre
    private double CapaciteActuelle {get; set;}
    // represente la quantité maximale du carburant dans la cuve en littre
    public double CapaciteMax {get; set;}
    // represente la quantité minimale du carburant dans la cuve en littre
    public double CapaciteMin {get; set;}
    // represente le numero unique de la cuve
    public int NumeeroCuve {get; set;}
    // represente le type de carburant adns la cuve en littre
    public TypeEssence Carburant {get; set;}
    // represente le niveau de seuil de carburant a ne pas depasser dans la cuve en littre
    
    public double Seuilcapacite {get; set;}
    /// <summary>
    /// Constructeur de la cuve remplit de maniere partiel ou total à la création
    /// </summary>
    /// <param name="numeeroCuve"></param>
    /// <param name="carburant"></param>
    /// <param name="capaciteActuelle"></param>
    /// <param name="capaciteMax"></param>
    /// <param name="capaciteMin"></param>
    /// <param name="seuilcapacite"></param>
    public Cuve(int numeeroCuve, TypeEssence carburant, double capaciteActuelle, double capaciteMax, double capaciteMin,double seuilcapacite)
    {
        this.NumeeroCuve = numeeroCuve;
        this.Carburant = carburant;
        this.CapaciteActuelle = capaciteActuelle;
        this.CapaciteMax = capaciteMax;
        this.CapaciteMin = capaciteMin;
        this.Seuilcapacite = seuilcapacite;
        
    }

    /// <summary>
    /// Constructeur de la cuve vide à la creation
    /// </summary>
    /// <param name="numeeroCuve"></param>
    /// <param name="carburant"></param>
    /// <param name="capaciteMax"></param>
    /// <param name="capaciteMin"></param>
    /// <param name="seuilcapacite"></param>
    public Cuve(int numeeroCuve, TypeEssence carburant, double capaciteMax, double capaciteMin,double seuilcapacite) 
        : this (
        numeeroCuve, carburant,0,capaciteMax,capaciteMin,seuilcapacite){}
    
    /// <summary>
    /// Vérifie si la est vide 
    /// </summary>
    /// <returns></returns>
    
    public bool EstVide()
    {
        return CapaciteActuelle == 0;
    }
    /// <summary>
    /// Vérifie si la est pleine
    /// </summary>
    /// <returns></returns>
    
    public bool EstPleine()
    {
        return CapaciteActuelle == CapaciteMax;
    }
    
    /// <summary>
    /// Vérifie si on doit commander du carbrant
    /// </summary>
    /// <returns></returns>
    
    public bool CommanderEssenc()
    {
       return CapaciteActuelle <= CapaciteMin;
    }
    /// <summary>
    ///Vérifie si la cuve peut distribuer du carburant
    /// </summary>
    /// <returns></returns>
    
    public bool DonnerEssenc()
    {
        return !RemplissageEssenc && CapaciteActuelle > Seuilcapacite;
    }
    
    /// <summary>
    /// Indique si la cuve est entrain d'etre remplie
    /// </summary>
    
    public bool RemplissageEssenc;
    /// <summary>
    /// Remplit la cuve avec une quantité donnéé de carburant
    /// </summary>
    /// <param name="quantite"></param>
    
    public void Remplir(double quantite)
    {
     CapaciteActuelle += quantite;
     if (CapaciteActuelle > CapaciteMax){
         CapaciteActuelle = CapaciteMax;}
    }
    
    /// <summary>
    /// Permet de commander et de remplir la cuve si nécessaire
    /// </summary>
    /// <param name="quantite"></param>
    
    public void CommanderEtRemplirCuve(double quantite)
    {
        if (CommanderEssenc())
        {
            Console.WriteLine("cuve " + NumeeroCuve + " en remplissage");
            RemplissageEssenc = true;
            Remplir(quantite);
            Console.WriteLine("la cuve " + NumeeroCuve + " a été remplit de " + quantite + " L");
            
            RemplissageEssenc = false;
            Console.WriteLine("cuve " + NumeeroCuve + " peut etre utilise maintenat");
        }
    }
    
    /// <summary>
    /// Permet de distribue une quantité de carburant
    /// </summary>
    /// <param name="quantite"></param>
    public double? DistriEssence(double quantite)
    {
        if (!DonnerEssenc())
        {
            Console.WriteLine(" La cuve ne peut distribuer du carburant");
            return null;
        }

        if (CapaciteActuelle < quantite)
        {
            Console.WriteLine(" pas assez d'essence dans la cuve ");
            return null;
        }
        CapaciteActuelle -= quantite;
        double lePrix = Carburant.CalculerPrixParLitre(quantite);
        
        
        Console.WriteLine(" distribution OK , " + quantite + " L distribué " );
        Console.WriteLine("Prix à paie " + lePrix + " € ");
        return lePrix;
    }
    
    /// <summary>
    /// Affiche l'état actuel de la cuve
    /// </summary>
    public void EtatDeLaCuve()
    {
        if (EstVide())
        {
            Console.WriteLine("nouvelle cuve " + NumeeroCuve + " et vide ");
           
        } else if (EstPleine())
        {
            Console.WriteLine("la  cuve " + NumeeroCuve + " pleine ");
        }
        else
        {
            Console.WriteLine(" la  cuve " + NumeeroCuve + " en service ");
        }
    }
    
    /// <summary>
    /// Remplit la cuve automatiquement si elle est vide
    /// </summary>
    /// <param name="quantite"></param>
    public void RemplirCuveSiVide(double quantite)
    {
        if (EstVide())
        {
            CommanderEtRemplirCuve(quantite);
            Console.WriteLine(" La cuve a été remplit de " + quantite + " L");
        }
    }
    
    /// <summary>
    /// Donne la capacité actuelle de la cuve
    /// </summary>
    /// <returns></returns>
    public double GetcapaciteActuelle()
    {
        return CapaciteActuelle;
    }
    
}