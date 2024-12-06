import java.util.Random;
import java.util.Scanner;

public class PiedraPapelTijera {

    public static void main(String[] args) {
        
        int piedra = 1;
        int papel  = 2;
        int tijera = 3;
        
        int partidas = 5;
        String resultado = "";
        String elementoJugador  = "";
        String elementoMaquina  = "";
        int puntosJugador = 0;
        int puntosMaquina = 0;
        
        Random aleatorio = new Random();
        Scanner tcd = new Scanner(System.in);
        
        for (int i = 0; i < partidas; i++) {     
            
            int tirada;
            //controlar que se introduce 1, 2 ó 3
            do  {
                System.out.print("Piedra(1)/Papel(2)/Tijera(3): ");
                tirada = tcd.nextInt(); tcd.nextLine();
            } while (tirada < 1 || tirada > 3);
            
            //tirada de la máquina
            int num = aleatorio.nextInt(3)+1;
            //convertir números en elementos
            if (tirada == 1) 
                elementoJugador = "piedra";
            else if (tirada == 2)
                elementoJugador = "papel";
            else 
                elementoJugador = "tijera";
                
            if (num == 1)
                elementoMaquina = "piedra";
            else if (num == 2)
                elementoMaquina = "papel";
            else 
                elementoMaquina = "tijera";
            
            System.out.println("Turno " + (i+1) + ": " + "\njugador-> " +
                                elementoJugador + "\nmáquina-> " +
                                elementoMaquina);           
            //caso empate
            if (tirada == 1 && num == 1 ||
                tirada == 2 && num == 2 ||
                tirada == 3 && num == 3) {
                resultado = "Empate";
            }
            //caso gana jugador
            if (tirada == 1 && num == 3 ||
                tirada == 2 && num == 1 ||
                tirada == 3 && num == 2) {
                resultado = "Has ganado";
                puntosJugador++;
            }
            //caso gana máquina
            if (tirada == 1 && num == 2 ||
                tirada == 2 && num == 3 ||
                tirada == 3 && num == 1) {
                resultado = "Gana la máquina";
                puntosMaquina++;
            }
            System.out.println(resultado);
            System.out.println();
        }
        tcd.close();
        System.out.println(puntosJugador + " - " + puntosMaquina);
        if (puntosJugador > puntosMaquina)
            System.out.println("¡¡¡Has ganado la partida!!!");
        else if (puntosJugador < puntosMaquina)
            System.out.println("Has perdido la partida");
        else
            System.out.println("Ha habido un empate");
    }   
}
