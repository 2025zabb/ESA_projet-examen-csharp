namespace ProjetExamen.Models;

abstract class Program
{
    static void Main(string[] args)
    {
        // ================================
        // 1. CREATION DE LA STATION
        // ================================
        StationService station = new StationService(
            "Total",
            "rue d'Assaut 40, 6000 Charleroi",
            new TimeSpan(6, 0, 0),
            new TimeSpan(20, 0, 0)
        );

        Console.WriteLine("===== STATION SERVICE =====");
        Console.WriteLine("Nom : " + station.Nom);
        Console.WriteLine("Adresse : " + station.Address);
        Console.WriteLine();

        // Horaires
        station.HorraireShop();
        Console.WriteLine();

        Employe employe1 = new Employe("Lefevre", "Boris", 1234, "Caisse");
        employe1.AfficherInfosPersonnelles();
        Console.WriteLine();

        // ================================
        // 2. CREATION DES CARBURANTS
        // ================================
        TypeEssence sp95 = new TypeEssence(NomCarburant.Sp95, 2.00);
        TypeEssence sp98 = new TypeEssence(NomCarburant.Sp98, 2.20);
        TypeEssence diesel = new TypeEssence(NomCarburant.Diesel, 1.80);

        // ================================
        // 3. CREATION DES CUVES
        // ================================
        Cuve cu1 = new Cuve(1, sp95, 200, 500, 150, 100);
        Cuve cu2 = new Cuve(2, sp98, 500, 150, 100);
        Cuve cu3 = new Cuve(3, diesel, 400, 500, 150, 100);

        station.AjouterCuve(cu1);
        station.AjouterCuve(cu2);
        station.AjouterCuve(cu3);
        Console.WriteLine();

        // ================================
        // 4. CREATION DES POMPES
        // ================================
        Pompe pop1 = new Pompe(1);
        Pompe pop2 = new Pompe(2);

        station.AjouterPompe(pop1);
        station.AjouterPompe(pop2);
        Console.WriteLine();

        // ================================
        // 5. CREATION DES PISTOLETS
        // ================================
        Pistolet p1 = new Pistolet(1, cu1);
        Pistolet p2 = new Pistolet(2, cu2);
        Pistolet p3 = new Pistolet(3, cu3);

        pop1.Pistolets.Add(p1);
        pop2.Pistolets.Add(p2);
        pop2.Pistolets.Add(p3);

        // ================================
        // 6. AFFICHAGES
        // ================================
        Console.WriteLine("===== STOCK DES CUVES =====");
        station.AffichagerDuStoke();
        Console.WriteLine();

        Console.WriteLine("===== POMPES =====");
        station.AfficherNombrePompe();
        Console.WriteLine();

        Console.WriteLine("===== PISTOLETS =====");
        station.AfficherPistolets();
        Console.WriteLine();

        Console.WriteLine("===== PRIX CARBURANT =====");
        station.AfficherPrixCarburant();
        Console.WriteLine();

        // ================================
        // 7. CREATION CLIENTS
        // ================================
        Client client1 = new Client("Nzabi", "Christian");
        Client client2 = new Client("Berto", "Boo");
        Client client3 = new Client("kabengwa", "Benedicte");

        // ================================
        // 8. ETAT DES CUVES
        // ================================
        Console.WriteLine("===== ETAT DES CUVES =====");
        cu1.EtatDeLaCuve();
        cu2.EtatDeLaCuve();
        cu3.EtatDeLaCuve();
        Console.WriteLine();

        // ================================
        // 9. FAIRE LE PLEIN
        // ================================
        Console.WriteLine("===== VENTES =====");
        
        client1.ChoixTypeEssence(NomCarburant.Sp95);
        station.RechercheBonneCarburant(NomCarburant.Diesel);
        pop1.FaireLePlein(client1, station, 30);
        
        Console.WriteLine();
        
        
        client1.ChoixTypeEssence(NomCarburant.Diesel);
        station.RechercheBonneCarburant(NomCarburant.Diesel);
        pop2.FaireLePlein(client2, station, 100);
       
        Console.WriteLine();
        
        client3.ChoixTypeEssence(NomCarburant.Sp95);
        station.RechercheBonneCarburant(NomCarburant.Diesel);
        pop1.FaireLePlein(client3, station, 30);
        

        // ================================æ
        // 10. HISTORIQUE DES VENTES
        // ================================
        Console.WriteLine("===== HISTORIQUE DES VENTES =====");
        station.AfficherHistoriqueDeVentes();
        Console.WriteLine();

        // ================================
        // 11. STOCK AVANT REAPPROVISIONNEMENT 
        // ================================
        Console.WriteLine("===== STOCK APRES VENTE =====");
        station.AffichagerDuStoke();
        Console.WriteLine();
        station.ControlerNiveauCuves();

        // ================================
        // FIN
        // ================================
        Console.WriteLine("Appuyez sur une touche pour quitter...");
        Console.ReadKey();
    }
}