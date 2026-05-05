using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
public class ClientTest
{
    [TestMethod]
    public void Verifier_Constructeur_Client()
    {
        
        Client client = new Client("Nzabi Mwange", "Christian");

        
        Assert.AreEqual("Nzabi Mwange", client.Nom);
        Assert.AreEqual("Christian", client.Prenom);
    }

    [TestMethod] 
    public void EffectuerLePaiement_DoitAfficherMessageCorrect()
    {
        
        Client client = new Client("pet", "parrot");
        double montant = 150;

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        // 
        client.EffectuerLePaiement(montant);

        // 
        string resultat = sw.ToString();

        StringAssert.Contains(resultat, "pet");
        StringAssert.Contains(resultat, "parrot");
        StringAssert.Contains(resultat, "150");
    }

    [TestMethod] 
    public void ChoixTypeEssenceDoitAfficherMessageCorrect()
    {
        Client client = new Client("lor", "Calm");
        var carburant = NomCarburant.Diesel;
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        client.ChoixTypeEssence(carburant);
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, NomCarburant.Diesel.ToString());
        StringAssert.Contains(resultat, "lor");
        StringAssert.Contains(resultat, "Calm");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
}