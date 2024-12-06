import java.util.Scanner;

public class NocheVieja {
    
    public static void main(String[] args) {
        Scanner tcd = new Scanner(System.in);
        
        System.out.println("¿Cuántos casos de prueba quieres hacer?");
        byte numPrueba = tcd.nextByte(); tcd.nextLine();
                
        for (int i = 1; i <= numPrueba; i++) {
            
            System.out.print("Prueba " + (i) + "-> Dime la hora (xx:xx): ");
            String horaCompleta    = tcd.nextLine();
            String horaSinEspacios = horaCompleta.trim();
            
            int hora    = Integer.parseInt(horaSinEspacios.substring(0, 2));
            int minutos = Integer.parseInt(horaSinEspacios.substring(3));

            int minutosLeft = (60 - minutos);
            int horasLeft   = (23 - hora);
            int resultado   = minutosLeft + (horasLeft * 60);

            if (resultado != 1440) {
                System.out.println(horaSinEspacios);
                System.out.println(resultado);
            }
        }       
        tcd.close();
    }
}

