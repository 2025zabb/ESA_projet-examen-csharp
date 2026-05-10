using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Cuve))]
public class CuveTest
{

    [TestMethod]
    public void Constructeur_InitialiseCorrectement()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 200, 900, 600, 250);

        Assert.AreEqual(NomCarburant.Sp95, cuve.Carburant.Type);
        Assert.AreEqual(1, cuve.NumeeroCuve);
        Assert.AreEqual(200, cuve.GetcapaciteActuelle());
        Assert.AreEqual(900, cuve.CapaciteMax);
        Assert.AreEqual(600, cuve.CapaciteMin);
        Assert.AreEqual(250, cuve.Seuilcapacite);
    }


    [TestMethod]
    public void Constructeur_SansCapaciteActuelleCuveCorrectement()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 900, 600, 250);

        Assert.AreEqual(NomCarburant.Sp95, cuve.Carburant.Type);
        Assert.AreEqual(1, cuve.NumeeroCuve);
        Assert.AreEqual(0, cuve.GetcapaciteActuelle());
        Assert.AreEqual(900, cuve.CapaciteMax);
        Assert.AreEqual(600, cuve.CapaciteMin);
        Assert.AreEqual(250, cuve.Seuilcapacite);
    }

    [TestMethod]
    public void EstVide_DoitRetournerVraiQuandLeConteneurEstVide()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 900, 600, 250);

        cuve.GetcapaciteActuelle();
        Assert.AreEqual(0, cuve.GetcapaciteActuelle());
        Assert.IsTrue(cuve.EstVide());
    }

    [TestMethod]
    public void EstPleine_DoitRetournerVraiQuandLeConteneurEstPlein()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 900, 900, 600, 250);

        cuve.EstPleine();
        Assert.IsTrue(cuve.EstPleine());
    }

    [TestMethod]
    public void EstPleine_DoitRetournerFaux_QuandLeConteneurEstPlein()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 900, 600, 250);

        cuve.EstPleine();
        Assert.IsFalse(cuve.EstPleine());
    }

    [TestMethod]
    public void CommanderEssence_DoitRéussirQuandLeStockEstPasSuffisant()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 900, 600, 250);

        cuve.CommanderEssence();
        Assert.IsTrue(cuve.CommanderEssence());
    }

    [TestMethod]
    public void CommanderEssence_DoitEchouerQuandLeStockEstDisponible()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 700, 900, 100, 250);

        cuve.CommanderEssence();
        Assert.IsFalse(cuve.CommanderEssence());
    }

    [TestMethod]
    public void DonnerEssence_DoitRetournerVraiQuandLeCarburantEstDisponible()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 700, 900, 100, 250);
        cuve.DonnerEssence();
        Assert.IsTrue(cuve.DonnerEssence());
    }

    [TestMethod]
    public void DonnerEssence_DoitRetourner_Faux_QuandLes_ConditionPas_Remplit()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 900, 100, 250);
        cuve.DemarrerRemplissage();
        cuve.SignalerProlemeDeDistribution();
        cuve.DonnerEssence();
        Assert.IsFalse(cuve.DonnerEssence());
    }

    [TestMethod]
    public void Remplir_DoitAugmenterLaQuantiteDeCarburantEtAtteindre()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 120, 50, 40);

        cuve.Remplir(30);
        Assert.AreEqual(120, cuve.GetcapaciteActuelle());
    }

    [TestMethod]
    public void Remplir_SansDepasserLeMax_AugmenteCorrectement()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 250, 50, 40);
        cuve.Remplir(30);
        Assert.AreEqual(130, cuve.GetcapaciteActuelle());
    }

    [TestMethod]
    public void CommanderEtRemplirCuve_DoitCommanderPuisRemplir()
    {

        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 250, 150, 40);
        double quantite = 50;


        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        cuve.CommanderEtRemplirCuve(quantite);

        string resultat = sw.ToString();

        StringAssert.Contains(resultat, "cuve 1 en remplissage");
        StringAssert.Contains(resultat, "la cuve 1 a été remplit de 50 L");
        StringAssert.Contains(resultat, "cuve 1 peut etre utilise maintenat");
        Assert.AreEqual(150, cuve.GetcapaciteActuelle());

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });


    }

    [TestMethod]
    public void DistriEssence_DoitRetournerNullQuandLaDistributionEstImpossible()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 200);
        double quantite = 150;
        
        cuve.SignalerProlemeDeDistribution();
        cuve.DemarrerRemplissage();
        cuve.DistriEssence(quantite);
        
        Assert.AreEqual(null, cuve.DistriEssence(quantite));
    }
    
    [TestMethod]
    public void DistriEssence_Doit_AfficheMessage()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 200);
        double quantite = 30;
        
        cuve.SignalerProlemeDeDistribution();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.DistriEssence(quantite);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat," La cuve ne peut pas distribuer du car probleme de distribution ");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

    }
    [TestMethod]
    public void DistriEssence_Doitretourne_AfficheMessage()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 200);
        double quantite = 30;
        
        cuve.DemarrerRemplissage();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.DistriEssence(quantite);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"la cuve ne peut pas distribuer du carburant car , elle est en remplissage ");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }
    
    [TestMethod]
    public void DistriEssence_Doit_retourne_AfficheMessage()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 200);
        double quantite = 30;
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.DistriEssence(quantite);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat," arrêt de distribution ,niveau de carburant trop bas ");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }
    
    [TestMethod]
    public void DistriEssence_AfficheMessage()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 4);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 50);
        double quantite = 200;
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.DistriEssence(quantite);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat," pas assez d'essence dans la cuve ");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }

    [TestMethod]
    public void DistriEssence_RetournePrix()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 50);
        double quantite = 20;
        
        cuve.DistriEssence(quantite);
        Assert.AreEqual(40,cuve.DistriEssence(quantite));
        
    }

    [TestMethod]
    public void DemarrerRemplissage_DoitActiverLeRemplissageEssenc()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 50);
        double quantite = 20;
        
        cuve.DemarrerRemplissage();
        cuve.DistriEssence(quantite);
        
        Assert.IsTrue(cuve.RemplissageEssenc);
    }

    [TestMethod]
    public void DemarrerRemplissage_Stop_LeRemplissage()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 100, 200, 51, 30);
        double quantite = 20;
        cuve.DemarrerRemplissage();
        cuve.ArreterRemplissage();
        cuve.DistriEssence(quantite);
        Assert.IsFalse(cuve.RemplissageEssenc);
    }

    [TestMethod]
    public void SignalerProblemeDeDistribution_DoitMettreProblemeDistributionATrue()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 1000, 2500, 801, 500);
        double quantite = 40;
        cuve.SignalerProlemeDeDistribution();
        cuve.DistriEssence(quantite);
        Assert.IsTrue(cuve.ProblemeDistribution);
    }

    [TestMethod]
    public void ResoudreProblemeDistribution_DoitMettreProblemeDistributionAFalse()
    {
        
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 150, 250, 75, 25);
        double quantite = 20;
        cuve.SignalerProlemeDeDistribution();
        cuve.ResoudreProblemeDistribution();
        cuve.DistriEssence(quantite);
        Assert.IsFalse(cuve.ProblemeDistribution);
    }

    [TestMethod]
    public void GetCapaciteActuelle_DoitRetournerLaCapaciteActuelle()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 100, 2500, 101, 50);
        double quantite = 20;
        cuve.GetcapaciteActuelle();
        
        Assert.AreEqual(100, cuve.GetcapaciteActuelle());
        
    }

    [TestMethod]
    public void RemplirCuveSiVide_DoitRemplirLaCuveQuandElleEstVide()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 2500, 101, 50);
        double quantite = 100;

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.RemplirCuveSiVide(quantite);
        string resultat = sw.ToString();
        
        Assert.IsTrue(cuve.GetcapaciteActuelle()>0);
        Assert.AreEqual(quantite, cuve.GetcapaciteActuelle());
        StringAssert.Contains(resultat, " La cuve a été remplit de " + quantite + " Litres");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }
    
    [TestMethod]
    public void RemplirCuveSiVide_DoitRemplirLaCuvesSiPasPleine()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence,75,  2500, 101, 50);
        double quantite = 25;
        
        cuve.CommanderEtRemplirCuve(quantite);
        
        Assert.AreEqual(100, cuve.GetcapaciteActuelle());
        
    }

    
    [TestMethod]
    public void EtatDeLaCuve_SiPleine_AffichePleine()
    {
        
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence,200, 200, 101, 50);
        
        double quantite = 100;
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.EtatDeLaCuve();
        
        string resultat = sw.ToString();

        StringAssert.Contains(resultat, "la  cuve 1 posséde du carburant ");
     
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
    [TestMethod]
    
    public void EtatDeLaCuve_SiVide_AfficheVide()
    {
        
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence, 2500, 101, 50);
        
        double quantite = 100;
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.EtatDeLaCuve();
        
        string resultat = sw.ToString();
        
        ;
        StringAssert.Contains(resultat, "nouvelle cuve 1 est vide ");
     
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
    [TestMethod]
    public void EtatDeLaCuve_SiNiVideNiPleine_AfficheEnService() 
    {
        
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1, typeEssence,200, 2500, 101, 50);
        
        double quantite = 100;
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        cuve.EtatDeLaCuve();
        
        string resultat = sw.ToString();
        
       
        StringAssert.Contains(resultat, " la  cuve 1 en service ");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }


    

}