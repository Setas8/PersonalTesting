import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.ArrayList;

public class amigo_invisible {

    public static void main(String[] args) {

        Scanner scn = new Scanner(System.in);

        System.out.println("Number of participants: ");
        int participantsNum = scn.nextInt();scn.nextLine();

        ArrayList<String> participants = new ArrayList<>();

        for (int i = 0; i < participantsNum; i++) {
            System.out.println("Name participant " + (i+1) + ":");
            participants.add(scn.nextLine());
        }

        Collections.shuffle(participants);

        Map<String,String> secretSantas = new HashMap<>();

        for (int i = 0; i < participantsNum; i++) {
            String secretSanta = participants.get((i+1) % participantsNum);
            secretSantas.put(participants.get(i), secretSanta);
        }

        System.out.println("SECRET SANTA RESULT");
        for (Map.Entry<String, String> ss : secretSantas.entrySet()) {
            System.out.println(ss.getKey() + "-->" + ss.getValue());
        }

        scn.close();
    }
}