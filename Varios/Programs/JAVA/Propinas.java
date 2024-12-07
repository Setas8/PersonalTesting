import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Propinas {

    public static void main(String[] args) {

        Scanner scn = new Scanner(System.in);
        Map<String, Double> mapaPropinas = new HashMap<>();
        boolean continuar = true;

        while (continuar) {
            System.out.println("\nIntroduce la cantidad total de propina a repartir: ");
            double propinaTotal = scn.nextDouble();
            scn.nextLine(); // Limpiar el buffer

            if (propinaTotal <= 0) {
                System.out.println("La cantidad de propinas debe ser mayor que 0.");
                continue;
            }

            System.out.println("Introduce el número de empleados: ");
            int numEmpleados = scn.nextInt();
            scn.nextLine(); // Limpiar el buffer

            if (numEmpleados <= 0) {
                System.out.println("El número de empleados debe ser mayor que cero.");
                continue;
            }

            double propinaPorEmpleado = Math.floor(propinaTotal / numEmpleados * 100) / 100.0; 
            double resto = propinaTotal - (propinaPorEmpleado * numEmpleados); 

            for (int i = 0; i < numEmpleados; i++) {
                System.out.println("Introduce el nombre del empleado " + (i + 1) + ": ");
                String nombre = scn.nextLine();

                mapaPropinas.put(nombre, mapaPropinas.getOrDefault(nombre, 0.0) + propinaPorEmpleado);
            }

            for (String nombre : mapaPropinas.keySet()) {
                if (resto <= 0) break;
                mapaPropinas.put(nombre, mapaPropinas.get(nombre) + 0.01);
                resto -= 0.01;
            }

            System.out.println("\nDistribución actual de propinas:");
            for (Map.Entry<String, Double> entry : mapaPropinas.entrySet()) {
                System.out.printf("%s: %.2f euros%n", entry.getKey(), entry.getValue());
            }
           
            System.out.println("\n¿Quieres repartir más propinas? (s/n): ");
            String respuesta = scn.nextLine().trim().toLowerCase();
            if (!respuesta.equals("s")) {
                continuar = false;
            }
        }

        System.out.println("\nDistribución final de propinas:");
        for (Map.Entry<String, Double> entry : mapaPropinas.entrySet()) {
            System.out.printf("%s: %.2f euros%n", entry.getKey(), entry.getValue());
        }

        scn.close();
    }
}


