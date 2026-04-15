namespace ProjetExamen;

public class Vente
{ 
   
   double prixVenteTolal {get; set;}
   TypeEssence essence {get; set;}
   int quantite {get; set;}

   public Vente(double prixVenteTolal, TypeEssence essence, int quantite)
   {
      this.prixVenteTolal = prixVenteTolal;
      this.essence = essence;
      this.quantite = quantite;
   }
  
}