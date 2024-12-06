/*
    *     
   ***    
  *****   
 *******  
********* 
*/
import java.util.Scanner;

public class Piramide {

    public static void main(String[] args) {
        
        Scanner tcd = new Scanner(System.in);
        
        System.out.print("Introduzca un numero: ");
        int limite = tcd.nextInt(); tcd.nextLine();
        
        for(int i = 1; i <= limite; i++){
            String linea = "";            
            for(int j = 1; j <= limite -i; j++){
                linea += " ";
            }
            for(int k =1; k <= (i*2)-1; k++){
                linea += "*";
            }
            System.out.println(linea + " ");
        }
        tcd.close();
    }
}
