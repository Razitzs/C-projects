using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Vehiculo
{
    string marca;
    string modelo;
    string tipoDeAuto;
    string placas;
    int pasajeros;
    Boolean yaRegistrado=false;

    public Vehiculo()
    {

    }

    public Vehiculo(string marca, string modelo, string tipoDeAuto, string placas, int pasajeros)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.tipoDeAuto = tipoDeAuto;
        this.placas = placas;
        this.pasajeros = pasajeros;
    }

    public Vehiculo registrarAuto(Usuario usuario)
    {
        int tipo;
        try
        {
            Console.WriteLine("Ingresa el tipo de vehículo: ");
            Console.WriteLine("1) Automóvil");
            Console.WriteLine("2) Camioneta");
            tipo = Convert.ToInt32(Console.ReadLine());
            switch (tipo)
            {
                case 1:
                    {

                        usuario.Vehiculo.tipoDeAuto = "Automóvil";
                        break;
                    }
                case 2:
                    {
                        usuario.Vehiculo.tipoDeAuto = "Camioneta";
                        break;
                    }
                default: Console.WriteLine("Ingrese una opción válida"); break;

            }

            Console.WriteLine("Ingresa la marca de tu vehículo: ");
            usuario.Vehiculo.marca = Console.ReadLine();
            Console.WriteLine("Ingresa el modelo de tu vehículo: ");
            usuario.Vehiculo.modelo = Console.ReadLine();
            Console.WriteLine("Ingresa las placas de tu vehículo: ");
            usuario.Vehiculo.placas = Console.ReadLine();
            Console.WriteLine("El número de pasajeros en tu vehículo: ");
            usuario.Vehiculo.pasajeros = Convert.ToInt32(Console.ReadLine());
            usuario.Vehiculo.YaRegistrado = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nIngrese una opción válida (" + ex.Message + ")\n");
        }

        return usuario.Vehiculo;
    }

    void actualizarBoletos()
    {

    }

    void modificarPasajeros()
    {

    }

    void modificarVehiculo()
    {

    }

    public string Marca { get => marca; set => marca = value; }
    public string Modelo { get => modelo; set => modelo = value; }
    public string TipoDeAuto { get => tipoDeAuto; set => tipoDeAuto = value; }
    public string Placas { get => placas; set => placas = value; }
    public int Pasajeros { get => pasajeros; set => pasajeros = value; }
    public bool YaRegistrado { get => yaRegistrado; set => yaRegistrado = value; }
}

