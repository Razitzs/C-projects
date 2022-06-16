using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class Menus
{
    public static void MenuUser(List<Usuario> usuarios)
    {
        List<Funcion> funciones = new List<Funcion>();
        Funcion Batman=new Funcion("The Batman", "7:00 pm","2h 56m","Matt Reeves", "PG-13", "8.0 (IMDB)");
        Funcion Spiderman = new Funcion("Spiderman no way home", "5:30 pm", "2h 28m","Jon Watts","PG-13", "8.3 (IMDB)");
        Funcion Red = new Funcion("Turning Red", "6:00 pm","1h 40m", "Domee Shi","PG", "7.0 (IMDB)");
        Batman=Batman.inicializar(Batman);
        Spiderman=Spiderman.inicializar(Spiderman);
        Red=Red.inicializar(Red);
        funciones.Add(Batman);
        funciones.Add(Spiderman);
        funciones.Add(Red);
        Usuario usuario = new Usuario();

        int opcion, bandera = 1, numVenta=0, numPeli=0;

        do
        {
            try
            {
                Console.WriteLine("Ingresa la opción deseada: ");
                Console.WriteLine("1) Iniciar sesión");
                Console.WriteLine("2) Registrarse");
                Console.WriteLine("3) Comprar boletos");
                Console.WriteLine("4) Ver mis boletos");
                Console.WriteLine("5) Ver recibos de compra");
                Console.WriteLine("6) Editar mi perfil");
                Console.WriteLine("7) Actualizar mis boletos");
                Console.WriteLine("8) Comprar complementos");
                Console.WriteLine("9) Cerrar sesión");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        {
                            Console.WriteLine("Seleccionaste: Iniciar sesión");
                            try
                            {
                                usuario = usuario.iniciarSesion(usuarios);
                                if (usuario.IniciadoSesion == 0)
                                {
                                    if (usuario.Admin == true)
                                    {
                                        menuAdmin(usuario, usuarios);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Seleccionaste: Registrarse");
                            Usuario newUser = new Usuario();
                            newUser = newUser.addUser(usuarios);
                            newUser.YaRegistrado = usuario.registrado();
                            usuarios.Add(usuario);
                            break;
                        }
                    case 3:
                        {
                            int op, band = 1;
                            Producto product = new Producto();
                            if (usuario.sesionIniciada() == 0)
                            {
                                Console.WriteLine("Seleccionaste: Comprar boletos");
                                Batman.verCartelera(funciones);
                                do
                                {
                                    Console.WriteLine("Presione 0 para salir");
                                    Console.WriteLine("\nSelecciona la función deseada: ");
                                    op = Convert.ToInt32(Console.ReadLine());
                                    switch (op)
                                    {
                                        case 1:
                                            {
                                                Vehiculo vehiculo = new Vehiculo();
                                                if(usuario.Vehiculo.YaRegistrado==false)
                                                    vehiculo.registrarAuto(usuario);
                                                if (usuario.Vehiculo.YaRegistrado == true)
                                                {
                                                    Batman=Batman.comprarBoletos(Batman,usuario,numPeli);
                                                    numPeli++;
                                                    product.comprarProductos(usuario,usuarios,numVenta);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error en el registro del vehículo, intente de nuevo");
                                                }
                                                break;
                                            }
                                        case 2:
                                            {

                                                Vehiculo vehiculo = new Vehiculo();
                                                if(usuario.Vehiculo.YaRegistrado==false)
                                                    vehiculo.registrarAuto(usuario);
                                                if (usuario.Vehiculo.YaRegistrado == true)
                                                {
                                                    Spiderman = Spiderman.comprarBoletos(Spiderman, usuario, numPeli);
                                                    numPeli++;
                                                    product.comprarProductos(usuario,usuarios,numVenta);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error en el registro del vehículo, intente de nuevo");
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                Vehiculo vehiculo = new Vehiculo();
                                                if (usuario.Vehiculo.YaRegistrado==false)
                                                    vehiculo.registrarAuto(usuario);
                                                if (usuario.Vehiculo.YaRegistrado == true)
                                                {
                                                    Red= Red.comprarBoletos(Red, usuario, numPeli);
                                                    numPeli++;
                                                    product.comprarProductos(usuario,usuarios,numVenta);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error en el registro del vehículo, intente de nuevo");
                                                }
                                                break;
                                        }
                                        case 0: band = 0; break;
                                        default: Console.WriteLine("Ingrese una opción válida"); break;
                                    }
                                } while (band != 0);
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }

                            break;
                        }
                    case 4:
                        {

                            if (usuario.sesionIniciada() == 0)
                            {
                                if (usuario.Funciones.Any())
                                {
                                    Console.WriteLine("\nSeleccionaste: Ver mis boletos");
                                    usuario.verBoleto(usuario);
                                }
                                else
                                {
                                    Console.WriteLine("\nEste usuario no ha comprado boletos");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }
                            break;
                        }
                    case 5:
                        {
                            //Ver como solucionar que no se borre el historial pero que tampoco se le cobre doble al cliente
                            if (usuario.sesionIniciada() == 0)
                            {
                                try
                                {
                                    Producto producto = new Producto();
                                    Console.WriteLine("Seleccionaste: Ver mis recibos de compra");
                                    producto.imprimirProductosComprados(usuario.Productos, usuario);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }
                            break;
                        }
                    case 6:
                        {
                            if (usuario.sesionIniciada() == 0)
                            {
                                Console.WriteLine("Seleccionaste: Editar mi perfil");
                                usuario=usuario.editarPerfil(usuario);
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }

                            break;
                        }
                    case 7:
                        {
                            if (usuario.sesionIniciada() == 0)
                            {
                                if (usuario.Funciones.Any() == true)
                                {
                                    Funcion funcion = new Funcion();
                                    Console.WriteLine("Seleccionaste: Actualizar mis boletos");
                                    funcion.actualizarBoletos(usuario,numVenta);
                                }
                                else
                                {
                                    Console.WriteLine("Este usuario no ha adquirido boletos");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }
                            break;
                        }

                    case 8:
                        {
                            if (usuario.IniciadoSesion == 0)
                            {
                                Console.WriteLine("Seleccionaste: Comprar complementos\n");
                                Vehiculo vehiculo = new Vehiculo();
                                if (usuario.Vehiculo.YaRegistrado==false)
                                {
                                    vehiculo = vehiculo.registrarAuto(usuario);
                                    usuario.Vehiculo = vehiculo;
                                }
                                else
                                {
                                    Producto producto = new Producto();
                                    producto.comprarProductos2(usuario, usuarios,numVenta);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Primero debes de iniciar sesión");
                            }
                            break;
                        }
                    case 9:
                        {
                            if (usuario.sesionIniciada() == 0)
                            {
                                Console.WriteLine("Seleccionaste: Cerrar sesión");
                                usuario.IniciadoSesion=-1;
                                Console.WriteLine("Sesión cerrada");
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }
                            break;
                        }
                    case 0: Console.WriteLine("Hasta luego :)"); bandera = 0; break;
                    default: Console.WriteLine("\nIngrese una opción válida\n"); break;
                }
            } 
            catch (FormatException ex)
            {
                Console.WriteLine("\nIngrese una opción válida ("+ ex.Message+ ")\n");
            }
        } while (bandera != 0);
    }

    public static void menuAdmin(Usuario usuario,List<Usuario> usuarios)
    {
        int opcion, bandera = 1;
        do
        { 
            try
            {
                    Console.WriteLine("Ingresa la opción deseada: ");
                    Console.WriteLine("1) Editar cartelera");
                    Console.WriteLine("2) Ver venta de boletos");
                    Console.WriteLine("3) Ver venta de productos");
                    Console.WriteLine("4) Reportes");
                    Console.WriteLine("5) Iniciar simulación");
                    Console.WriteLine("6) Cerrar sesión");
                    Console.WriteLine("0) Salir");
                    Console.Write("Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            {

                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste: editar cartelera");

                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }

                                break;
                            }
                        case 2:
                            {

                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste: Ver venta de boletos");
                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }

                                break;
                            }
                        case 3:
                            {

                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste: Ver venta de productos");
                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }

                                break;
                            }
                        case 4:
                            {

                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste:  Reportes");
                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }


                                break;
                            }
                        case 5:
                            {

                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste: Iniciar simulación");
                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }

                                break;
                            }
                        case 6:
                            {
                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste: Cerrar sesión");
                                    usuario = null;
                                    Console.WriteLine("Sesión cerrada");
                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }
                                break;
                            }
                    case 0: Console.WriteLine("Hasta luego :)"); bandera = 0; break;

                        default: Console.WriteLine("Ingrese una opción válida"); break;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nIngrese una opción válida (" + ex.Message + ")\n");
            }
        } while (bandera != 0) ;
    }


    public static void Reportes()
    {
        int opcion, bandera = 1;
        do
        {
            try
            {
                Console.WriteLine("Ingresa la modalidad deseada: ");
                Console.WriteLine("1) Por producto");
                Console.WriteLine("2) Por función");
                Console.WriteLine("3) Por horario (Boletos)");
                Console.WriteLine("4) Descargar reporte completo");
                Console.WriteLine("5) Descargar reporte por función");
                Console.WriteLine("6) Descargar reporte de venta de boletos");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        {
                            Console.WriteLine("Seleccionaste: Por producto");

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Seleccionaste: Por función");

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Seleccionaste: Por horario (Boletos)");

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Seleccionaste: Descargar reporte completo");

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Seleccionaste: Descargar reporte por función");

                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Seleccionaste: Descargar reporte de venta de boletos");

                            break;
                        }

                    case 0: Console.WriteLine("Hasta luego :)"); bandera = 0; break;

                    default: Console.WriteLine("Ingrese una opción válida"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nIngrese una opción válida (" + ex.Message + ")\n");
            }
        } while (bandera != 0);
    }
}




