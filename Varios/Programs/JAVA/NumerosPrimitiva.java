import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class NumerosPrimitiva {
    
    static Scanner tcd          = new Scanner(System.in);
    static Random aleatorio     = new Random(1);
    //static int[] primitiva      = new int[6];
    static int opcion           = Integer.MIN_VALUE;
    static int numParticipantes = Integer.MIN_VALUE;
    
    public static void main(String[] args) {
         
                     
        opciones();           
    }   
    public static void menu() {
        
        System.out.println("\nMENÚ\n1-Primitiva para copiones"
                             + "\n2-Salir");
        opcion = tcd.nextInt();tcd.nextLine();
    }
    public static void opciones(){
        menu();
        switch(opcion) {
            case 1:
                System.out.println("¿Número de participantes?");
                numParticipantes = tcd.nextInt();tcd.nextLine();
                primiParaCopiones(numParticipantes);
                opciones();
                break;
            case 2:
                System.out.println("¡Hasta pronto!");
                break;
            default:
                System.out.println("No eligió correctamente");
                opciones();
        }           
    }
    public static void primiParaCopiones(int participantes){
        
        for (int x = 0; x < participantes; x++) {
            //calcularCombinacionGanadora();           
            //comprobarApuestaRepetida();
            System.out.println("\nParticipante " + (x+1)); 
            System.out.println("---------------");
            imprimirArrayOrdenado(calcularCombinacionGanadora());          
        } 
    }
    public static void imprimirArrayOrdenado (int[] array) {
        Arrays.sort(array);     
        for (int i = 0; i <= array.length-1; i++)  {
            System.out.println(array[i]);
        }
    }  
    public static int[] calcularCombinacionGanadora(){
        int[] primitiva = new int[6];
        //Inicializando el array
        for (int i = 0; i < 6; i++) {
            primitiva[i] = -1;
        }
        //Rellenando el array
        for (int i = 0; i < 6; i++) {
            int num = (int) (Math.random() * 49 + 1);
            //int num = aleatorio.nextInt(49) + 1;
            num = aleatorio.nextInt(49) + 1;
            while (!comprobarApuestaRepetida(num, primitiva)) {
                num = (int) (Math.random() * 49 + 1);
                //num = aleatorio.nextInt(49) + 1;
            }
            primitiva[i] = num;
        }       
        return primitiva;
    }
    public static boolean comprobarApuestaRepetida(int num, int[] apuestas) {
               
        for(int i = 0; i < apuestas.length; i++){
            if(num == apuestas[i]){
                return false;
            }
        }
        return true;
    }
    public static void quicksort (int lista1[], int izq, int der){
        int i=izq;
        int j=der;
        int pivote=lista1[(i+j)/2];
        do {
            while (lista1[i]<pivote){
                i++;
            }
            while (lista1[j]>pivote){
                j--;
            }
            if (i<=j){
                int aux=lista1[i];
                lista1[i]=lista1[j];
                lista1[j]=aux;
                i++;
                j--;
            }
        }while(i<=j);
        if (izq<j){
            quicksort(lista1, izq, j);
        }
        if (i<der){
            quicksort(lista1, i, der);
        }
    }
    public static void quicksortP (String lista1[], int izq, int der){
        int i=izq;
        int j=der;
        int pivote=(i+j)/2;
        do {
            while (lista1[i].compareToIgnoreCase(lista1[pivote])<0){
                i++;
            }
            while (lista1[j].compareToIgnoreCase(lista1[pivote])>0){
                j--;
            }
            if (i<=j){
                String aux=lista1[i];
                lista1[i]=lista1[j];
                lista1[j]=aux;
                i++;
                j--;
            }
        }while(i<=j);
        if (izq<j){
            quicksortP(lista1, izq, j);
        }
        if (i<der){
            quicksortP(lista1, i, der);
        }
    }
}

/*
    for(int i = 0; i < primitiva.length-1; i++){
        for(int j = i+1; j < primitiva.length; j++){
            if(primitiva[i] > primitiva[j]){
                //Intercambiamos valores
                int auxiliar = primitiva[i];
                primitiva[i] = primitiva[j];
                primitiva[j] = auxiliar;
            }
        }
    }    

    System.out.println("***************************");
    for (int i = 0; i <= primitiva.length-1; i++)  {
        System.out.println(primitiva[i]);
    }

    quicksort (primitiva, 2,3);
    System.out.println("******************");
    for (int i = 0; i <= primitiva.length-1; i++)  {
        System.out.println(primitiva[i]);
    }
*/
