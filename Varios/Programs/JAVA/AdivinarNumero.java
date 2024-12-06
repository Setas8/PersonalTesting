import java.util.Scanner;

public class AdivinarNumero {
    
    public static void main(String[] args) {
   
        Scanner tcd = new Scanner(System.in);
                
        int aleatorio = (int)(Math.random()*100);
        
        int num = 0;
        int numIntentos = 0;
        do{  
            numIntentos++;
            System.out.print("Encuentra un número entre el 1 y el 100: ");
            num = tcd.nextInt(); tcd.nextLine();
            
            if (num < aleatorio)
                System.out.println("El número es más alto");
            if (num > aleatorio)
                System.out.println("El número es más bajo");
                       
                      
        }while (num != aleatorio);
        System.out.println("Correcto!!! Lo has conseguido en " + numIntentos +
                           " intentos." );
        tcd.close();
    } 
}