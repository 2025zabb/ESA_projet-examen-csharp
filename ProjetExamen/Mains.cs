namespace ProjetExamen;

class Mains
{
    static void Main(string[] args)
    {
        
        TypeEssence diesel = new TypeEssence(NomCarburant.diesel,1.94); 
        TypeEssence sp95 = new TypeEssence(NomCarburant.sp95,2.00);
        
        Cuve cuv1 = new Cuve(1,diesel,300,(1000),500,250); 
        cuv1.DistriEssence(400);
        cuv1.CommanderEtRemplirCuve(500);
        cuv1.DistriEssence(444);

        Console.WriteLine(" ");
        
        Cuve cuve2 = new Cuve(2, sp95, 0, 250, 200);
        Console.WriteLine(" la cuve est vraiment vide ?? " + cuve2.EstVide());
        
       
        Pistolet test = new Pistolet(2,cuv1);
        
        Console.WriteLine(" ");
        
        cuve2.EtatDeLaCuve();
        Console.WriteLine(" ");

        double PriPour50L =diesel.CalculerPrixParLitre(50);
        Console.WriteLine(" Le prix de 50L vaut : " + PriPour50L + " euro " );
        



    }
}