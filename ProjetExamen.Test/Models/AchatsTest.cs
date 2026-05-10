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
        NomCarburant carburant = NomCarburant.Diesel;
        double quantite = 1000;
         double prix = 2.2;
        DayOfWeek jour = DayOfWeek.Monday;
        double total = 2200;
        
        Achats achat = new Achats(carburant,quantite,prix,jour,total);
        
        Assert.AreEqual(NomCarburant.Diesel, achat.Carburant);
        Assert.AreEqual(1000,achat.Quantite);
        Assert.AreEqual(2.2,achat.Prix);
        Assert.AreEqual(DayOfWeek.Monday,achat.Jour);
        Assert.AreEqual(2200,achat.Total);
    }
}