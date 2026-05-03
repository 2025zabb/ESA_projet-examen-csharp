namespace ProjetExamen.Models;

public class Achats
{
    public NomCarburant Carburant { get; set; }
    public double Quantite { get; set; }
    public double Prix { get; set; }
    public DayOfWeek Jour { get; set; }
    public double Total { get; set; }


    public Achats(NomCarburant carburant, double quantite, double prix, DayOfWeek jour,double total)
    {
        Carburant = carburant;
        Quantite = quantite;
        Prix = prix;
        Jour = jour;
        Total = total;
        
    }
}