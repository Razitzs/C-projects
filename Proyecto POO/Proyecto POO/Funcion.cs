using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Funcion
{
    string nombre;
    string horario;
    string duracion;
    string director;
    string clasificacion;
    string reseña;
    float costo;
    int asientosDisponibles=15;
    int numEntradas;
    float costoTotal=0;
    int num;
    string[,] map = new string[3, 5];
    Boolean [,] bMap= new Boolean[3, 5];
    List<Usuario> usuarios=new List<Usuario>();
    List<Producto> productos=new List<Producto>();

    public Funcion()
    {

    }
    public Funcion(string nombre, string horario, string duracion, string director, string clasificacion, string reseña)
    {
        this.nombre = nombre;
        this.horario = horario;
        this.duracion = duracion;
        this.director = director;
        this.clasificacion=clasificacion;
        this.reseña = reseña;
    }

    public void tablaDeProductos(Funcion funcion)
    {
        Producto p1 = new Producto("FS001", "Refresco Grande   ", 45, "45 ");
        Producto p2 = new Producto("FS002", "Hot Dog           ", 40, "40 ");
        Producto p3 = new Producto("FS003", "Palomitas Grandes ", 70, "70 ");
        Producto p4 = new Producto("FS004", "Icee              ", 55, "55 ");
        Producto p5 = new Producto("FS005", "Nachos            ", 70, "70 ");
        Producto p6 = new Producto("FS006", "Refresco mediano  ", 38, "38 ");
        Producto p7 = new Producto("FS007", "Palomitas medianas", 58, "58 ");
        Producto p8 = new Producto("FS008", "Refresco chico    ", 52, "52 ");
        Producto p9 = new Producto("FS009", "Palomitas chicas  ", 46, "46 ");
        Producto p10 = new Producto("FS010", "Chocolates        ", 34, "34 ");
        Producto p11 = new Producto("BF001", "Boleto Auto       ", 350, "350");
        Producto p12 = new Producto("BF002", "Boleto Camioneta  ", 475, "475");

        funcion.Productos.Add(p1);
        funcion.Productos.Add(p2);
        funcion.Productos.Add(p3);
        funcion.Productos.Add(p4);
        funcion.Productos.Add(p5);
        funcion.Productos.Add(p6);
        funcion.Productos.Add(p7);
        funcion.Productos.Add(p8);
        funcion.Productos.Add(p9);
        funcion.Productos.Add(p10);
        funcion.Productos.Add(p11);
        funcion.Productos.Add(p12);
    }

    public float reportePorVentaDeBoletos(Funcion funcion,float total,ref int cantidadAutos,ref int cantidadCamionetas)
    {
        List<Producto> products = new List<Producto>();

        for (int i = 0; i < funcion.usuarios.Count; i++)
        {
            products = funcion.usuarios[i].HistorialDeProductos.SelectMany(x => x).ToList();
            for (int j = 0; j < funcion.Productos.Count; j++)
            {
                for (int k = 0; k < products.Count; k++)
                {
                    if (funcion.Productos[j].Id == products[k].Id && products[k].Id == "BF001") 
                    {
                        cantidadAutos++;
                        total += 350;
                    }
                    else if(funcion.Productos[j].Id == products[k].Id && products[k].Id == "BF002")
                    {
                        cantidadCamionetas++;
                        total += 475;
                    }
                   
                }
            }
        }
        return total;
    }

    public void imprimeVentaBoletos(float total,ref int cantidadAutos,ref int cantidadCamionetas, bool descargar,int numReporteB)
    {
        Console.WriteLine("Boletos vendidos en general: ");
        Console.WriteLine("__________________________________________");
        Console.WriteLine("    Tipo de Vehículo    |    Cantidad    |");
        Console.WriteLine("________________________|________________|");
        Console.WriteLine("                        |                |");
        Console.WriteLine("    Automóvil           |        {0}       |", cantidadAutos);
        Console.WriteLine("    Camioneta           |        {0}       |", cantidadCamionetas);
        Console.WriteLine("________________________|________________|");
        Console.WriteLine("Total: ${0}\n",total);

        if(descargar==true)
        {
            try
            {
                string direccionArchivo = @"C:\Users\ferra\source\repos\Proyecto POO\Reportes\ReporteVentaBoletos0" + numReporteB + ".txt";
                //Hago un nuevo escritor y le paso la dirección en donde se encuentra el archivo
                StreamWriter escribir = new StreamWriter(direccionArchivo, true);
                //Escribo el mensaje
                escribir.WriteLine("Boletos vendidos en general: ");
                escribir.WriteLine("__________________________________________");
                escribir.WriteLine("    Tipo de Vehículo    |    Cantidad    |");
                escribir.WriteLine("________________________|________________|");
                escribir.WriteLine("                        |                |");
                escribir.WriteLine("    Automóvil           |        {0}       |", cantidadAutos);
                escribir.WriteLine("    Camioneta           |        {0}       |", cantidadCamionetas);
                escribir.WriteLine("________________________|________________|");
                escribir.WriteLine("Total: ${0}\n", total);
                escribir.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("\nEl reporte se guardó exitosamente en la carpeta de este proyecto\n");
            }
        }
    }


    public float reportePorProducto(Funcion funcion, Funcion function, int numReporte,float totalTodas)
    {
        List<Producto> products = new List<Producto>();
        
        for (int i = 0; i < funcion.usuarios.Count; i++)
        {
            products = funcion.usuarios[i].HistorialDeProductos.SelectMany(x => x).ToList();
            for (int j = 0; j < funcion.Productos.Count; j++)
            {
                for (int k = 0; k < products.Count; k++)
                {
                    if (funcion.Productos[j].Id == products[k].Id)
                    {
                        function.Productos[j].Cantidad++;
                    }
                }
            }
        }

        for (int i = 0; i < funcion.usuarios.Count; i++)
        {
            totalTodas += funcion.usuarios[i].Total;
        }
        return totalTodas;
    }



    public void reporteFuncion(Funcion funcion, Boolean descargar,int numReporte,string tipoDeReporte)
    {
        List<Producto> products = new List<Producto>();
        funcion=reiniciarCuenta(funcion);
        for(int i = 0; i < funcion.usuarios.Count; i++)
        {
            products =funcion.usuarios[i].HistorialDeProductos.SelectMany(x => x).ToList();
            for (int j = 0; j<funcion.Productos.Count; j++)
            {
                for (int k = 0; k < products.Count; k++)
                {
                    if (funcion.Productos[j].Id == products[k].Id)
                    {
                        funcion.Productos[j].Cantidad++;
                    }
                }
            }
        }

        if (descargar == false)
            reporteF(funcion, descargar, numReporte, true, tipoDeReporte, 0);
        else if (descargar == true)
            reporteF(funcion, descargar, numReporte, true, tipoDeReporte, 0);            
    }


    public void reporteF(Funcion funcion,Boolean descargar, int numReporte,Boolean imprime,string tipoDeReporte,float totalTodas)
    {
        float total = 0;
        if(imprime==true)
            Console.WriteLine("\nReporte de: {0}\n",funcion.nombre);
        Console.WriteLine("__________________________________________________________");
        Console.WriteLine("    ID   | Producto          |  Costo ($) |   Cantidad   |");
        Console.WriteLine("_________|___________________|____________|______________|");
        for (int i = 0; i < funcion.Productos.Count; i++)
        {
            Console.WriteLine("         |                   |            |              |");
            Console.WriteLine(" {0}   | {1}|  {2}       |     {3}        |", funcion.Productos[i].Id, funcion.Productos[i].Nombre, funcion.Productos[i].Cost, funcion.Productos[i].Cantidad);
            Console.WriteLine("_________|___________________|____________|______________|");
        }


        if (tipoDeReporte != "ReportePorProducto0")
        {
            for (int i = 0; i < funcion.usuarios.Count; i++)
            {
                total += funcion.usuarios[i].Total;
            }
            Console.WriteLine("Total: $" + total + "\n");
        }
        else
            Console.WriteLine("Total: $" + totalTodas + "\n");
        
        
        if (descargar == true)
        {
            try
            {
                string direccionArchivo;
                if (tipoDeReporte== "ReporteCompleto0")
                    direccionArchivo = @"C:\Users\ferra\source\repos\Proyecto POO\Reportes\ReporteCompleto0"+numReporte;
                else
                    direccionArchivo = @"C:\Users\ferra\source\repos\Proyecto POO\Reportes\" + tipoDeReporte + (funcion.num + 1) + "_0" + numReporte;
                //Hago un nuevo escritor y le paso la dirección en donde se encuentra el archivo
                StreamWriter escribir = new StreamWriter(direccionArchivo, true);
                //Escribo el mensaje
                escribir.WriteLine("\nReporte de: {0}\n", funcion.nombre);
                escribir.WriteLine("__________________________________________________________");
                escribir.WriteLine("    ID   | Producto          |  Costo ($) |   Cantidad   |");
                escribir.WriteLine("_________|___________________|____________|______________|");
                for (int i = 0; i < funcion.Productos.Count; i++)
                {
                    escribir.WriteLine("         |                   |            |              |");
                    escribir.WriteLine(" {0}   | {1}|  {2}       |     {3}        |", funcion.Productos[i].Id, funcion.Productos[i].Nombre, funcion.Productos[i].Cost, funcion.Productos[i].Cantidad);
                    escribir.WriteLine("_________|___________________|____________|______________|");
                }
                if(tipoDeReporte!= "ReportePorProducto0")
                    escribir.WriteLine("Total: $" + total + "\n");
                else
                    escribir.WriteLine("Total: $" + totalTodas + "\n");

                escribir.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


    public Funcion reiniciarCuenta(Funcion funcion)
    {
        for(int i=0; i<funcion.Productos.Count;i++)
        {
            funcion.Productos[i].Cantidad = 0;
        }
        return funcion;
    }



    public Funcion comprarBoletos(Funcion funcion, Usuario usuario,int numPeli,List<Usuario> usuarios, int numVenta)
    { 
        Producto producto=new Producto();
        Funcion Ftemporal=new Funcion();
        Usuario user = new Usuario();
        inicializar(Ftemporal);

            if (funcion.AsientosDisponibles == 0)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Boletos no disponibles");
                Console.WriteLine("-----------------------");
                return funcion;
            }
            else
            {
                try
                {
                    int fila, columna;
                    printMap(funcion);
                    Console.WriteLine("Ingrese la fila deseada: ");
                    fila = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese la columna deseada: ");
                    columna = Convert.ToInt32(Console.ReadLine());

                    if (funcion.bMap[fila, columna] == true)
                    {
                        Ftemporal.Map[fila, columna] = " X  ";
                        Ftemporal.bMap[fila, columna] = false;
                        user.Asientos[numPeli] = Convert.ToString(fila) + ", " + Convert.ToString(columna);
                        Console.WriteLine("Que disfrute su función :)");
                        if (producto.comprarProductos(usuario, usuarios, numVenta) == true)
                        {
                            funcion.Map[fila, columna] = " X  ";
                            funcion.bMap[fila, columna] = false;
                            usuario.Asientos[numPeli] = Convert.ToString(fila) + ", " + Convert.ToString(columna);
                            funcion.asientosDisponibles--;
                            usuario.NumPeli++;
                            if (usuario.Vehiculo.TipoDeAuto == "Automóvil")
                                funcion.CostoTotal += 350;
                            else
                                funcion.costoTotal += 475;
                            usuario.Funciones.Add(funcion);
                            funcion.usuarios.Add(usuario);
                            Console.WriteLine("Asientos restantes: " + funcion.AsientosDisponibles);
                            return funcion;
                        }
                        else
                        {
                            Console.WriteLine("La compra del boleto no se realizó");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lugar no disponible :(");
                        comprarBoletos(funcion, usuario, numPeli, usuarios, numVenta);
                        return funcion;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            return funcion;
            }
    }

    public void actualizarBoletos(ref Usuario usuario,int numVenta)
    {
        int opcion;
        bool bandera = false;
        List<Usuario> usuarios = new List<Usuario>();
        try
        {
            do
            {
                Console.WriteLine("Ingresa la opción deseada: ");
                Console.WriteLine("1) Modificar el número de pasajeros en el auto");
                Console.WriteLine("2) Modificar el tipo de auto");
                Console.WriteLine("3) Agregar complementos");
                Console.WriteLine("0) Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    int num;
                    Console.WriteLine("Seleccionase: Modificar el número de pasajeros en el auto");
                    Console.WriteLine("Ingrese el nuevo número de pasajeros en el auto: ");
                    num = Convert.ToInt32(Console.ReadLine());
                    usuario.Vehiculo.Pasajeros = num;
                }
                else if (opcion == 2)
                {
                    int op=0;
                    bool b = false;
                    try
                    {
                        do
                        {
                            Console.WriteLine("Seleccionase: Modificar el tipo de vehículo");
                            if (usuario.Vehiculo.TipoDeAuto == "Automóvil")
                            {
                                Console.WriteLine("¿Deseas cambiar el tipo de tu vehículo a camioneta? Se te cobrarán $30 más la diferencia del boleto");
                                Console.WriteLine("1) Sí");
                                Console.WriteLine("2) No");
                                op = Convert.ToInt32(Console.ReadLine());
                                if (op == 1)
                                {
                                    float total = ((30) + (475 - 350));

                                    if (usuario.Tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                                    {
                                        usuario.Vehiculo.TipoDeAuto = "Camioneta";
                                        for (int i = 0; i < usuario.HistorialDeProductos.Count; i++)
                                        {
                                            if (usuario.HistorialDeProductos[0].ElementAt(i).Id == "BF001")
                                            {
                                                usuario.HistorialDeProductos[0].ElementAt(i).Id = "BF002";
                                                usuario.HistorialDeProductos[0].ElementAt(i).Nombre = "Boleto Camioneta  ";
                                                usuario.HistorialDeProductos[0].ElementAt(i).Cost = "475";
                                                usuario.HistorialDeProductos[0].ElementAt(i).Costo = 475;
                                            }
                                        }
                                        usuario.Total+=total;
                                        Console.WriteLine("Tipo de vehículo cambiado\n");
                                        b = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se realizó el cambio de vehículo debido a insuficiencia de fondos en la tarjeta");
                                        b = true;
                                    }
                                }
                                else
                                {
                                    b = true;
                                }
                            }
                            else if (usuario.Vehiculo.TipoDeAuto == "Camioneta")
                            {
                                Console.WriteLine("¿Deseas cambiar el tipo de tu vehículo a automóvil? Se te cobrarán $30");
                                Console.WriteLine("1) Sí");
                                Console.WriteLine("2) No");
                                op=Convert.ToInt32(Console.ReadLine()); 
                                if (op == 1)
                                { 
                                     
                                    float total = 30;
                                    if (usuario.Tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                                    {
                                        
                                        usuario.Vehiculo.TipoDeAuto = "Automóvil";
                                        
                                        for (int i = 0; i < usuario.HistorialDeProductos.Count; i++)
                                        {
                                            if (usuario.HistorialDeProductos[0].ElementAt(i).Id == "BF002")
                                            {
                                                usuario.HistorialDeProductos[0].ElementAt(i).Id = "BF001";
                                                usuario.HistorialDeProductos[0].ElementAt(i).Nombre = "Boleto Auto       ";
                                                usuario.HistorialDeProductos[0].ElementAt(i).Cost = "350";
                                                usuario.HistorialDeProductos[0].ElementAt(i).Costo = 350;
                                            }
                                        }
                                        usuario.Total += total;
                                        Console.WriteLine("Tipo de vehículo cambiado\n");
                                        b = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se realizó el cambio de vehículo debido a insuficiencia de fondos en la tarjeta");
                                        b = true;
                                    }
                                }
                                else
                                {
                                    b = true;
                                }
                            }
                        }
                        while (b != true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (opcion == 3)
                {
                    Producto producto = new Producto();
                    Console.WriteLine("Seleccionó: Agregar complementos");
                        producto.comprarProductos2(usuario, usuarios,numVenta);
                }
                else if(opcion==0)
                {
                    bandera = true;
                }
                else
                {
                    Console.WriteLine("Ingrese una opción válida");
                }
            }
            while (bandera != true);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void VerVentaDeBoletos(List<Funcion> funciones)
    {
        for (int i = 0; i < funciones.Count; i++)
        {
            Console.WriteLine("\nFunción {0}: {1}", (i + 1), funciones[i].nombre);
            funciones[i].printMap(funciones[i]);
            Console.WriteLine("Total recaudado de esta función: $" + funciones[i].costoTotal);
            Console.WriteLine();
        }
    }



    public void editarCartelera(List<Funcion> funciones)
    {
        bool bandera = false;
        int opcion;
        verCartelera(funciones);
        try
        {
            do
            {
                Console.WriteLine("Ingrese la función que desea editar");
                Console.WriteLine("Presione 0 para salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    editarPeli(funciones[opcion-1]);
                }
                else if (opcion == 2)
                {
                    editarPeli(funciones[opcion-1]);
                }
                else if (opcion == 3)
                {
                    editarPeli(funciones[opcion-1]);
                }
                else if(opcion==0)
                {
                    bandera=true;
                }
                else
                {
                    Console.WriteLine("Ingrese una opción válida");
                }
            }while (bandera != true);  
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void editarPeli(Funcion funcion)
    {
        bool bandera = false;
        int opcion;
        imprimeDetalles(funcion);
        do
        {

            try
            {
                Console.WriteLine("\n¿Qué apartado deseas editar de la función?");
                Console.WriteLine("1) Nombre");
                Console.WriteLine("2) Horario");
                Console.WriteLine("3) Duración");
                Console.WriteLine("4) Director");
                Console.WriteLine("5) Clasificación");
                Console.WriteLine("6) Reseña");
                Console.WriteLine("7) Todo");
                Console.WriteLine("0) Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        {
                            Console.WriteLine("\nSeleccionaste: Nombre");
                            Console.WriteLine("Ingresa el nuevo nombre: ");
                            funcion.nombre = Console.ReadLine();
                            Console.WriteLine("Nombre editado");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nSeleccionaste: Horario");
                            Console.WriteLine("Ingresa el nuevo horario: ");
                            funcion.Horario = Console.ReadLine();
                            Console.WriteLine("Horario editado");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nSeleccionaste: Duración");
                            Console.WriteLine("Ingresa la nueva duración: ");
                            funcion.duracion = Console.ReadLine();
                            Console.WriteLine("Duración editada");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\nSeleccionaste: Director");
                            Console.WriteLine("Ingresa el nuevo director: ");
                            funcion.director = Console.ReadLine();
                            Console.WriteLine("Director editado");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\nSeleccionaste: Clasificación");
                            Console.WriteLine("Ingresa la nueva clasificación: ");
                            funcion.clasificacion = Console.ReadLine();
                            Console.WriteLine("Clasificación editada");
                            break;
                        }

                    case 6:
                        {
                            Console.WriteLine("\nSeleccionaste: Reseña");
                            Console.WriteLine("Ingresa la nueva reseña: ");
                            funcion.reseña = Console.ReadLine();
                            Console.WriteLine("Reseña editada");
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("\nSeleccionaste: Todo");
                            Console.WriteLine("Ingresa el nuevo nombre: ");
                            funcion.nombre = Console.ReadLine();
                            Console.WriteLine("Ingresa el nuevo horario: ");
                            funcion.horario = Console.ReadLine();
                            Console.WriteLine("Ingresa la nueva duración: ");
                            funcion.duracion = Console.ReadLine();
                            Console.WriteLine("Ingresa el nuevo director: ");
                            funcion.director = Console.ReadLine();
                            Console.WriteLine("Ingresa la nueva clasificación: ");
                            funcion.clasificacion = Console.ReadLine();
                            Console.WriteLine("Ingresa la nueva reseña: ");
                            funcion.reseña = Console.ReadLine();
                            Console.WriteLine("Todos los campos cambiados");
                            break;
                        }
                    case 0: bandera = true; break;

                    default: Console.WriteLine("Ingrese una opción válida"); break;
                }
                imprimeDetalles(funcion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (bandera != true);
    }




    public void imprimeDetalles(Funcion funcion)
    {
        Console.WriteLine("\nDetalles de la función: ");
        Console.WriteLine("Nombre:  {0}", funcion.Nombre);
        Console.WriteLine("Horario: {0}", funcion.Horario);
        Console.WriteLine("Duración: {0}", funcion.Duracion);
        Console.WriteLine("Director: {0}", funcion.Director);
        Console.WriteLine("Clasificación: {0}", funcion.Clasificacion);
        Console.WriteLine("Reseña: {0}", funcion.Reseña);
        Console.WriteLine();
    }

    public void verCartelera(List<Funcion> funciones)
    {
        Console.WriteLine("\nDetalles de las funciones: ");
        for (int i = 0; i < funciones.Count; i++)
        {
            Console.WriteLine("\nOpción {0}",(i+1));
            Console.WriteLine("Nombre: {0}",funciones[i].Nombre);
            Console.WriteLine("Horario: {0}", funciones[i].Horario);
            Console.WriteLine("Duración: {0}", funciones[i].Duracion);
            Console.WriteLine("Director: {0}", funciones[i].Director);
            Console.WriteLine("Clasificación: {0}", funciones[i].Clasificacion);
            Console.WriteLine("Reseña: {0}", funciones[i].Reseña);
            Console.WriteLine();
        }
    }

    public void starMap(Funcion funcion)
    {
        for (int i = 0; i < funcion.Map.GetLength(0); i++)
        {
            for (int j = 0; j < funcion.Map.GetLength(1); j++)
            {
                funcion.Map[i, j] =Convert.ToString(i)+", "+Convert.ToString(j) ;
            }
        }
    }

    public  void startBMap(Funcion funcion)
    {
        for (int i = 0; i < funcion.bMap.GetLength(0); i++)
        {
            for (int j = 0; j < funcion.bMap.GetLength(1); j++)
            {
                funcion.bMap[i, j] = true;
            }
        }
    }

    public Funcion inicializar(Funcion funcion)
    {
        starMap(funcion);
        startBMap(funcion);
        return funcion;
    }


    public void printMap(Funcion funcion)
    {
        Console.WriteLine("\nMapa de la función: ");
        Console.WriteLine("\nDisponibles: coordenadas");
        Console.WriteLine("No disponibles: X");


        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("                           Pantalla                             |");
        Console.WriteLine("________________________________________________________________|");
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                Console.Write("    {0}    |", Map[i, j]);
            }
            Console.WriteLine("\n____________|____________|____________|____________|____________|");
        }
        Console.WriteLine("\n");
        
    }



    public string Nombre { get => nombre; set => nombre = value; }
    public string Horario { get => horario; set => horario = value; }
    public string Duracion { get => duracion; set => duracion = value; }
    public string Director { get => director; set => director = value; }
    public string Clasificacion { get => clasificacion; set => clasificacion = value; }
    public string Reseña { get => reseña; set => reseña = value; }
    public float Costo { get => costo; set => costo = value; }
    public int AsientosDisponibles { get => asientosDisponibles; set => asientosDisponibles = value; }
    public int NumEntradas { get => numEntradas; set => numEntradas = value; }
    public float CostoTotal { get => costoTotal; set => costoTotal = value; }
    public bool[,] BMap { get => bMap; set => bMap = value; }
    public string[,] Map { get => map; set => map = value; }
    public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
    public int Num { get => num; set => num = value; }
    public List<Producto> Productos { get => productos; set => productos = value; }
}
