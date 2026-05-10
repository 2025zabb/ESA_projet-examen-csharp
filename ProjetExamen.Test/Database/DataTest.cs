using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using ProjetExamen.Database;

namespace ProjetExamen.Test.Database;

[TestClass]
[TestSubject(typeof(Data))]
public class DataTest
{

    [TestMethod]
    public void GetNonNullConnectio()
    {
     Data d = new Data();
     
     var connection = d.GetConnection();
     Assert.AreNotEqual(null, connection);
     Assert.IsExactInstanceOfType(connection, typeof(NpgsqlConnection));
    }
    
    [TestMethod]
    public void GetConnection_TestLesBonParametres(){
     Data d = new Data();
     var connection = d.GetConnection();
     
     StringAssert.Contains(connection.Database, "projetexam");
     StringAssert.Contains(connection.UserName, "postgres");
     StringAssert.Contains(connection.ConnectionString,"Password=zabb_&§");
    }
}