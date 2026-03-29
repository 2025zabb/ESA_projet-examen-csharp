namespace ProjetExamen;

class Mains
{
    static void Main(string[] args)
    {
        
        TypeEssence diesel = new TypeEssence("diesel",1.94);
        
        Cuve cuv1 = new Cuve(1,diesel,200,500,250);
        Pompe pompe = new Pompe(1);
        
        StationService station = new("Total", "Liège");
        station.AjouteCuve(cuv1);
        station.AjoutePompe(pompe);
        station.ConnectCuvePmpe(1,1);

    }
}