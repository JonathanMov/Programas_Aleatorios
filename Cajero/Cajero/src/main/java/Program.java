public class Program {
    public static void main(String[] args) {
        Cajero a=new Cajero(5000);
        a.getDinero();
        System.out.println("Se retiro 1200 pesos");
        for(Monto c: a.retirar(1200)){
            System.out.println("Distribuidos en "+c.getCantidad()+" billetes de "+c.getDenominacion());
        }
        a.getDinero();
        a.rellenar(2, 10, 5, 3);
        a.getDinero();
    }
}
