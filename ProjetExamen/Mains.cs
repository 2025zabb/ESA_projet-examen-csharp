namespace ProjetExamen;

class Mains
{
    static void Main(string[] args)
    {
        
        TypeEssence diesel = new TypeEssence(NomCarburant.Diesel,1.94); 
        TypeEssence sp95 = new TypeEssence(NomCarburant.Sp95,2.00);
        
        Cuve cuve = new Cuve(1,diesel,100,300,150,50);
        cuve.EtatDeLaCuve();
        Console.WriteLine(" ");
        Pistolet pistolet = new Pistolet(1, cuve);
        pistolet.Enpanne = true;
        Console.WriteLine(pistolet.Status());
        pistolet.Cuve.DistriEssence(30);





    }
}