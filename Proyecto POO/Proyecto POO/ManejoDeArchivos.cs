using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using System.IO;



public class ManejoDeArchivos
{

    public static void HacerRecibo(List<List<Producto>> Historial,Usuario usuario)
    {
        List<Producto> productos = new List<Producto>();
        productos = Historial.SelectMany(x => x).ToList();
        try
        {
            string direccionArchivo = @"C:\Users\ferra\source\repos\Proyecto POO\RecibosClientes\compra_"+usuario.UserName+"_"+(usuario.NumVenta+1)+".txt";
            //Hago un nuevo escritor y le paso la dirección en donde se encuentra el archivo
            StreamWriter escribir = new StreamWriter(direccionArchivo, true);
            //Escribo el mensaje
            escribir.WriteLine("Los productos repetidos en un nuevo ticket no se cobraron nuevamente a la tarjeta (sólo refleja compras anteriores)");
            escribir.WriteLine("___________________________________________");
            escribir.WriteLine("    ID   | Producto          |  Costo ($) |");
            escribir.WriteLine("_________|___________________|____________|");
            for (int i = 0; i < productos.Count; i++)
            {
                escribir.WriteLine("         |                   |            |");
                escribir.WriteLine(" {0}   | {1}|  {2}       |", productos[i].Id, productos[i].Nombre, productos[i].Cost);
                escribir.WriteLine("_________|___________________|____________|");
            }
            escribir.WriteLine("Total: $" + usuario.Total);
            //Cierro el archivo
            escribir.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            Console.WriteLine("\nEl archivo se guardó exitosamente en la carpeta de este proyecto\n");
        }
    }


    public static void reporteDeAsistencia(Usuario usuario, List<List<Producto>> Historial)
    {
        try
        {
            List<Producto> listaProductos = new List<Producto>();
            string direccionArchivo = @"C:\Users\ferra\source\repos\Proyecto POO\Reporte asistencias\ReporteAsistencia0" + (usuario.NumVenta + 1) + ".txt";
            //Hago un nuevo escritor y le paso la dirección en donde se encuentra el archivo
            StreamWriter escribir = new StreamWriter(direccionArchivo, true);

            escribir.WriteLine("Reporte de asistencia de: {0} {1} {2}\n", usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno);
            for (int i = 0; i < usuario.Funciones.Count; i++)
            {
                escribir.WriteLine("Nombre de la película: {0}", usuario.Funciones1[i].Nombre);
                escribir.WriteLine("Asiento: {0}", usuario.Asientos[i]);
                escribir.WriteLine();
            }

            listaProductos = Historial.SelectMany(x => x).ToList();
            escribir.WriteLine("\nProductos consumidos: \n");
            escribir.WriteLine("___________________________________________");
            escribir.WriteLine("    ID   | Producto          |  Costo ($) |");
            escribir.WriteLine("_________|___________________|____________|");
            for (int i = 0; i < listaProductos.Count; i++)
            {
                escribir.WriteLine("         |                   |            |");
                escribir.WriteLine(" {0}   | {1}|  {2}       |", listaProductos[i].Id, listaProductos[i].Nombre, listaProductos[i].Cost);
                escribir.WriteLine("_________|___________________|____________|");
            }
            escribir.WriteLine("Total: $" + usuario.Total + "\n");
            escribir.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en la realización del reporte de asistencia: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("\nEl reporte de asistencia se guardó exitosamente en la carpeta de este proyecto\n");
        }
    }
}
