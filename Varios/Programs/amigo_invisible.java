import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.ArrayList;

public class amigo_invisible {

    public static void main(String[] args) {    

        getData();     
    }

    private static int getNumParticipants(Scanner scn) {

        System.out.println("Number of participants: ");
        int participantsNum = scn.nextInt();scn.nextLine();
        
        return participantsNum;
    }

    private static void getData() {

        Scanner scn = new Scanner(System.in);

        int participantsNum = getNumParticipants(scn);

        ArrayList<String> participantsList = new ArrayList<>();

        for (int i = 0; i < participantsNum; i++) {
            System.out.println("Name participant " + (i+1) + ":");
            participantsList.add(scn.nextLine());
        }
        Collections.shuffle(participantsList);
        scn.close();

        calculateResult(participantsList, participantsNum);
    }

    private static void calculateResult(ArrayList<String> participantsList, int participantsNum) {

        Map<String,String> secretSantas = new HashMap<>();

        for (int i = 0; i < participantsNum; i++) {
            String secretSanta = participantsList.get((i+1) % participantsNum);
            secretSantas.put(participantsList.get(i), secretSanta);
        }
        showResult(secretSantas);
    }

    private static void showResult(Map<String,String> secretMap) {

        System.out.println("SECRET SANTA RESULT");
        for (Map.Entry<String, String> ss : secretMap.entrySet()) {
            System.out.println(ss.getKey() + "-->" + ss.getValue());
        }
    }
}
