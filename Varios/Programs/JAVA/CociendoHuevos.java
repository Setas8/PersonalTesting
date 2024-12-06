import java.util.Scanner;

public class CociendoHuevos {
    //368 aceptaelreto
    public static void main(String[] args) {
        
        Scanner tcd = new Scanner(System.in);
        short huevos;
        short capacidad;
        do {
            System.out.println("\n¿Cuántos huevos quieres cocer? ");
            huevos    = tcd.nextShort(); tcd.nextLine();
            System.out.println("¿Cuántos huevos caben? ");
            capacidad = tcd.nextShort(); tcd.nextLine();
            
            if (huevos == 0 || capacidad == 0) break;

            double cacer = (double)huevos / capacidad;
            short tiempo = (short) Math.ceil(cacer);
            
            System.out.print(huevos + " " + capacidad + " " + (tiempo * 10));
        } while (huevos != 0);      
        tcd.close();
    }   
}
