using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(TypeEssence))]
public class TypeEssenceTest
{

    [TestMethod]
    public void Verifier_initiale_Constructeur()
    {
        NomCarburant carburant = NomCarburant.Sp95;
         double prixParLitre =  2.2;
         
         TypeEssence typeEssence = new TypeEssence(carburant,prixParLitre);
         
       
        Assert.AreEqual(2.2,typeEssence.GetPrixParLitre());
        Assert.AreEqual(carburant,typeEssence.Type);
        
    }

    [TestMethod]
    public void CalculerPrixTotal_DoitsRetournerBonResultat()
    {
        double quantiteParLitre = 20;
      TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95,2);
      
      typeEssence.CalculerPrixTotal(quantiteParLitre);

      Assert.AreEqual(40,typeEssence.CalculerPrixTotal(quantiteParLitre));


    }

    [TestMethod]
    public void GetPrixParLitre_DoitsRetournerBonPrix()
    {
        TypeEssence typeEssence = new TypeEssence(NomCarburant.Sp95,5);

        typeEssence.GetPrixParLitre();
        Assert.AreEqual(5,typeEssence.GetPrixParLitre());
    }
   
}