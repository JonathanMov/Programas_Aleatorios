public class Usuario {
    private String nombre;
    private int saldo;
    public Usuario(){}
    public Usuario(String nombre,int saldo){
        this.nombre=nombre;
        this.saldo=saldo;
    }
    public void retirar(int retirado){
        this.saldo-=retirado;
    }
    public void depositar(int depositado){
        this.saldo+=depositado;
    }
    public int getSaldo(){
        return this.saldo;
    }
}