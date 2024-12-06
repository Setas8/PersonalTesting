import java.util.InputMismatchException;
import java.util.Scanner;

public class MenuOpciones {

    static Scanner tcd = new Scanner(System.in);
    static int pOpcion;
    
    public static void main(String[] args) {
        
        menu();
        tcd.close();
    }
    public static void menu() {               
        int opcion;
        boolean continua;
        do {
            try {
                continua = false;
                System.out.println("\n- - - - - - - - - - - - - - - - - - - -");
                System.out.println(""
                + "1.Opción1"
                + "\n2.Opción2"
                + "\n3.Opción3"
               + "\n0.Salir");
                opcion = tcd.nextInt(); tcd.nextLine();
                switch (opcion) {
                    case 0:
                        System.out.println("\nHasta pronto!");
                        break;
                    case 1:                                                 
                        //codigo
                        menu();
                        break;
                    case 2:                       
                        //codigo
                        menu();
                        break;
                    case 3:
                        //codigo
                        menu();
                        break;                   
                    default:      
                        System.out.println("\nOpción incorrecta");
                        menu();                                          
                }
            } catch (InputMismatchException  ime) {           
                System.out.println("\nNo has introducido un entero");
                tcd.next();
                continua = true;
            } 
        } while(continua);  
    }  
}