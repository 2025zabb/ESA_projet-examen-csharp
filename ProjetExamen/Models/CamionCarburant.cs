namespace ProjetExamen.Models;

public class CamionCarburant
{
    public double Quantite {get; set;}
    public double PrixParLitre {get; set;}

    public CamionCarburant(double quantite, double prixParLitre)
    {
        Quantite = quantite;
        PrixParLitre = prixParLitre;
    }

    public void LivraisonDuCarburant(Cuve cuve)
    {
        
        double cout = Quantite * PrixParLitre;
        
        Console.WriteLine($"Camion arrivé.");
        Console.WriteLine($"Quantité livrée : {Quantite} L");
        Console.WriteLine($"Coût total : {cout} €");
        
        cuve.SignalerProlemeDeDistribution();
        cuve.CommanderEtRemplirCuve(Quantite);
        cuve.ResoudreProblemeDistribution();
        
        
    }
}