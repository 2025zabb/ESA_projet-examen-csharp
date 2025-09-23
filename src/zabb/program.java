package zabb;

import java.util.Scanner;

public class program {

    public static void main(String[] args) {
        System.out.println("tu veux te presenter(o/n) : ");
        Scanner input = new Scanner(System.in);
        String o = input.nextLine();
        if(o.equals("o")){
            presentation();
        }

    }
    public static void presentation(){
        Scanner input = new Scanner(System.in);
        System.out.println("Please enter votre nom : ");
        String nom = input.nextLine();
        System.out.println("Please enter votre prenom : ");
        String prenom = input.nextLine();

        if(!nom.equals(prenom)){
            System.out.println("bonjour, je m'appelle " + nom + " " + prenom);
        }else {
            System.out.println(" votre nom : " + nom + " " + prenom +"sont identique");
        }

        }
}
