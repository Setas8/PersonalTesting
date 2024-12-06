import java.util.Scanner;

public class DevolverCampoXCaracteres {

    
    public static void main(String[] args) {
        Scanner tcd = new Scanner(System.in);
        System.out.println("Dime palabra de 10 caracteres: ");
        String palabra = tcd.nextLine();
        System.out.println("0123456789");
        System.out.print(stringCaracteres(palabra));
        System.out.println("-");
    }
    public static String stringCaracteres(String palabra) {
        
        int tamanioCampo = 10;
        String str = "";
        int tamanioPalabra = palabra.length();
        
        if (tamanioPalabra <= tamanioCampo) {
            for (int i = tamanioPalabra;i < tamanioCampo; i++) {
                palabra += " ";
            }
            str = palabra;
        }
        else if (tamanioPalabra >= tamanioCampo) {
            str = palabra.substring(0, tamanioCampo);
        }
        else
            str = palabra;
                
        return str;
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
}