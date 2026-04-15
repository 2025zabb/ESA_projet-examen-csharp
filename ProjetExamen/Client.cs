namespace ProjetExamen;

public class Client:Personnes
{
    public Client(string nom, string prenom) : base(nom, prenom)
    {
    }

    public void EffectuerLePaiement(double montant)
    {
        Console.WriteLine("Mr,Mme " + Nom + " " + Prenom + " a payer " + montant + "€");
    }
    
}

