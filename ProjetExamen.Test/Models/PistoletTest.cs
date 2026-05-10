using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Pistolet))]
public class PistoletTest
{

    [TestMethod]
    public void VerifierConstructor()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,500,1000,250,125);
        Pistolet pistolet = new Pistolet(1,cuve);
        
        
        
        Assert.IsTrue(pistolet.Disponible);
        Assert.IsFalse(pistolet.Enpanne);
        Assert.IsNotNull(pistolet);
       
        
    }

    [TestMethod]
    public void StatPistoleDisponible()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,300,500,250,125);
        Pistolet pistolet = new Pistolet(1,cuve);

        pistolet.Reparer();

        pistolet.Status();
        Assert.AreEqual("Le pistolet est disponible",pistolet.Status());
        Assert.IsTrue(pistolet.Disponible);
    }
    [TestMethod]
    public void StatPistoleEnpanne()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,500,770,330,205);
        Pistolet pistolet = new Pistolet(1,cuve);

        pistolet.Reparer();
        pistolet.MettreEnPanne();

        pistolet.Status();
        Assert.AreEqual("Le pistolet est en panne",pistolet.Status());
        Assert.IsTrue(pistolet.Enpanne);
    }

    [TestMethod]
    public void EtatPistolePasDisponible()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp98, 2.4);
        Cuve cuve = new Cuve(1,typeEssence,400,800,350,225);
        Pistolet pistolet = new Pistolet(1,cuve);
        
        pistolet.Occuper();
        pistolet.Status();
        
        Assert.AreEqual("Le pistolet est déjà utilisé",pistolet.Status());
        
        
    }

    [TestMethod]
    public void Distribue_PistoletEnPanne_RetourneNull()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Pistolet pistolet = new Pistolet(1,cuve);
        
        pistolet.MettreEnPanne();

        pistolet.Distribue(10);
        
        Assert.AreEqual(null, pistolet.Distribue(10));
        
        
    }
    
    [TestMethod]
    public void Distribue_PistoletEnPanne_AfficheMessage()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Lpg, 4);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Pistolet pistolet = new Pistolet(1,cuve);
        
        pistolet.MettreEnPanne();
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        pistolet.Distribue(20);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat,"Le pistolet est en panne, pas de distribution");

    }

    [TestMethod]
    public void Distribue_PistoletOccupe_RetourneNull()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 3);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Pistolet pistolet = new Pistolet(1,cuve);
        
        pistolet.Occuper();

        pistolet.Distribue(10);
        
        Assert.AreEqual(null, pistolet.Distribue(10));   
    }

    [TestMethod]
    public void Distribue_PistoletDisponible_RetournePrix()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95, 2);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Pistolet pistolet = new Pistolet(1,cuve);
        
       
        pistolet.Distribue(50);
        
        Assert.AreEqual(100, pistolet.Distribue(50)); 
    }
    
    [TestMethod]
    public void MettreEnPanne_ChangerStat_du_Pistolet()
    {
        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp95, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 100, 20, 5, 0);
        Pistolet pistolet = new Pistolet(1, cuve);
        
        pistolet.MettreEnPanne();
        Assert.IsTrue(pistolet.Enpanne);
        
    }

    [TestMethod]
    public void Repare_ChangerEtat_du_Pistole()
    {
        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp95, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 1000, 2000, 500, 250);
        Pistolet pistolet = new Pistolet(1, cuve);
        pistolet.MettreEnPanne();
        pistolet.Reparer();
        Assert.IsFalse(pistolet.Enpanne);
    }

    [TestMethod]
    public void Occuper_Pistolet_DevientIndisponible()
    {
        
        TypeEssence carbutant = new TypeEssence(NomCarburant.Sp95, 2.56);
        Cuve cuve = new Cuve(1, carbutant, 1000, 2000, 500, 250);
        Pistolet pistolet = new Pistolet(1, cuve);
        
        pistolet.Occuper();
        
        Assert.IsFalse(pistolet.Disponible);
        Assert.IsFalse(pistolet.Enpanne);
        
    }
    
    
    [TestMethod]
    public void Occuper_PistoletEnPanne_ResteDisponible()
    {
        
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Diesel, 4);
        Cuve cuve = new Cuve(1,typeEssence,200,100,50,25);
        Pistolet pistolet = new Pistolet(1,cuve);
        
        pistolet.MettreEnPanne();
        pistolet.Occuper();
        
        Assert.IsTrue(pistolet.Disponible);
        Assert.IsTrue(pistolet.Enpanne);
        
    }
}