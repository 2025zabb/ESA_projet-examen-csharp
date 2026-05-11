using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(StationService))]
public class StationServiceTest
{

    [TestMethod]
    public void Constructeur_InitialiseCorrectement()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        
        TimeSpan ouverture = new TimeSpan(5,0,0);
        TimeSpan fermeture = new TimeSpan(18,0,0);
        
        Assert.IsNotNull(station);
        Assert.IsInstanceOfType(station, typeof(StationService));
        Assert.AreEqual("MyStation",station.Nom);
        Assert.AreEqual("rue des Alliés",station.Address);
        Assert.AreEqual(ouverture,station.HoraireOuvertureShop);
        Assert.AreEqual(fermeture,station.HoraireFermetureShop);
        Assert.IsNotNull(station.Cuves);
        Assert.AreEqual(0, station.Cuves.Count);
        Assert.IsNotNull(station.Ventes);
        Assert.AreEqual(0, station.Ventes.Count);
        Assert.IsNotNull(station.Achats);
        Assert.AreEqual(0, station.Achats.Count);
        Assert.IsNotNull(station.Pompes);
        Assert.AreEqual(0, station.Pompes.Count);
        
    }

    [TestMethod]
    public void AjouterCuve_DoitAjouterLaCuveALaListe()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AjouterCuve(cuve);
        
        string resultat = sw.ToString();
        
        Assert.IsNotNull(station.Cuves);
        Assert.AreEqual(1, station.Cuves.Count);
        StringAssert.Contains(resultat,"Cuve " + cuve.NumeeroCuve + " a été ajoutée à la station service  " + station.Nom);
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }

    [TestMethod]
    public void AjouterPompe_DoitAjouterLaPompeALaStationService()

    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
         station.AjouterPompe(pompe);
        
        string resultat = sw.ToString();
        
        Assert.IsNotNull(station.Pompes);
        Assert.AreEqual(1, station.Pompes.Count);
        StringAssert.Contains(resultat,"Pompe " + pompe.NumeeroPompe + " a été creer dans la station service " + station.Nom);
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [TestMethod]
    public void SupprimerCuve_DoitRetirerLaCuveDeLaStationService()

    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AjouterCuve(cuve);
        station.SupprimerCuve(cuve);
        
        string resultat = sw.ToString();
        
        
        Assert.AreEqual(0, station.Cuves.Count);
        StringAssert.Contains(resultat,"Cuve" + cuve.NumeeroCuve + " a été supprimer de la station service " + station.Nom);
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [TestMethod]
    public void SupprimerPompe_DoitRetirerLaPompeDeLaStationService()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        station.AjouterPompe(pompe);
        station.SupprimerPompe(pompe);
        
        string resultat = sw.ToString();
        
        
        Assert.AreEqual(0, station.Pompes.Count);
        StringAssert.Contains(resultat,"Pompe " + pompe.NumeeroPompe + "  supprimer de la station-service " + station.Nom);
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });   
    }

    [TestMethod]
    public void AfficherDuStock_DoitAfficherLesInformationsDuStock()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Cuve cuve2 = new Cuve(2,typeEssence,800,1000,500,100);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AjouterCuve(cuve);
        station.AjouterCuve(cuve2);
        
        station.AffichagerDuStoke();
        
        string resultat = sw.ToString();
        
        
        Assert.AreEqual(2, station.Cuves.Count);
        StringAssert.Contains(resultat,"La capacite de la cuve " + cuve.NumeeroCuve + " vaut : " + cuve.GetcapaciteActuelle() + " Littre disponible ");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [TestMethod]
    public void AfficherNombrePompe_DoitAfficherChaquePompeAvecSonNumeroEtSonStatut()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        Pompe pompe2 = new Pompe(2, Typepompes.CamionDebitRapide);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        station.AjouterPompe(pompe);
        station.AjouterPompe(pompe2);
        
        station.AfficherNombrePompe();
        string resultat = sw.ToString();
        
        
        Assert.AreEqual(2, station.Pompes.Count);
        StringAssert.Contains(resultat,"Pompe n°"  + pompe.NumeeroPompe + " " + pompe.Status());
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });      
    }

    [TestMethod]
    public void AfficherPistolets_DoitAfficherLaListeDesPistolets()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Cuve cuve2 = new Cuve(2,typeEssence,800,1000,500,100);
        Pompe pompe = new Pompe(1, Typepompes.AutresUsage);
        Pompe pompe2 = new Pompe(2, Typepompes.CamionDebitRapide);
        
        Pistolet pistolet = new Pistolet(1, cuve);
        Pistolet pistolet2 = new Pistolet(2, cuve2);
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        pompe.Pistolets.Add(pistolet);
        pompe2.Pistolets.Add(pistolet2);
        
        station.AjouterPompe(pompe);
        station.AjouterPompe(pompe2);
        
        station.AfficherPistolets();
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, "Pistolet " + pistolet.NumeeroPistole + " - " + pistolet.Status());
        StringAssert.Contains(resultat, "Pistolet " + pistolet2.NumeeroPistole + " - " + pistolet2.Status());
        
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [TestMethod]
    public void HorraireShop_DoitAfficherLesHorairesDuShop()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
       
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        station.HorraireShop();
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, $"""
                                         Horaires du shop
                                         ----------------
                                         Lundi    : {station.HoraireOuvertureShop:hh\:mm} - {station.HoraireFermetureShop:hh\:mm}
                                         Mardi    : {station.HoraireOuvertureShop:hh\:mm} - {station.HoraireFermetureShop:hh\:mm}
                                         Mercredi : {station.HoraireOuvertureShop:hh\:mm} - {station.HoraireFermetureShop:hh\:mm}
                                         Jeudi    : {station.HoraireOuvertureShop:hh\:mm} - {station.HoraireFermetureShop:hh\:mm}
                                         Vendredi : {station.HoraireOuvertureShop:hh\:mm} - {station.HoraireFermetureShop:hh\:mm}
                                         Samedi   : {station.HoraireOuvertureShop:hh\:mm} - {station.HoraireFermetureShop:hh\:mm}
                                         Dimanche : Fermé
                                         """);
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }

    [TestMethod]
    public void AfficherPrixCarburant_DoitAfficherLePrixDeChaqueCarburantUneSeuleFois()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        TypeEssence typeEssence2 = new TypeEssence(NomCarburant.Sp98, 4);
        TypeEssence typeEssence3 =  new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Cuve cuve2 = new Cuve(2,typeEssence2,800,1000,500,100);
        Cuve cuve3 = new Cuve(3,typeEssence3,750,900,500,100);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AjouterCuve(cuve);
        station.AjouterCuve(cuve2);
        station.AjouterCuve(cuve3);
        
        station.AfficherPrixCarburant();
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, cuve.Carburant.Type+ ":" + cuve.Carburant.GetPrixParLitre()+ " €/L");
        StringAssert.Contains(resultat,cuve2.Carburant.Type+ ":" + cuve2.Carburant.GetPrixParLitre()+ " €/L");
        Assert.AreEqual(cuve.Carburant.Type, cuve3.Carburant.Type);
        Assert.IsTrue(resultat.IndexOf("Dissel", StringComparison.Ordinal) == resultat.LastIndexOf("Dissel", StringComparison.Ordinal));
        
        
        
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [TestMethod]
    public void AjouterUneVente_DoitAjouterLaVenteEtLaSauvegarder()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Vente vente = new Vente(2, NomCarburant.Lpg,50, DayOfWeek.Friday);
        
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
         
        
        station.AjouterUneVente(vente);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"une vente a été ajouter ");
        Assert.AreEqual(1,station.Ventes.Count);
    }
    
    [TestMethod]
    public void AjouterUneAchat_DoitAjouterUnAchatEtLaSauvegarder()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Achats achat = new Achats(NomCarburant.Diesel, 40,2,DayOfWeek.Thursday,80);
       
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AjouterUnAchat(achat);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"un achat a été ajouter ");
        Assert.AreEqual(1,station.Achats.Count);
        
    }

    [TestMethod]
    public void AfficherHistoriqueDeVentes_DoitAfficherLeMessageAucunVenteQuandIlNyaPasDeVente()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        

       
       
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AfficherHistoriqueDeVentes();
        
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"Pas de vente");
    }
    
    
    [TestMethod]
    public void AfficherHistoriqueDeVentes_DoitAfficherLesVentesQuandIlyaDeVente()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Vente vente = new Vente(2, NomCarburant.Lpg,50, DayOfWeek.Friday);
        Vente vente1 = new Vente(3, NomCarburant.Diesel, 60, DayOfWeek.Thursday);

        
       
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        station.Ventes.Add(vente);
        station.Ventes.Add(vente1);
        station.AfficherHistoriqueDeVentes();
       
        
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"Carburant : " + vente.Essence +
                                  " Quantité : " + vente.Quantite + " L " +
                                  " Prix : " + vente.Prix + " €" +
                                  " Jour : " + vente.Jour);
    }

    [TestMethod]
    public void AfficherHistoriqueDAchats_DoitAfficherLeMessageAucunAchatQuandIlNyAPasDAchat()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        station.AfficherHistoriqueDAchats();
        
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"Pas d'Achat");
    }
    
    [TestMethod]
    public void AfficherHistoriqueDAchats_DoitAffiLesAchatQuandIlyaAchat()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
   
        Achats achat = new Achats(NomCarburant.Sp95,30,2,DayOfWeek.Thursday,80);

        
       
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
       station.Achats.Add(achat);
       station.AfficherHistoriqueDAchats();
       
        
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, "Carburant : " + achat.Carburant +
                                        " Quantité : " + achat.Quantite + " L " +
                                        " Prix : " + achat.Prix + " €" +
                                        " Jour : " + achat.Jour +
                                        " Total : " + achat.Total);
    }

    [TestMethod]
    public void SauvegarderAchatsBdd_DoitEnregistrerUnAchatEnBaseDeDonnees()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
   
        Achats achat = new Achats(NomCarburant.Sp95,30,2,DayOfWeek.Thursday,80);
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        station.AjouterUnAchat(achat);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, " Achat enregistrée en base !");
    }
    
    [TestMethod]
    public void SauvegarderVenteBdd_DoitEnregistrerUneVenteEnBaseDeDonnees()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        Vente vente = new Vente(2, NomCarburant.Lpg,50, DayOfWeek.Friday);
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        station.AjouterUneVente(vente);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, " Vente enregistrée en base !");
    }

    [TestMethod]
    public void RechercheBonneCarburant_DoitRetournerLaCuveCorrespondante()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        TypeEssence typeEssence2 = new TypeEssence(NomCarburant.Sp95, 3);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Cuve cuve2 = new Cuve(1,typeEssence2,2000,7500,150,25);
        
        station.AjouterCuve(cuve);
        station.AjouterCuve(cuve2);
        
        station.RechercheBonneCarburant(typeEssence.Type);
        Assert.AreEqual(cuve2, station.RechercheBonneCarburant(NomCarburant.Sp95));
    }



    [TestMethod]
    public void PrixAchatCarburant_DoitRetournerLeBonPrixSelonLeTypeDeCarburant()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
       
        station.PrixAchatCarburant(NomCarburant.Sp95);
        
        Assert.AreEqual(2,station.PrixAchatCarburant(NomCarburant.Sp95));
    }

    [TestMethod]
    public void ControlerNiveauCuves_DoitCommanderUnReapprovisionnementQuandLeNiveauEstInferieurOuEgalAuMinimum()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,500,1000,500,25);
        
        station.AjouterCuve(cuve);
        
        station.ControlerNiveauCuves();
        
        Assert.AreEqual(1,station.Achats.Count);
        
    }

    [TestMethod]
    public void ControlerNiveauCuves_Doit_Pas_CommanderUnReapprovisionnementQuandLeNiveauSuperieur_InferieurOuEgalAuMinimum()
    {
        StationService station = new StationService("MyStation", "rue des Alliés",new TimeSpan(5,0,0),new TimeSpan(18,0,0));
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,600,1000,500,25);
        
        station.AjouterCuve(cuve);
        
        station.ControlerNiveauCuves();
        
        Assert.AreEqual(0,station.Achats.Count);
    }
    


    


}