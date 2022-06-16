using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




 public class Producto
{
    string id;
    string nombre;
    string cost;
    float costo;
   

    public Producto()
    {

    }
    public Producto(string id, string nombre, float costo, string cost)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Costo = costo;
        this.Cost = cost;
    }

    public List<Producto> ShowProducts()
    {
        List<Producto> listaProductos = new List<Producto>();
        Producto p1 = new Producto("FS001", "Refresco Grande   ", 45,"45 ");
        Producto p2 = new Producto("FS002", "Hot Dog           ", 40, "40 ");
        Producto p3 = new Producto("FS003", "Palomitas Grandes ", 70,"70 ");
        Producto p4 = new Producto("FS004", "Icee              ", 55,"55 " );
        Producto p5 = new Producto("FS005", "Nachos            ", 70,"70 ");
        Producto p6 = new Producto("FS006", "Refresco mediano  ", 38,"38 " );
        Producto p7 = new Producto("FS007", "Palomitas medianas", 58,"58 ");
        Producto p8 = new Producto("FS008", "Refresco chico    ", 52,"52 ");
        Producto p9 = new Producto("FS009", "Palomitas chicas  ", 46,"46 ");
        Producto p10 = new Producto("FS010", "Chocolates        ", 34,"34 ");
        Producto p11 = new Producto("BF001", "Boleto Auto       ", 350,"350");
        Producto p12 = new Producto("BF002", "Boleto Camioneta  ", 475,"475");

        listaProductos.Add(p1);
        listaProductos.Add(p2);
        listaProductos.Add(p3);
        listaProductos.Add(p4);
        listaProductos.Add(p5);
        listaProductos.Add(p6);
        listaProductos.Add(p7);
        listaProductos.Add(p8);
        listaProductos.Add(p9);
        listaProductos.Add(p10);
        listaProductos.Add(p11);
        listaProductos.Add(p12);

        // Variables para las columnas y las filas
        Console.WriteLine("___________________________________________");
        Console.WriteLine("    ID   | Producto          |  Costo ($) |");
        Console.WriteLine("_________|___________________|____________|");
        for (int i = 0; i < listaProductos.Count; i++)
        {
            Console.WriteLine("         |                   |            |");
            Console.WriteLine(" {0}   | {1}|  {2}       |", listaProductos[i].Id, listaProductos[i].Nombre, listaProductos[i].Cost);
            Console.WriteLine("_________|___________________|____________|");
        }
        Console.WriteLine();
        return listaProductos;
    }

    public void comprarProductos(Usuario usuario,List<Usuario> usuarios, int numVenta)
    {
        int num,pago;
        float total;
        List<Producto> listaProductos = new List<Producto>();
        usuario.Productos.Clear();
        try
        {
            Producto producto = new Producto();
            listaProductos = producto.ShowProducts();
            if (usuario.Vehiculo.TipoDeAuto == "Automóvil")
            {
                usuario.Productos.Add(listaProductos[10]);
            }
            else if (usuario.Vehiculo.TipoDeAuto == "Camioneta")
            {
                usuario.Productos.Add(listaProductos[11]);
            }
            Console.WriteLine("Deseas comprar comprar algo de la dulcería?");
            Console.WriteLine("1) Sí");
            Console.WriteLine("2) No");
            int o = Convert.ToInt32(Console.ReadLine());
            if (o == 1)
            {
                Console.WriteLine("¿Cuántos productos desea adquirir?");
                num = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("Ingrese el ID del producto "+(i+1)+": ");
                    string id=Console.ReadLine();
                    if(verifyProducts(listaProductos, id, usuario)==false)
                    {
                        Console.WriteLine("Producto no existente");
                    }
                }
                imprimirProductosComprados(usuario.Productos,usuario);
            }
            else if (o == 2)
            {
                imprimirProductosComprados(usuario.Productos,usuario);
            }
            else
            {
                Console.WriteLine("Ingrese una opción válida");
            }
            Console.WriteLine("¿Proceder con el pago?");
            Console.WriteLine("1) Sí");
            Console.WriteLine("2) No");
            pago = Convert.ToInt32(Console.ReadLine());
            if (pago == 1)
            {
                
                Tarjeta tarjeta = new Tarjeta();
                total = sumaPrecios(usuario.Productos);
                usuario.Total = total;
                if (usuario.Tarjeta.Tipo == null)
                {
                    Console.WriteLine("\nPrimero es necesario registrar su tarjeta");
                    usuario.Tarjeta = tarjeta.registrarTarjeta(usuario);
                    tarjeta.imprimeDetalles(usuario.Tarjeta);
                    if (tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                    {
                        numVenta += 1;
                        usuario.NumVenta= numVenta;
                        ManejoDeArchivos.HacerRecibo(usuario,total);
                    }
                }
                else
                {
                    if (tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                    {
                        numVenta += 1;
                        usuario.NumVenta = numVenta;
                        ManejoDeArchivos.HacerRecibo(usuario,total);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nCobro no realizado");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nIngrese una opción válida (" + ex.Message + ")\n");
        }
    }


    public void comprarProductos2(Usuario usuario,List<Usuario> usuarios,int numVenta)
    {
        List<Producto> listaProductos=new List<Producto>();
        int num;
        float total;
        Producto producto = new Producto();
        usuario.Productos.Clear();
        listaProductos = producto.ShowProducts();
        Console.WriteLine("¿Cuántos productos desea adquirir?");
        num = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine("Ingrese el ID del producto " + (i + 1) + ": ");
            string id = Console.ReadLine();
            if (verifyProducts(listaProductos, id, usuario) == false)
            {
                Console.WriteLine("Producto no existente");
            }
        }
        imprimirProductosComprados(usuario.Productos,usuario);
        int pago;
        try
        {
            Console.WriteLine("¿Proceder con el pago?");
            Console.WriteLine("1) Sí");
            Console.WriteLine("2) No");
            pago = Convert.ToInt32(Console.ReadLine());
            if (pago == 1)
            {

                Tarjeta tarjeta = new Tarjeta();
                total = sumaPrecios(usuario.Productos);
                usuario.Total = total;
                if (usuario.Tarjeta.Tipo == null)
                {
                    Console.WriteLine("\nPrimero es necesario registrar su tarjeta");
                    usuario.Tarjeta = tarjeta.registrarTarjeta(usuario);
                    tarjeta.imprimeDetalles(usuario.Tarjeta);
                    if (tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                    {
                        numVenta += 1;
                        usuario.NumVenta = numVenta;
                        ManejoDeArchivos.HacerRecibo(usuario, total);
                    }
                }
                else
                {
                    if (tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                    {
                        numVenta += 1;
                        usuario.NumVenta = numVenta;
                        ManejoDeArchivos.HacerRecibo(usuario, total);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nCobro no realizado");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Este usuario no ha adquirido productos");
        }
    }

    public float sumaPrecios(List<Producto> productos)
    {
        float total = 0;
        for (int i = 0; i < productos.Count; i++)
        {
            total += productos[i].costo;
        }
        return total;
    }

    public void imprimirProductosComprados(List<Producto> listaProductos,Usuario usuario)
    {
        float total;
        total = sumaPrecios(usuario.Productos);
        Console.WriteLine("\nLista de productos adquiridos: \n");
        Console.WriteLine("___________________________________________");
        Console.WriteLine("    ID   | Producto          |  Costo ($) |");
        Console.WriteLine("_________|___________________|____________|");
        for (int i = 0; i < listaProductos.Count; i++)
        {
            Console.WriteLine("         |                   |            |");
            Console.WriteLine(" {0}   | {1}|  {2}       |", listaProductos[i].Id, listaProductos[i].Nombre, listaProductos[i].Cost);
            Console.WriteLine("_________|___________________|____________|");
        }
        Console.WriteLine("Total: $"+total);
    }

    public Boolean verifyProducts(List<Producto> productos, string id,Usuario usuario)
    {
        for(int i = 0;i < productos.Count;i++)
        {
            if(productos[i].Id == id)
            {
                usuario.Productos.Add(productos[i]);
                Console.WriteLine("Compra realizada con éxito :)");
                return true;
            }
        }
        return false;
    }

    public string Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Cost { get => cost; set => cost = value; }
    public float Costo { get => costo; set => costo = value; }
}

