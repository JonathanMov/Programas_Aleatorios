import java.util.ArrayList;

public class Cajero {
    private int saldo_disponible;
    private ArrayList<Monto> billetes= new ArrayList<>(4);
    private final int denom[]={1000,500,200,100};
    private Usuario cliente=new Usuario();
    /*Creacion de constructor implementando el método actualizar y creando la ArrayList*/
    public Cajero(int saldo){
        this.saldo_disponible=saldo;
        for(int i=0;i<=3;i++)billetes.add(new Monto());
        actualizar(saldo);
    }
    /*Método privado para acomodar los billetes y su cantidad en la lista creada anteriormente*/
    private ArrayList<Monto> acomodar(int saldo){
        ArrayList<Monto> acomodado = new ArrayList<>();
        /*Se recorren las 4 posiciones de la ArrayList con el for y luego se agrega un dato tipo monto
        a la lista creada, para crear los montos se usa la denominacion con la posicion actual del
        for y para saber la cantidad de billetes que hay se usa el metodo repartir_dinero que se verá
        más adelante; despues se actualiza el saldo multiplicando la denominacion por la cantidad que
        hay de ese billete en la lista local. Se regresa la lista local.
        PD: este metodo CREA una lista y la regresa*/
        for(int i=0;i<=3;i++){
            acomodado.add(new Monto(denom[i],repartir_dinero(saldo,denom[i])));
            saldo-=acomodado.get(i).getDenominacion()*acomodado.get(i).getCantidad();
        }
        return acomodado;
    }
    /*Método para acomodar los billetes de la lista de clase, se usa la misma lógica que en el método
    de acomodar, solo que como se esta modificando la lista clase no se regresa ninguna lista.
    Pd: este metodo MODIFICA la lista clase*/
    private void actualizar(int saldo){
        for(int i=0;i<billetes.size();i++){
            this.billetes.set(i,new Monto(denom[i],repartir_dinero(saldo,denom[i])));
            saldo-=billetes.get(i).getDenominacion()*billetes.get(i).getCantidad();
        }
    }
    /*Método para saber la cantidad de billetes posibles de una denominacion en funcion de la cantidad 
    de dinero disponible*/
    private int repartir_dinero(double m,double d){
        /*Se declara un contador para que en caso de error se regrese 0. En el ciclo se usa una condicional
        que declara que si la division entre (la cantidad de dinero y la denominacion es mayor o igual a 1)
        el monto disminuira la cantidad de la denominacion, y si la condicion no se cumple el método regresará
        el valor actual del contador*/
        int i=0;
        for(i=0;i<=m;i++){
            if(m/d>=1)m-=d;
            else return i;
        }
        return i;
    }
    /*Se implementa la clase Usuario para poder llevar acabo las validaciones de retiro*/
    public void login(Usuario c){
        this.cliente=c;
    }
    /*Método que regresa una lista con los billetes que el cajero regresó */
    public ArrayList<Monto> retirar(int retiro){
        /*Condicion para saber si el cliente y el cajero tiene suficientes fondos para realizar
        el retiro, se incluye otra condicional para saber si hay suficientes billetes para realizar
        el retiro,se llama al método para que se le descuente el retiro a la cuenta
        del cliente, se disminuye la cantidad de dinero que tiene el cajero y se llama
        al método para*/
        if((cliente.getSaldo()>=retiro)&&(this.saldo_disponible>=retiro)){
            cliente.retirar(retiro);
        
            for(int i=0;i<=3;i++){
                if(billetes.get(i).getCantidad()<acomodar(retiro).get(i).getCantidad()){
                    System.out.println("Monto invalido, contacte encargado");
                    return null;
                }
            }
            
            for(int i=0;i<=3;i++){
                billetes.get(i).disCant(acomodar(retiro).get(i).getCantidad());
            }
            this.saldo_disponible-=retiro;
            return acomodar(retiro);
        }
        return null;
    }
    public void deposito(int b1000, int b500,int b200,int b100){
        int depositado=(b1000*1000)+(b500*500)+(b200*200)+(b100*100);
        cliente.depositar(depositado);
        this.saldo_disponible+=depositado;
        int cant[]={b1000,b500,b200,b100};
        for(int i=0;i<=3;i++)this.billetes.set(i,new Monto(denom[i],billetes.get(i).getCantidad()+cant[i]));
    }
    public void getDinero(){
        System.out.println("Hay "+ this.saldo_disponible+" pesos en el cajero.");
        for(Monto d:billetes){
            System.out.println("Distribuidos en "+d.getCantidad()+" billetes de "+d.getDenominacion());
        }
    }
}

class Monto{
    private int denominacion;
    private int cantidad;
    public Monto(){}
    public Monto(int denominacion,int cantidad){
        this.denominacion=denominacion;
        this.cantidad=cantidad;
    }
    public int getDenominacion(){
        return denominacion;
    }
    public int getCantidad(){
        return cantidad;
    }
    public void aumCant(int aumento){
        this.cantidad+=aumento;
    }
    public void disCant(int dism){
        this.cantidad-=dism;
    }
}