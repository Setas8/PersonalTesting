import java.util.Arrays;
import java.util.Scanner;
import java.util.Random;

public class NumerosPrimitiva {
    static Scanner tcd = new Scanner(System.in);
    static Random aleatorio = new Random();

    public static void main(String[] args) {
        mostrarMenu();
    }

    public static void mostrarMenu() {
        int opcion;
        do {
            System.out.println("\nMENÚ");
            System.out.println("1 - Generar combinaciones de la Primitiva");
            System.out.println("2 - Salir");
            System.out.print("Seleccione una opción: ");
            opcion = tcd.nextInt();

            switch (opcion) {
                case 1 -> generarCombinaciones();
                case 2 -> System.out.println("¡Hasta pronto!");
                default -> System.out.println("Opción no válida. Inténtelo de nuevo.");
            }
        } while (opcion != 2);
    }

    public static void generarCombinaciones() {
        System.out.print("Número de participantes: ");
        int participantes = tcd.nextInt();

        for (int i = 1; i <= participantes; i++) {
            int[] combinacion = calcularCombinacionGanadora();
            System.out.println("\nParticipante " + i);
            System.out.println("Combinación: " + Arrays.toString(combinacion));
        }
    }

    public static int[] calcularCombinacionGanadora() {
        int[] primitiva = new int[6];
        int index = 0;

        while (index < 6) {
            int num = aleatorio.nextInt(49) + 1; // Genera un número entre 1 y 49
            if (!estaRepetido(num, primitiva)) {
                primitiva[index++] = num;
            }
        }
        Arrays.sort(primitiva); // Ordenar antes de devolver
        return primitiva;
    }

    public static boolean estaRepetido(int num, int[] primitiva) {
        for (int n : primitiva) {
            if (n == num) return true;
        }
        return false;
    }
}