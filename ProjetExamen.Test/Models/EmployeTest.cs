using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Employe))]
public class EmployeTest
{

    [TestMethod]
    public void Verifier_Constructeur_Employee()
    {
        string nom = "John Doe";
        string prenom = "Doe";

        Employe employe = new Employe(nom, prenom,1,"cassier");

        Assert.AreEqual("John Doe", employe.Nom);
        Assert.AreEqual("Doe", employe.Prenom);
       
    }

    [TestMethod]
    public void VerifierAfficherInfosPersonnelles()
    {
        Employe employe = new Employe("John Doe", "Doe", 1, "cassier");
        
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        employe.AfficherInfosPersonnelles();
        string resultat = sw.ToString();

        StringAssert.Contains(resultat, "John Doe");
        StringAssert.Contains(resultat, "Doe");
        StringAssert.Contains(resultat, "cassier");
        StringAssert.Contains(resultat, "1");
        
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
    
}