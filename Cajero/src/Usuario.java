public class Usuario {
    private int NIP;
    private int saldo;
    public Usuario(){}
    public Usuario(int NIP,int saldo){
        this.NIP=NIP;
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