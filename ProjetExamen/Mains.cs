using System.Numerics;

namespace ProjetExamen;

class Mains
{
    static void Main(string[] args)
    {
        //  1. Station
        StationService station = new StationService("Total", "rue d'Assaut 40, 6000 Charleroi");

        Console.WriteLine("Station : " + station.Nom);
        Console.WriteLine("address de la Station Service : " +station.Address);
        Console.WriteLine("----------------------------------");
       
        

        //  Carburants
        TypeEssence sp95 = new TypeEssence(NomCarburant.Sp95, 2.00);
        TypeEssence sp98 = new TypeEssence(NomCarburant.Sp98, 2.20);
        TypeEssence diesel = new TypeEssence(NomCarburant.Diesel, 1.80);
       
        
        // création cuve
        Cuve cu1 = new Cuve(1, sp95, 200, 500, 150, 100);
        Cuve cu2 = new Cuve(2, sp95, 500, 150, 100);
        Cuve cu3 = new Cuve(3, diesel, 500, 500, 150, 100);
        
        // creation pompe
        Pompe pop1 = new Pompe(1);
        Pompe pop2 = new Pompe(2);
        
        //Ajoute des cuves dans la station-service
        station.AjouterCuve(cu1);
        station.AjouterCuve(cu2);
        station.AjouterCuve(cu3);
        // création des pompes dans la station
        station.AjouterPompe(pop1);
        station.AjouterPompe(pop2);
        Console.WriteLine(" ");
        
        // affiche stok et nombreux de pompes
        station.AffichagerDuStoke();
        Console.WriteLine(" ");
        station.AfficherNombrePompe();
        Console.WriteLine(" ");
        
        //creation des pistoles
        Pistolet pistolet1 = new Pistolet(1, cu1);
        Pistolet pistolet2 = new Pistolet(2, cu2);
        Pistolet pistolet3 = new Pistolet(3, cu3);
       
        //ajouter les pistoles sur les pompes
        pop1.Pistolets.Add(pistolet1);
        pop2.Pistolets.Add(pistolet2);
        pop2.Pistolets.Add(pistolet3);
        Console.WriteLine(" ");
        
        //afficher les pistoles
        station.AfficherPistolets();
        Console.WriteLine(" ");
        // creation client 
        Client client1 = new Client("Mme clarise");
        Client client2 = new Client("Mr berto");
        
        // test 
        cu1.EtatDeLaCuve();
        cu2.EtatDeLaCuve();
        cu3.EtatDeLaCuve();
        Console.WriteLine(" ");
        
        pop1.FaireLePlein(client1, 80);
        Console.WriteLine(" ");
        pop2.FaireLePlein(client2, 45);
        
        










    }
}