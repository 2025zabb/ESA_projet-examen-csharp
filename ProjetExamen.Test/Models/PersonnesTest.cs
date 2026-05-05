using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Personnes))]
public class PersonnesTest
{

    [TestMethod]
    public void verifier_le_constructeur_Personnes()
    {
        string nom = "Lefevre";
        string prenom = "Boris";
        
        Personnes p = new Personnes(nom, prenom);
        Assert.AreEqual("Lefevre", p.Nom);
        Assert.AreEqual("Boris", p.Prenom);
    }

    [TestMethod]
    public void AfficherInfos_des_Personnes()
    {
        Personnes p = new Personnes("Lefevre", "Boris");
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        
        p.AfficherInfos();
        
        string resultat = sw.ToString();
        StringAssert.Contains(resultat, "Lefevre");
        StringAssert.Contains(resultat, "Boris");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
}