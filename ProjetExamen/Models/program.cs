using ProjetExamen.Models;

namespace ProjetExamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TypeEssence sp95 = new TypeEssence(NomCarburant.Sp95, 1.80);
            TypeEssence diesel = new TypeEssence(NomCarburant.Diesel, 1.70);
            TypeEssence sp98 = new TypeEssence(NomCarburant.Sp98, 1.95);

            Cuve cuveSp95 = new Cuve(1, sp95, 1000, 200, 100);
            Cuve cuveDiesel = new Cuve(2, diesel, 500, 1000, 200, 100);
            Cuve cuveSp98 = new Cuve(3, sp98, 120, 1000, 200, 100);

            Pompe pop1 = new Pompe(1, Typepompes.AutresUsage);

            Pistolet pistole1 = new Pistolet(1, cuveSp95);
            Pistolet pistole2 = new Pistolet(2, cuveDiesel);

            pop1.Pistolets.Add(pistole1);
            pop1.Pistolets.Add(pistole2);

            StationService station = new StationService(
                "MaStation",
                "Rue de test",
                new TimeSpan(8, 0, 0),
                new TimeSpan(18, 0, 0)
            );

            station.AjouterCuve(cuveSp95);
            station.AjouterCuve(cuveDiesel);
            station.AjouterCuve(cuveSp98);
            station.AjouterPompe(pop1);

            Console.WriteLine("===== ETAT AVANT CONTROLE =====");
            station.AffichagerDuStoke();

            Console.WriteLine();
            Console.WriteLine("===== CONTROLE DES CUVES =====");
            station.ControlerNiveauCuves();

            Console.WriteLine();
            Console.WriteLine("===== ETAT APRES CONTROLE =====");
            station.AffichagerDuStoke();

            Console.WriteLine();
            Console.WriteLine("===== PRIX CARBURANTS =====");
            station.AfficherPrixCarburant();

            Console.WriteLine();
            Console.WriteLine("===== TEST VENTE CLIENT =====");

            Client client1 = new Client("christ", "bob");
            Vehicule voiture = new Vehicule("rouge", "Clio 3", client1, CategoryVéhicules.Voiture);
            Vehicule moto = new Vehicule("vert", "bw", client1, CategoryVéhicules.Moto);

            client1.ChoixTypeEssence(NomCarburant.Sp95);
            station.RechercheBonneCarburant(NomCarburant.Sp95);

            pop1.FaireLePlein(client1, station, 72, NomCarburant.Sp95, voiture);

            Console.WriteLine();
            Console.WriteLine("===== TEST COMPATIBILITE =====");

            Client client2 = new Client("alice", "martin");
            Vehicule voitureTest = new Vehicule("bleu", "Peugeot 208", client2, CategoryVéhicules.Voiture);
            Vehicule camionTest = new Vehicule("blanc", "Scania", client2, CategoryVéhicules.Camion);

            Console.WriteLine("Test avec une voiture sur pompe AutresUsage :");
            pop1.FaireLePlein(client2, station, 20, NomCarburant.Sp95, voitureTest);

            Console.WriteLine();
            Console.WriteLine("Test avec un camion sur pompe AutresUsage :");
            pop1.FaireLePlein(client2, station, 20, NomCarburant.Sp95, camionTest);

            Console.WriteLine();
            
            
            Console.WriteLine();
            Console.WriteLine("===== TEST CARBURANT ABSENT =====");
            pop1.FaireLePlein(client1, station, 10, NomCarburant.Sp98,voiture);
            
            Console.WriteLine();
            Console.WriteLine("===== HISTORIQUE DES ACHATS =====");
            station.AfficherHistoriqueDAchats();

            Console.WriteLine();
            Console.WriteLine("===== HISTORIQUE DES VENTES =====");
            station.AfficherHistoriqueDeVentes();
        }
    }
}
