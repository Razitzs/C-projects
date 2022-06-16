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
        Batman.tablaDeProductos(Batman);
        Spiderman.tablaDeProductos(Spiderman);
        Red.tablaDeProductos(Red);
        funciones.Add(Batman);
        funciones.Add(Spiderman);
        funciones.Add(Red);
        Usuario usuario = new Usuario();

        int opcion, bandera = 1, numVenta = 0;
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
                Console.WriteLine("9) Editar tarjeta");
                Console.WriteLine("10) Cerrar sesión");
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
                                        menuAdmin(usuario, usuarios,funciones,numVenta);
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
                            usuarios = newUser.addUser(usuarios,newUser);
                            break;
                        }
                    case 3:
                        {
                            int op, band = 1;
                            Producto product = new Producto();
                            if (usuario.sesionIniciada() == 0)
                            {
                                if (usuario.NumPeli == 0)
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
                                                    if (usuario.Vehiculo.YaRegistrado == false)
                                                        vehiculo.registrarAuto(usuario);
                                                    if (usuario.Vehiculo.YaRegistrado == true)
                                                    {
                                                        Batman = Batman.comprarBoletos(funciones[0], usuario, usuario.NumPeli, usuarios, numVenta);
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
                                                    if (usuario.Vehiculo.YaRegistrado == false)
                                                        vehiculo.registrarAuto(usuario);
                                                    if (usuario.Vehiculo.YaRegistrado == true)
                                                    {
                                                        Spiderman = Spiderman.comprarBoletos(funciones[1], usuario, usuario.NumPeli, usuarios, numVenta);
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
                                                    if (usuario.Vehiculo.YaRegistrado == false)
                                                        vehiculo.registrarAuto(usuario);
                                                    if (usuario.Vehiculo.YaRegistrado == true)
                                                    {
                                                        Red = Red.comprarBoletos(funciones[2], usuario, usuario.NumPeli, usuarios, numVenta);
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
                                    Console.WriteLine("Este usuario ya tiene un boleto comprado");
                                }
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
                            if (usuario.sesionIniciada() == 0)
                            {
                                try
                                {
                                    Producto producto = new Producto();
                                    Console.WriteLine("Seleccionaste: Ver mis recibos de compra");
                                    producto.historialDeCompras(usuario, usuario.HistorialDeProductos);
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
                                    funcion.actualizarBoletos(ref usuario,numVenta);
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
                                Producto producto = new Producto();
                                producto.comprarProductos2(usuario, usuarios,numVenta);
                                
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
                                Console.WriteLine("Seleccionaste: Editar tarjeta");
                                usuario.Tarjeta.editarTarjeta(usuario.Tarjeta);
                                Console.WriteLine("Sesión cerrada");
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                            }
                            break;
                        }
                    case 10:
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
            Console.WriteLine("\nIngrese una opción válida (" + ex.Message + ")\n");
        }
    } while (bandera != 0);
    }

    public static void menuAdmin(Usuario usuario,List<Usuario> usuarios,List<Funcion> funciones, int numVenta)
    {
        int opcion, bandera = 1;
        Funcion funcion = new Funcion();
      
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
                                    funcion.editarCartelera(funciones);
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
                                    funcion.VerVentaDeBoletos(funciones);
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
                                    Producto producto=new Producto();
                                    Console.WriteLine("Seleccionaste: Ver venta de productos");
                                    for(int i=1; i<usuarios.Count; i++)
                                    {
                                        Console.WriteLine("\n{0} {1} {2}: ",usuarios[i].Nombre,usuarios[i].ApellidoPaterno, usuarios[i].ApellidoMaterno);
                                        producto.historialDeCompras(usuarios[i], usuarios[i].HistorialDeProductos);
                                    }
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
                                    Reportes(funciones);
                                }
                                else
                                {
                                    Console.WriteLine("\nPrimero te tienes que iniciar sesión\n");
                                }


                                break;
                            }
                        case 5:
                            {
                                bool b = false;
                                int terminar;
                                Producto producto=new Producto();
                                
                                    Console.WriteLine("Seleccionaste: Iniciar simulación");
                                    usuario = usuario.logIn(usuarios);
                                    if(usuario.Asistencia==true && usuario.Funciones.Any()==true)
                                    {
                                    
                                        Console.WriteLine("\nEntrega de sus productos: ");
                                        producto.buyProducts(usuario, usuarios, numVenta);
                                        producto.historialDeCompras(usuario, usuario.HistorialDeProductos);

                                    do
                                    {
                                        Console.WriteLine("Se está reproduciendo la película...");
                                        Console.WriteLine("¿Quieres que termine?");
                                        Console.WriteLine("1) Sí");
                                        Console.WriteLine("2) No");
                                        terminar = Convert.ToInt32(Console.ReadLine());
                                        if(terminar==1)
                                        {
                                            usuario.IniciadoSesion = -1;
                                            ManejoDeArchivos.reporteDeAsistencia(usuario, usuario.HistorialDeProductos);
                                            b=true;
                                        }

                                    } while (b != true);
                                        
                                    
                                    }
                                    else
                                    {
                                        Console.WriteLine("El usuario debe comprar primero un boleto de cine para poder realizar la simulación");
                                    }
                                
                             
                                break;
                            }
                        case 6:
                            {
                                if (usuario.sesionIniciada() == 0)
                                {
                                    Console.WriteLine("Seleccionaste: Cerrar sesión");
                                    usuario.IniciadoSesion = -1;
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


    public static void Reportes(List<Funcion> funciones)
    {       
        int opcion, bandera = 1, numReporteC = 1, numReporteF =1, numReporteB=1, numReporteP=1;
       
        do
        {
            try
            {
                Console.WriteLine("Ingresa el reporte deseado: ");
                Console.WriteLine("1) Por producto");
                Console.WriteLine("2) Por función");
                Console.WriteLine("3) Venta de boletos");
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
                            Funcion funcion = new Funcion();
                            funcion.tablaDeProductos(funcion);
                            float totalTodas = 0;
                            Console.WriteLine("Seleccionaste: Por producto");
                            funcion.reiniciarCuenta(funcion);
                            for (int i = 0; i < funciones.Count; i++)
                                totalTodas = funcion.reportePorProducto(funciones[i], funcion, numReporteP, totalTodas);
                            funcion.reporteF(funcion, false, numReporteP, false, "ReportePorProducto0", totalTodas);
                            numReporteP++;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Seleccionaste: Por función");
                            bool b = false;
                            int op;
                            funciones[0].verCartelera(funciones);
                        try
                        {
                            do
                            {
                                    Console.WriteLine("Ingrese el reporte de la función deseada: ");
                                    Console.WriteLine("Presione 0 para salir");
                                    op = Convert.ToInt32(Console.ReadLine());
                                    if (op == 1)
                                    {
                                        funciones[0].reporteFuncion(funciones[0],false,numReporteF, "ReporteFuncion0");
                                    }
                                    else if (op== 2)
                                    {
                                        funciones[1].reporteFuncion(funciones[1], false, numReporteF, "ReporteFuncion0");
                                    }
                                    else if (op == 3)
                                    {
                                        funciones[2].reporteFuncion(funciones[2], false, numReporteF, "ReporteFuncion0");
                                    }
                                    else if (op== 0)
                                    {
                                        b = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese una opción válida");
                                    }
                            } while (b != true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                        }
                    case 3:
                        {
                            float totalBoletos = 0;
                            int cantidadAutos = 0, cantidadCamionetas = 0;
                            Console.WriteLine("Venta de boletos");
                            Funcion f = new Funcion();
                            f.tablaDeProductos(f);
                            for (int i = 0; i < funciones.Count; i++)
                                totalBoletos = f.reportePorVentaDeBoletos(funciones[i], totalBoletos, ref cantidadAutos, ref cantidadCamionetas);
                            f.imprimeVentaBoletos(totalBoletos, ref cantidadAutos, ref cantidadCamionetas,false,numReporteB);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Seleccionaste: Descargar reporte completo");
                            for(int i=0; i<funciones.Count; i++)
                                funciones[0].reporteFuncion(funciones[i],true,numReporteC,"ReporteCompleto0");
                            Console.WriteLine("\nReporte completo guardado en la carpeta del proyecto");
                            numReporteC++;
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Seleccionaste: Descargar reporte por función");
                            bool b = false;
                            int op;
                            funciones[0].verCartelera(funciones);
                        try
                        {
                            do
                                {
                                    Console.WriteLine("Ingrese el reporte de la función deseada: ");
                                    Console.WriteLine("Presione 0 para salir");
                                    op = Convert.ToInt32(Console.ReadLine());
                                    if (op == 1)
                                    {
                                        funciones[0].reporteFuncion(funciones[0], true, numReporteF,"ReporteFuncion0");
                                        Console.WriteLine("\nReporte por función guardado en la carpeta del proyecto");
                                        numReporteF++;
                                    }
                                    else if (op == 2)
                                    {
                                        funciones[1].reporteFuncion(funciones[1], true, numReporteF, "ReporteFuncion0");
                                        Console.WriteLine("\nReporte por función guardado en la carpeta del proyecto");
                                        numReporteF++;
                                    }
                                    else if (op == 3)
                                    {
                                        funciones[2].reporteFuncion(funciones[2], true, numReporteF, "ReporteFuncion0");
                                        Console.WriteLine("\nReporte por función guardado en la carpeta del proyecto");
                                        numReporteF++;
                                    }
                                    else if (op == 0)
                                    {
                                        b = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese una opción válida");
                                    }
                                } while (b != true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                        }
                    case 6:
                        {
                            float totalBoletos = 0;
                            int cantidadAutos = 0, cantidadCamionetas = 0;
                            Console.WriteLine("Seleccionaste: Descargar reporte de venta de boletos");
                            Funcion f = new Funcion();
                            f.tablaDeProductos(f);
                            for (int i = 0; i < funciones.Count; i++)
                                totalBoletos = f.reportePorVentaDeBoletos(funciones[i], totalBoletos, ref cantidadAutos, ref cantidadCamionetas);
                            f.imprimeVentaBoletos(totalBoletos, ref cantidadAutos, ref cantidadCamionetas, true, numReporteB);
                            numReporteB++;
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




