import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.ArrayList;

/**
 * Programa para asignar "Amigos Invisibles" de manera aleatoria entre un grupo de participantes.
 * 
 * @author Diego Cuadrado
 * @version 1.0
 */
public class amigo_invisible {
    /**
     * Punto de entrada principal del programa.
     */ 
       public static void main(String[] args) {    

        getData();     
    }
    /**
     * Obtiene el número de participantes mediante entrada del usuario.
     * @param scn Scanner para leer la entrada del usuario.
     * @return Número de participantes.
     */
    private static int getParticipantsNum(Scanner scn) {

        System.out.println("Number of participants: ");
        int participantsNum = scn.nextInt();scn.nextLine();
        
        return participantsNum;
    }
    /**
     * Recoge los nombres de los participantes y organiza los datos necesarios para asignar "Amigos Invisibles".
     */
    private static void getData() {

        Scanner scn = new Scanner(System.in);

        int participantsNum = getParticipantsNum(scn);

        ArrayList<String> participantsList = new ArrayList<>();

        for (int i = 0; i < participantsNum; i++) {
            System.out.println("Name participant " + (i+1) + ":");
            participantsList.add(scn.nextLine());
        }
        Collections.shuffle(participantsList);
        scn.close();

        calculateResult(participantsList, participantsNum);
    }
    /**
     * Calcula los resultados de "Amigos Invisibles" asignando un amigo a cada participante.
     * @param participantsList Lista de nombres de participantes.
     * @param participantsNum Número de participantes.
     */
    private static void calculateResult(ArrayList<String> participantsList, int participantsNum) {

        Map<String,String> secretSantas = new HashMap<>();

        for (int i = 0; i < participantsNum; i++) {
            String secretSanta = participantsList.get((i+1) % participantsNum);
            secretSantas.put(participantsList.get(i), secretSanta);
        }
        showResult(secretSantas);
    }
    /**
     * Muestra el resultado de la asignación de "Amigos Invisibles".
     * @param secretMap Mapa que contiene los emparejamientos de "Amigos Invisibles".
     */
    private static void showResult(Map<String,String> secretMap) {

        System.out.println("SECRET SANTA RESULT");
        for (Map.Entry<String, String> ss : secretMap.entrySet()) {
            System.out.println(ss.getKey() + "-->" + ss.getValue());
        }
    }
}
