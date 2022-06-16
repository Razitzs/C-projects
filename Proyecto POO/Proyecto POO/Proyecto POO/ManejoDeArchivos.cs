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
    //public static List<Agenda> lecturaArchivoNombres(string nombreArchivo)
    //{
    //    string direccion = nombreArchivo;
    //    StreamReader reader = new StreamReader(File.OpenRead(@direccion));
    //    List<Agenda> lista = new List<Agenda>();

    //    while (!reader.EndOfStream)
    //    {
    //        var line = reader.ReadLine();
    //        var values = line.Split(',');
    //        Agenda agenda = new Agenda();
    //        agenda.Nombre = values[0];
    //        agenda.Apellido = values[1];
    //        agenda.Num = values[2];
    //        lista.Add(agenda);
    //    }
    //    reader.Close();
    //    return lista;
    //}

    public static void HacerRecibo(Usuario usuario,float total)
    {
        try
        {
            string direccionArchivo = @"C:\Users\ferra\source\repos\Proyecto POO\RecibosClientes\compra_"+usuario.UserName+"_"+usuario.NumVenta+".txt";
            //Hago un nuevo escritor y le paso la dirección en donde se encuentra el archivo
            StreamWriter escribir = new StreamWriter(direccionArchivo, true);
            //Escribo el mensaje
            escribir.WriteLine("___________________________________________");
            escribir.WriteLine("    ID   | Producto          |  Costo ($) |");
            escribir.WriteLine("_________|___________________|____________|");
            for (int i = 0; i < usuario.Productos.Count; i++)
            {
                escribir.WriteLine("         |                   |            |");
                escribir.WriteLine(" {0}   | {1}|  {2}       |", usuario.Productos[i].Id, usuario.Productos[i].Nombre, usuario.Productos[i].Cost);
                escribir.WriteLine("_________|___________________|____________|");
            }
            escribir.WriteLine("Total: $" + total);
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
}
