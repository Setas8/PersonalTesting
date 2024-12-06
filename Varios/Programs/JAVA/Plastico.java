import java.util.Scanner;

public class Plastico {

       public static void main(String[] args) {
        /*
        Ejercicio 1
        Báscula de precisión en mano, antes de comprar nada te vas a dedicar a
        pesar el producto completo y a mirar en la etiqueta el peso neto (útil). 
        */
        Scanner tcd = new Scanner(System.in);
        System.out.print("Introduce el número de pruebas a realizar: ");
        byte numPruebas = tcd.nextByte();
        int pesoPlastic = 0;
        int pesoElegido = 99999;
        
        for (int i = 0; i < numPruebas; i++) {
            System.out.print("\nPeso neto del producto " + (i+1)+ ": ");
            int pesoNeto     = tcd.nextInt();
            System.out.print("Peso completo del producto " + (i+1)+ ": ");
            int pesoCompleto = tcd.nextInt();
            pesoPlastic = pesoCompleto - pesoNeto;
            
            System.out.println("El peso del plástico de la prueba " + (i+1) +
                                ": " + pesoPlastic + "gr.");
                       
            if (pesoPlastic < pesoElegido) 
                pesoElegido = pesoPlastic;                           
        }                      
        System.out.println("\nMe quedo con el producto con menor peso de plástico"
                            + " de " + pesoElegido + "gr.");
        tcd.close();
    }    
}
