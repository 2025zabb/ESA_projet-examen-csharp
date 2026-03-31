namespace ProjetExamen;

class Mains
{
    static void Main(string[] args)
    {
        
        TypeEssence diesel = new TypeEssence(NomCarburant.diesel,1.94); 
        
        Cuve cuv1 = new Cuve(1,diesel,300,(1000),500,250); 
        cuv1.DistriEssence(400);
        cuv1.CommanderEtRemplirCuve(500);
        cuv1.DistriEssence(444);
        
        

    }
}