namespace ProjetExamen;
/// <summary>
/// Ca represente une cube de stokage de carburant, elle permet de remplire la cuve,
/// de voir son état , de distribue du carburant
/// </summary>
public class Cuve: InterfacCuve
{
    // represente la quantité actuelle du carburant dans la cuve en littre
    private double capaciteActuelle {get; set;}
    // represente la quantité maximale du carburant dans la cuve en littre
    public double capaciteMax {get; set;}
    // represente la quantité minimale du carburant dans la cuve en littre
    public double capaciteMin {get; set;}
    // represente le numero unique de la cuve
    public int numeeroCuve {get; set;}
    // represente le type de carburant adns la cuve en littre
    public TypeEssence carburant {get; set;}
    // represente le niveau de seuil de carburant a ne pas depasser dans la cuve en littre
    
    public double seuilcapacite {get; set;}
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
        this.numeeroCuve = numeeroCuve;
        this.carburant = carburant;
        this.capaciteActuelle = capaciteActuelle;
        this.capaciteMax = capaciteMax;
        this.capaciteMin = capaciteMin;
        this.seuilcapacite = seuilcapacite;
        
    }
    /// <summary>
    /// Constructeur de la cuve vide à la creation
    /// </summary>
    /// <param name="numeeroCuve"></param>
    /// <param name="carburant"></param>
    /// <param name="capaciteActuelle"></param>
    /// <param name="capaciteMax"></param>
    /// <param name="capaciteMin"></param>
    
    public Cuve(int numeeroCuve, TypeEssence carburant, double capaciteMax, double capaciteMin,double seuilcapacite) 
        : this (
        numeeroCuve, carburant,0,capaciteMax,capaciteMin,seuilcapacite){}
    
    /// <summary>
    /// Vérifie si la est vide 
    /// </summary>
    /// <returns></returns>
    
    public bool EstVide()
    {
        return capaciteActuelle == 0;
    }
    /// <summary>
    /// Vérifie si la est pleine
    /// </summary>
    /// <returns></returns>
    
    public bool EstPleine()
    {
        return capaciteActuelle == capaciteMax;
    }
    
    /// <summary>
    /// Vérifie si on doit commander du carbrant
    /// </summary>
    /// <returns></returns>
    
    public bool CommanderEssenc()
    {
       return capaciteActuelle <= capaciteMin;
    }
    /// <summary>
    ///Vérifie si la cuve peut distribuer du carburant
    /// </summary>
    /// <returns></returns>
    
    public bool DonnerEssenc()
    {
        return !RemplissageEssenc && capaciteActuelle > seuilcapacite;
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
     capaciteActuelle += quantite;
     if (capaciteActuelle > capaciteMax){
         capaciteActuelle = capaciteMax;}
    }
    
    /// <summary>
    /// Permet de commander et de remplir la cuve si nécessaire
    /// </summary>
    /// <param name="quantite"></param>
    
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
    
    /// <summary>
    /// Permet de distribue une quantité de carburant
    /// </summary>
    /// <param name="quantite"></param>
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
    
    /// <summary>
    /// Affiche l'état actuel de la cuve
    /// </summary>
    public void EtatDeLaCuve()
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
    
    /// <summary>
    /// Remplit la cuve automatiquement si elle est vide
    /// </summary>
    /// <param name="quantite"></param>
    public void RemplirCuveSiVide(double quantite)
    {
        if (EstVide())
        {
            CommanderEtRemplirCuve(quantite);
        }
    }
    
    /// <summary>
    /// Donne la capacité actuelle de la cuve
    /// </summary>
    /// <returns></returns>
    public double GetcapaciteActuelle()
    {
        return capaciteActuelle;
    }
    
}