using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    float costoTotal;
    string[,] map = new string[3, 5];
    Boolean [,] bMap= new Boolean[3, 5];

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

    public Funcion comprarBoletos(Funcion funcion, Usuario usuario,int numPeli)
    { 
            if (funcion.AsientosDisponibles == 0)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Boletos no disponibles");
                Console.WriteLine("-----------------------");
                return funcion;
            }
            else
            {
                funcion.asientosDisponibles--;
                try
                {
                int fila, columna;
                printMap(funcion);
                Console.WriteLine("Ingrese la fila deseada: ");
                fila = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la columna deseada: ");
                columna = Convert.ToInt32(Console.ReadLine());
                
                    if ( funcion.bMap[fila,columna]==true) 
                    {
                        funcion.Map[fila, columna] = " X  ";
                        funcion.bMap[fila, columna] = false;
                        usuario.Asientos[numPeli] = Convert.ToString(fila) + ", " + Convert.ToString(columna);
                        Console.WriteLine("Que disfrute su función :)");
                        funcion.printMap(funcion);
                        funcion.CostoTotal = funcion.Costo;
                        usuario.Funciones.Add(funcion);
                        Console.WriteLine("Asientos restantes: " + funcion.AsientosDisponibles);
                        return funcion;
                    }
                    else
                    {
                        Console.WriteLine("Lugar no disponible :(");
                        comprarBoletos(funcion, usuario, numPeli);
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

    public void actualizarBoletos(Usuario usuario,int numVenta)
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
                    int type;
                    bool b = false;
                    do
                    {
                        Console.WriteLine("Seleccionase: Modificar el tipo de vehículo");
                        Console.WriteLine("Ingrese el nuevo tipo de vehículo: ");
                        Console.WriteLine("1) Automóvil");
                        Console.WriteLine("2) Camioneta");
                        type = Convert.ToInt32(Console.ReadLine());
                        if (type == 1)
                        {
                            float total = ((30) + (350 - 350));
                            if (usuario.Tarjeta.comprarConTarjeta(usuario, total, usuarios) == true)
                                usuario.Vehiculo.TipoDeAuto = "Automóvil";
                            else
                                Console.WriteLine("No se realizó el cambio de vehículo");
                            b =true;
                        }
                        else if (type == 2)
                        {
                            float total= ((30) + (475 - 350));
                           
                            if (usuario.Tarjeta.comprarConTarjeta(usuario, total,usuarios)==true)
                                usuario.Vehiculo.TipoDeAuto = "Camioneta";
                            else
                                Console.WriteLine("No se realizó el cambio de vehículo");
                            b = true;
                        }
                        else
                        {
                            Console.WriteLine("Ingrese una opción válida");
                        }
                    }
                    while (b != true);
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
}
