using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Proyecto Final
Equipo dinamita
Programación Orientada a Objetos
Grupo:
Semestre 2022-2
Equipo ##: Equipo dinamita
Integrantes:
* Armando García Granillo: Documentación
* Fernando Razo Villeda: Implementación del código
* Felipe Soriano Soto: Documentación
* 
*/

public class Program
{
    static void Main(string[] args)
    {
        Usuario admin = new Usuario("Joaquin", "Perez", "Ramirez", "Joaqui.Perez@gmail.com", "F3C&2116fi_8e15ñ", "5509834984", "Av Dirección 1233", "FotoAdmon");
        List<Usuario> usuarios = new List<Usuario>();
        usuarios.Add(admin);
        Console.WriteLine("¡¡¡Bienvenido al Auto Cinema Foto Club!!! ");
        Menus.MenuUser(usuarios);
    }
}
