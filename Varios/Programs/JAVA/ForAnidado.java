/*
-Aa   
      
-Ba   
+BaB  
      
-Ca   
+CaB  
-CaBc 
      
-Da   
+DaB  
-DaBc 
+DaBcD

 */
import java.util.Scanner;

public class ForAnidado {
    public static void  $(String s){System.out.print(s);} 
    public static void  $(int 	 s){System.out.print(s);} 
    public static void  $(char 	 s){System.out.print(s);} 
    public static void $$(String s){System.out.println(s);} 	
    public static void $$(int    s){System.out.println(s);} 
    public static void $$(char   s){System.out.println(s);} 

    
    static Scanner 	poTcd = new Scanner(System.in); 

    public static void main(String[] args) {
        
        $("Introduce un número: ");
        int wiLimite = poTcd.nextInt(); poTcd.nextLine();
               
        for (int i = 1; i <= wiLimite; i++){           
            for (int j = 1; j <= i; j++){
                if (j%2 != 0){
                    $("-");$((char) (64 +i));  
                }else{
                    $("+");$((char) (64 +i));
                }
                for (int k = 1; k <= j; k++){
                    if (k%2==1)
                        $((char) (96 +k));
                    else
                        $((char) (64 +k));
                }$$("");                                     
            }$$("");            
        }       
    }//Main
}//Pr14
