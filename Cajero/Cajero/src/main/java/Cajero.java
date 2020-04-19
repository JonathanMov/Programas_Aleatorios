import java.util.ArrayList;

public class Cajero {
    private int saldo_disponible;
    private ArrayList<Monto> billetes= new ArrayList<>(3);
    private final int denom[]={1000,500,200,100};
    
    public Cajero(int saldo){
        this.saldo_disponible=saldo;
        for(int i=0;i<=3;i++)billetes.add(new Monto());
        actualizar(saldo);
    }
    private ArrayList<Monto> acomodar(int saldo){
        ArrayList<Monto> acomodado = new ArrayList<>();
        for(int i=0;i<billetes.size();i++){
            acomodado.add(new Monto(denom[i],repartir_dinero(saldo,denom[i])));
            saldo-=acomodado.get(i).getDenominacion()*acomodado.get(i).getCantidad();
        }
        return acomodado;
    }
    private void actualizar(int saldo){
        for(int i=0;i<billetes.size();i++){
            this.billetes.set(i,new Monto(denom[i],repartir_dinero(saldo,denom[i])));
            saldo-=billetes.get(i).getDenominacion()*billetes.get(i).getCantidad();
        }
    }
    private int repartir_dinero(double m,double d){
        int i=0;
        for(i=0;i<=m;i++){
            if(m/d>=1)m-=d;
            else return i;
        }
        return i;
    }
    public ArrayList<Monto> retirar(int retiro){
        this.saldo_disponible-=retiro;
        
        actualizar(this.saldo_disponible);
        
        return acomodar(retiro);
    }
    public void getDinero(){
        System.out.println("Hay "+ this.saldo_disponible+" pesos en el cajero.");
        for(Monto d:billetes){
            System.out.println("Distribuidos en "+d.getCantidad()+" billets de "+d.getDenominacion());
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
}
