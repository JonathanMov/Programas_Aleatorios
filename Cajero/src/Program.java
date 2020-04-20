public class Program {
    public static void main(String[] args) {
        Cajero a=new Cajero(5000);
        a.login(new Usuario("Jonathan",3000));
        a.getDinero();
        System.out.println("Se retira 1200 pesos");
        a.retirar(1200);
        a.getDinero();
        a.deposito(2, 10, 5, 3);
        a.getDinero();
        System.out.println("Se retira 1200 pesos");
        a.retirar(1200);
        a.getDinero();
    }
}
