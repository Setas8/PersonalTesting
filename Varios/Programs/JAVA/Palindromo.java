public class Palindromo {

    public static void main(String[] args) {
        String palabra = "diego"; 
        System.out.println(palabra.charAt(0));
        System.out.println(palabra.charAt(palabra.length()-1));
        System.out.println(esPalindromo(palabra));
        
    }
    static boolean esPalindromo(String palabra) {

        boolean ok = false;
        int caracteresPalabra = palabra.length();
        while(!ok) {
            for (int i = 0; i == caracteresPalabra; i++) {
                caracteresPalabra--;
                if (i != caracteresPalabra) {
                    if (Character.compare(palabra.charAt(i), palabra.charAt(caracteresPalabra)) == 0)                  
                        ok = true;                                    
                    else
                        ok = false;
                }           
            }
        }           
        return ok;
    }
    
}
