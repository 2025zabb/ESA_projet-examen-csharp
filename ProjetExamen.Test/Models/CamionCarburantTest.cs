using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(CamionCarburant))]
public class CamionCarburantTest
{

    [TestMethod]
    public void Constructeur_InitialiseCorrectement()
    {
        CamionCarburant camion = new CamionCarburant(1000, 5);
        Assert.IsNotNull(camion);
        
        Assert.AreEqual(1000,camion.Quantite);
        Assert.AreEqual(5,camion.PrixParLitre);
    }

    [TestMethod]
    public void LivraisonDuCarburant_Afficher_message()
    {
       
        CamionCarburant camion = new CamionCarburant(100, 2);

        TypeEssence essence = new TypeEssence(NomCarburant.Diesel, 2);
        Cuve cuve = new Cuve(1, essence, 0, 1000, 50, 10);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

       
        camion.LivraisonDuCarburant(cuve);

      
        string resultat = sw.ToString();

        StringAssert.Contains(resultat, "Camion arrivé");
        StringAssert.Contains(resultat, "Quantité livrée : 100");
        StringAssert.Contains(resultat, "Coût total : 200");

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        
    }

    [TestMethod]
    public void LivraisonDuCarburant_Livraison()
    {
        CamionCarburant camion = new CamionCarburant(50, 4);

        TypeEssence essence = new TypeEssence(NomCarburant.Diesel, 2);
        Cuve cuve = new Cuve(1, essence, 400, 9100, 200, 100);
        
        cuve.SignalerProlemeDeDistribution();
        camion.LivraisonDuCarburant(cuve); 
        
        Assert.IsFalse(cuve.ProblemeDistribution);
    }
}