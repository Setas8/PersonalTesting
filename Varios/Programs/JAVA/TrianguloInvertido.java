/*
    * 
   ** 
  *** 
 **** 
*****
 */
import java.util.Scanner;

public class TrianguloInvertido {

    public static void main(String[] args) {
        
        Scanner tcd = new Scanner(System.in);
        
        System.out.print("Introduzca un numero: ");
        int limite = tcd.nextInt(); tcd.nextLine();
        
        for(int i = 1; i <= limite; i++){
            String linea = "";            
            for(int j = 0; j < limite -i; j++){
                linea += " ";
            }
            for(int k = 0; k < i; k++){
                linea += "*";
            }
            System.out.println(linea + " ");
        }
        tcd.close();
    }
}
