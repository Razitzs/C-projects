using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Tarjeta
{
    string tipo;
    double saldo;
    string num;
    string banco;
    string codigo;

    public Tarjeta()
    {

    }
    public Tarjeta(string tipo, float saldo, string num, string banco, string codigo)
    {
        this.tipo = tipo;
        this.saldo = saldo;
        this.num = num;
        this.banco = banco;
        this.codigo = codigo;
    }

    public Tarjeta registrarTarjeta(Usuario usuario)
    {
        try
        {
            Console.WriteLine("Ingresa el tipo de tarjeta (crédito o débito): ");
            usuario.Tarjeta.tipo=Console.ReadLine();
            Console.WriteLine("Ingresa el saldo de la tarjeta: ");
            usuario.Tarjeta.saldo=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingresa el número de tarjeta: ");
            usuario.Tarjeta.num=Console.ReadLine();
            Console.WriteLine("Ingresa el banco de tu tarjeta: ");
            usuario.Tarjeta.banco=Console.ReadLine();   
            Console.WriteLine("Ingresa el código de verificación de tu tarjeta: ");
            usuario.Tarjeta.codigo=Console.ReadLine();
            Console.WriteLine("\nTarjeta registrada");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return usuario.Tarjeta;
    }

    public Boolean comprarConTarjeta(Usuario usuario, float total,List<Usuario> usuarios)
    {
        bool bandera=false;
        string num, verif;
        try
        {
            do
            {
                Console.WriteLine("Para pagar ingrese los siguientes datos de la tarjeta");
                Console.WriteLine("Número de la tarjeta: ");
                num = Console.ReadLine();
                Console.WriteLine("Código de verificación: ");
                verif = Console.ReadLine();
                if (verif == usuario.Tarjeta.Codigo && num == usuario.Tarjeta.num)
                {
                    if (usuario.Tarjeta.saldo >= total)
                    {
             
                        usuario.Tarjeta.saldo -= total;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Cargo a tu tarjeta completado");
                        Console.WriteLine("------------------------------\n");
                        bandera = true;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente :(");
                        bandera = true;
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("\nTarjeta no encontrada, es probable que la tarjeta no haya sido registrada o que alguno de los datos ingresados esté incorrecto");
                    return false;
                }
            } while (bandera != true);
        }
        catch(Exception ex)
        {
            Console.WriteLine (ex.Message);
        }
        return false;
    }

    public void imprimeDetalles(Tarjeta tarjeta)
    {
        Console.WriteLine("\nDetalles de la tarjeta: ");
        Console.WriteLine("Tipo:  {0}", tarjeta.tipo);
        Console.WriteLine("Saldo: ${0}", tarjeta.saldo);
        Console.WriteLine("Número: {0}", tarjeta.num);
        Console.WriteLine("Banco: {0}",tarjeta.banco);
        Console.WriteLine("Código de verifiación: {0}", tarjeta.codigo);
        Console.WriteLine("\n");
    }

    public string Tipo { get => tipo; set => tipo = value; }
    public double Saldo { get => saldo; set => saldo = value; }
    public string Num { get => num; set => num = value; }
    public string Banco { get => banco; set => banco = value; }
    public string Codigo { get => codigo; set => codigo = value; }
}

