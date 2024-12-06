import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class PedirLocalDateCorrecto {

    public static void main(String[] args) {
        Scanner tcd = new Scanner(System.in);
        
        String nombre, apellido1, apellido2, fechaNac;
        
        System.out.print("Nombre: ");
        nombre    = comprobarLongitudString(tcd.nextLine());        
        System.out.print("Primer apellido: ");
        apellido1 = comprobarLongitudString(tcd.nextLine());
        System.out.print("Segundo apellido: ");
        apellido2 = comprobarLongitudString(tcd.nextLine());          
        boolean ok = true;
            do {
                try {
                    System.out.print("Fecha nacimiento(aaaa-mm-dd): ");
                    fechaNac = tcd.nextLine();
                    stringToDate(fechaNac);
                    ok = true;
                } catch (Exception e) {
                    System.out.println("Formato de fecha no válido");
                    ok = false;
                }           
            } while (!ok);
    }
    public static String comprobarLongitudString(String s) {
        if (s.length() < 20) 
            for (int i = s.length(); i < 20; i++) {
                s += " ";
            }              
        else 
            s = s.substring(0, 20);        
        return s;
    }
    public static LocalDate stringToDate(String f) throws Exception{                  
        return LocalDate.parse(f, DateTimeFormatter.ISO_DATE);        
    }   
}
