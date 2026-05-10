using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetExamen.Models;

namespace ProjetExamen.Test.Models;

[TestClass]
[TestSubject(typeof(Vehicule))]
public class VehiculeTest
{

    [TestMethod]
    public void VehiculeConstructor()
    {
        Client client = new Client("Bob", "Sad");
        Vehicule v = new Vehicule("jaune", "BMW", client, CategoryVéhicules.Moto);
        
        Assert.IsNotNull(v);
        Assert.AreEqual("jaune",v.Couleur);
        Assert.AreEqual("BMW",v.Marque);
        Assert.AreEqual(CategoryVéhicules.Moto, v.Category);
        Assert.AreEqual(client,v.Client);
        
    }
}