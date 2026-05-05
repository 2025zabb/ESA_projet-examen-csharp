using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Pompe))]
public class PompeTest
{

    [TestMethod]
    public void Constructeur_InitialiserPompe()
    {
        int numeeroPompe = 1;
        Typepompes typePompe = Typepompes.AutresUsage;
        
        Pompe pompe = new Pompe(numeeroPompe, typePompe);
        
        Assert.AreEqual(1,pompe.NumeeroPompe);
        Assert.AreEqual(Typepompes.AutresUsage, pompe.TypePompe);
        Assert.IsFalse(pompe.Enpanne);
        Assert.IsTrue(pompe.Disponible);
        Assert.IsNotNull(pompe.Pistolets);
        Assert.AreEqual(0, pompe.Pistolets.Count);

    }

    [TestMethod]
    public void StatPompeDisponible()
    {
        
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        pompe.MettreEnPanne();
        pompe.Repare();
        
        string traite = pompe.Status();

       
        Assert.AreEqual("Pompe disponible", traite);
    }
    
    [TestMethod]
    public void EtatPompeEnpanne()
    {
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        pompe.Repare();
        pompe.MettreEnPanne();
        
        pompe.Status();
        
        Assert.AreEqual("Pompe en panne",pompe.Status());
        
    }
    
    [TestMethod]
    public void EtatPompePasDisponible()
    {
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        
        pompe.Occuper();
        
        pompe.Status();
        
        Assert.AreEqual("Pompe pas disponible",pompe.Status());
        
    }
    

    [TestMethod]
    public void MettreEnPanne_ChangerStat_du_Pompe()
    {
        Pompe pompe = new Pompe(1, Typepompes.CamionDebitRapide);
        
        pompe.MettreEnPanne();
        Assert.IsTrue(pompe.Enpanne);
        
    }

    [TestMethod]
    public void Repare_ChangerEtat_du_Pompe()
    {
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        pompe.MettreEnPanne();
        pompe.Repare();
        Assert.IsFalse(pompe.Enpanne);
    }

    [TestMethod]
    public void Occuper_Pistolet_DevientIndisponible()
    {
        
        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp95, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 1000, 2000, 500, 250);
        Pistolet pistolet = new Pistolet(1, cuve);
        
        pistolet.Occuper();
        
        Assert.IsFalse(pistolet.Disponible);
        
    }
    
    
    [TestMethod]
    public void Occuper_PistoletEnPanne_ResteDisponible()
    {
        
        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp95, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 1000, 2000, 500, 250);
        Pistolet pistolet = new Pistolet(1, cuve);
        
        pistolet.MettreEnPanne();
        pistolet.Occuper();
        
        Assert.IsTrue(pistolet.Disponible);
        Assert.IsTrue(pistolet.Enpanne);
        
    }
    
    
    [TestMethod]
    public void FaireLePlein_PompeEnPanne_AfficheMessageErreur()
    {
        double quantite = 100;
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        
        Client client = new Client("KB", "ben-ten");
        Vehicule voiture = new Vehicule("Rouge", "Clio", client, CategoryVéhicules.Voiture);

        pompe.MettreEnPanne();
       
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        pompe.FaireLePlein(client,station,quantite,NomCarburant.Sp95,voiture);
        
        
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, "Pompe hors service");;
        Assert.IsTrue(pompe.Enpanne);
    }
    
    [TestMethod]
    
    public void FaireLePlein_VehiculeNonCompatible_AfficheMessageErreur()
    {
        double quantite = 100;
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(10,0,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        
        Client client = new Client("KB", "ben-ten");
        Vehicule voiture = new Vehicule("Rouge", "Clio", client, CategoryVéhicules.Camion);

     
       
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        pompe.FaireLePlein(client,station,quantite,NomCarburant.Sp95,voiture);
        
        
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, "Ce véhicule n’est pas compatible avec la pompe");
       
    }
    

    [TestMethod]
    
    public void VerifierPompeEtVehicule_PompeAutreUsage_Voiture_ok()
    {
     Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
     Client client = new Client("KB", "ben-ten");
     Vehicule vehicule = new Vehicule("jaune", "clio 3", client, CategoryVéhicules.Voiture);
     
     bool verif = pompe.VerifierPompeEtVehicule(vehicule);

     Assert.IsTrue(verif);
    }
    
    [TestMethod]
    public void VerifierPompeEtVehicule_PompeAutreUsage_Moto_ok()
    {
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        Client client = new Client("Smalville", "ClarK");
        Vehicule vehicule = new Vehicule("jaune", "clio 3", client, CategoryVéhicules.Voiture);
        
        bool verif =  pompe.VerifierPompeEtVehicule(vehicule);
        
        Assert.IsTrue(verif);
    }
    
    [TestMethod]
    public void VerifierPompeEtVehicule_PompeCamion_Camion_ok()
    {
        Pompe pompe = new Pompe(1, Typepompes.CamionDebitRapide);
        Client client = new Client("KB", "ben-ten");
        Vehicule vehicule = new Vehicule("jaune", "clio 3", client, CategoryVéhicules.Camion);
        
        bool verif = pompe.VerifierPompeEtVehicule(vehicule);
        Assert.IsTrue(verif);
        
    }

    [TestMethod]
    public void VerifierPompeEtVehicule_DoitRetournerFaux_PourVoitureSurPompeCamion()
    {
        Pompe pompe = new Pompe(1, Typepompes.CamionDebitRapide);
        Client client = new Client("Joel", "CLIPton");
        Vehicule vehicule = new Vehicule("jaune", "clio 3", client, CategoryVéhicules.Voiture); 
        
        bool verif = pompe.VerifierPompeEtVehicule(vehicule);
        Assert.IsFalse(verif);
        
    }

    [TestMethod]
    public void FaireLePlein_CarburantNonDisponible_AfficheMessage()
    {
        double quantite = 100;
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(6,0,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        
        Client client = new Client("George", "tristan");
        Vehicule voiture = new Vehicule("jaune", "BMW", client, CategoryVéhicules.Voiture);


        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp95, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 1000, 2000, 500, 250);
        Pistolet pistolet = new Pistolet(1, cuve);
        pompe.Pistolets.Add(pistolet);
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        pompe.FaireLePlein(client,station,quantite,NomCarburant.Sp98,voiture);
        
        
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, "Le carburant demandé n’est pas servi ici");;
       
    }
    
    [TestMethod]
    public void FaireLePlein_PistoletEnPanne_AfficheMessage()
    {
        double quantite = 100;
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(6,0,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        
        Client client = new Client("George", "tristan");
        Vehicule voiture = new Vehicule("jaune", "BMW", client, CategoryVéhicules.Voiture);


        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp98, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 1000, 2000, 500, 250);
        Pistolet pistolet = new Pistolet(1, cuve);
        
        
        pompe.Pistolets.Add(pistolet);
        pistolet.MettreEnPanne();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        pompe.FaireLePlein(client,station,quantite,NomCarburant.Sp98,voiture);
        
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, "Un pistolet du bon carburant est en panne");;
       
    }
    
    
    [TestMethod]
    public void FaireLePlein_PistoletPasDisponible_AfficheMessage()
    {
        double quantite = 100;
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(4,0,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        
        Client client = new Client("Paul", "solp");
        Vehicule voiture = new Vehicule("Noir", "AUDI", client, CategoryVéhicules.Voiture);


        TypeEssence carbutant = new TypeEssence(NomCarburant.Diesel, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 100, 50, 25, 5);
        Pistolet pistolet = new Pistolet(1, cuve);
        
        
        pompe.Pistolets.Add(pistolet);
        pistolet.Occuper();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        pompe.FaireLePlein(client,station,quantite,NomCarburant.Diesel,voiture);
        
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, "Un pistolet du bon carburant n’est pas disponible");;
       
    }
    
    

}