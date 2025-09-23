package zabb;

import java.util.Scanner;

public class program {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("tu veux te presenter(o/n) : ");
        String o = input.nextLine();

        if(o.equals("o")){
            presentation(input);
        }else  if(o.equals("n")){
            System.out.println("au revoir");
            System.exit(0);
        }else {
            System.out.println("Choix invalide !");
        }
        input.close();

    }
    public static void presentation(Scanner input){
        System.out.println("Please enter votre Nom : ");
        String nom = input.nextLine();
        System.out.println("Please enter votre Prenom : ");
        String prenom = input.nextLine();
        System.out.println("Please enter votre Hobby : ");
        String hobby = input.nextLine();



        if(!nom.equals(prenom)){
            System.out.println("bonjour, je m'appelle " + nom + " " + prenom+".");
        }else {
            System.out.println(" votre nom : " + nom + " " + prenom +"sont identique");
        }
        if (hobby.equals(" ")){
            System.out.println(" votre Hobby !?");
        }else{
            System.out.println("j'aime" +" "+ hobby+".");
        }

    }
}
