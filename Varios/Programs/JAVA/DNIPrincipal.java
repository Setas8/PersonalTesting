public class DNIPrincipal {

    public static void main(String[] args) {
        
        DNI dni1 = new DNI();
        try {
            dni1.set(46888014);
            dni1.getNIF();
            System.out.println(dni1.getNIF());
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        System.out.println("-----------------");
        DNI dni2 = new DNI();
        try {
            dni2.set(74889885);
            dni2.getNIF();
            System.out.println(dni2.getNIF());
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        
        System.out.println("-------------");
        DNI dni3 = new DNI();
        try {
            dni3.set("46888014f");
            System.out.println(dni3.getNumDNI());
            System.out.println(dni3.getNIF());
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
