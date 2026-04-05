namespace ProjetExamen;

public class Client
{
    public string Nom { set;get;}
    
    public Client(string nom)
    {
        Nom = nom;
    }

    public void EffectuerLePaiement(double montant)
    {
        Console.WriteLine("Mr,Mme " + Nom + " a payer " + montant + "€");
    }
    
}

