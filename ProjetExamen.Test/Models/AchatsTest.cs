using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Achats))]
public class AchatsTest
{

    [TestMethod]
    public void verifier_le_constructeur_Achats()
    {
        NomCarburant Carburant = NomCarburant.Diesel;
        double Quantite = 1000;
         double Prix = 2.2;
        DayOfWeek Jour = DayOfWeek.Monday;
        double Total = 2200;
        
        Achats achat = new Achats(NomCarburant.Diesel,Quantite,Prix,Jour,Total);
        
        Assert.AreEqual(NomCarburant.Diesel, achat.Carburant);
        Assert.AreEqual(1000,achat.Quantite);
        Assert.AreEqual(2.2,achat.Prix);
        Assert.AreEqual(DayOfWeek.Monday,achat.Jour);
        Assert.AreEqual(2200,achat.Total);
    }
}