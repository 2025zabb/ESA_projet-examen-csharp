namespace ProjetExamen.Models;

public class Vente
{ 
   
   public double PrixVenteTolal {get; set;}
   public NomCarburant Essences {get; set;}
   public double Quantites {get; set;}
   
   public DayOfWeek Jours {get; set;}

   public Vente(double prixVenteTolal, NomCarburant essences, double quantites, DayOfWeek jours)
   {
      this.PrixVenteTolal = prixVenteTolal;
      this.Essences = essences;
      this.Quantites = quantites;
      this.Jours = jours;
   }
   
  
}