using System.Numerics;

namespace ProjetExamen;

class Mains
{
    static void Main(string[] args)
    {
        StationService station = new StationService("Total", "rue de namur 180");
        Console.WriteLine("Nom de la station Service " + station.Nom);
        Console.WriteLine("Ladress de la Station Service " +station.Address);
        TypeEssence sp95 = new TypeEssence(NomCarburant.Sp95,2.00);
        Cuve cu1 = new Cuve(1, sp95, 200, 500, 150, 100);
        Pompe pop1 = new Pompe(1);
        station.AjouterCuve(cu1);
        station.AjouterPompe(pop1);
        
        Console.WriteLine(" ");
        
        Pistolet pistolet = new Pistolet(1, cu1);
        pistolet.Enpanne = true;
        Console.WriteLine(pistolet.Status());
        pistolet.Cuve.DistriEssence(55);
        
        Console.WriteLine(" ");
      
        Pompe pop2 = new Pompe(1);
        Pistolet pi1 = new Pistolet(1,cu1);
         pop2.Pistolets.Add(pi1);
         
        
       
        
       

        


    }
}