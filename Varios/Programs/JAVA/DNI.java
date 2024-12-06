public class DNI {

    private int numDNI;

    private static final String LETRAS_DNI = "TRWAGMYFPDXBNJZSQVHLCKE";

    public int getNumDNI() {
        return numDNI;
    }

    public String getNIF() {

        return "" + this.getNumDNI() + calcularLetraNIF(this.getNumDNI());
    }

    public void set(int dni) throws Exception {
        if (dni > 9999999 && dni < 99999999) {
            this.numDNI = dni;
        } else {
            throw new Exception("DNI inválido: " + String.valueOf(dni));
        }
    }

    public void set(String nif) throws Exception {
        if (validarNIF(nif)) {
            this.numDNI = DNI.extraerNumeroNIF(nif);
        } else {
            throw new Exception("NIF inválido: " + nif);
        }
    }

    private static char calcularLetraNIF(int dni) {
        char letra;
        letra = LETRAS_DNI.charAt(dni % 23);

        return letra;
    }

    private boolean validarNIF(String nif) {
        boolean dniCorrecto = true;

        if (nif.length() < 8 || nif.length() > 9) {
            dniCorrecto = false;
        } else {
            if (DNI.extraerLetraNIF(nif.toUpperCase())
                    == DNI.calcularLetraNIF(DNI.extraerNumeroNIF(nif))) {
                dniCorrecto = true;
            } else {
                dniCorrecto = false;
            }
        }
        return dniCorrecto;
    }

    private static char extraerLetraNIF(String nif) {
        char letra = nif.charAt(nif.length() - 1);
        return letra;
    }

    private static int extraerNumeroNIF(String nif) {
        int num = Integer.parseInt(nif.substring(0, nif.length() - 1));
        return num;
    }
}
