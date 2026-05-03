using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Vente))]
public class VenteTest
{

    [TestMethod]
    public void verifie_le_Constructeur_Vente()
    {
       double Prix = 150;
       NomCarburant Essence = NomCarburant.Sp95;
       double Quantite = 75;
       DayOfWeek Jour = DayOfWeek.Friday;
       
       Vente vente = new Vente(Prix, Essence,Quantite,Jour);
       
       Assert.AreEqual(150, vente.Prix);
       Assert.AreEqual(NomCarburant.Sp95, vente.Essence);
       Assert.AreEqual(75, vente.Quantite);
       Assert.AreEqual(Jour, vente.Jour);
        
    }
}