using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
* Proyecto final
* 22/05/2022
* Equipo #1
* Integrantes:
* Armando García Granillo
* Fernando Razo Villeda
* Felipe Soriano Soto
* 
*/

public class Program
{
    static void Main(string[] args)
    {   
        Usuario admin = new Usuario("Joaquin", "Perez","Ramirez", "Joaqui.Perez@gmail.com", "F3C&2116fi_8e15ñ", "5509834984", "Av Dirección 1233", "FotoAdmon");
        List<Usuario> usuarios = new List<Usuario>();
        usuarios.Add(admin);
        Console.WriteLine("¡¡¡Bienvenido al Auto Cinema Foto Club!!! ");
        Menus.MenuUser(usuarios);
    }
}
