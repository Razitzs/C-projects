using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Usuario
{
    string nombre;
    string apellidoPaterno;
    string apellidoMaterno;
    string correo;
    string password;
    string celular;
    string direccion;
    string userName;
    Boolean yaRegistrado=false;
    int iniciadoSesion= -1;
    Boolean admin;
    List<Producto> productos=new List<Producto>();
    List<List<Producto>> historialDeProductos=new List<List<Producto>>();
    List<Funcion> funciones=new List<Funcion>();
    List<float> historialTotales=new List<float>();
    Vehiculo vehiculo=new Vehiculo();
    Tarjeta tarjeta=new Tarjeta();
    int numVenta;
    int numPeli=0;
    float total=0;
    string []asientos=new string[15];
    bool asistencia=false;
    public Usuario(string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string celular, string  direccion, string userName)
    {
        this.nombre = nombre;
        this.apellidoPaterno=apellidoPaterno;
        this.apellidoMaterno=apellidoMaterno;
        this.correo= correo;
        this.password= password;
        this.celular=celular;
        this.direccion=direccion;
        this.userName=userName;
    }
    public Usuario()
    {

    }
    public List<Usuario> addUser(List<Usuario> usuarios, Usuario newUser)
    {
        Console.WriteLine("Es necesario ingresar sus datos antes de comprar los boletos");
        Console.WriteLine("Ingresa tu nombre: ");
        newUser.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa tu apellido paterno: ");
        newUser.apellidoPaterno =Console.ReadLine();
        Console.WriteLine("Ingresa tu apellido materno: ");
        newUser.apellidoMaterno =Console.ReadLine();
        Console.WriteLine("Ingresa tu correo electrónico: ");
        newUser.correo =Console.ReadLine();
        Console.WriteLine("Ingresa tu contraseña: ");
        newUser.password =Console.ReadLine();
        Console.WriteLine("Ingresa número telefónico: ");
        newUser.celular =Console.ReadLine();
        Console.WriteLine("Ingresa tu dirección: ");
        newUser.direccion = Console.ReadLine();
        Console.WriteLine("Ingresa tu nombre de usuario: ");
        newUser.userName = Console.ReadLine();
        newUser.VerifyAdmin(newUser);
        usuarios.Add(newUser);
        printUser(newUser);
        newUser.YaRegistrado = true;
        return usuarios;
    }

    public Usuario editarPerfil(Usuario usuario)
    {
        bool bandera = false;
        int opcion;
        printUser(usuario);
        do
        {
            try
            {
                Console.WriteLine("\n¿Qué apartado deseas editar de tu perfil?");
                Console.WriteLine("1) Nombre");
                Console.WriteLine("2) Apellido paterno");
                Console.WriteLine("3) Apellido materno");
                Console.WriteLine("4) Correo electrónico");
                Console.WriteLine("5) Contraseña");
                Console.WriteLine("6) Número telefónico");
                Console.WriteLine("7) Nombre de usuario");
                Console.WriteLine("8) Dirección");
                Console.WriteLine("9) Todo");
                Console.WriteLine("0) Salir");
                opcion=Convert.ToInt32(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        {
                            Console.WriteLine("\nSeleccionaste: Nombre");
                            Console.WriteLine("Ingresa tu nuevo nombre: ");
                            usuario.nombre = Console.ReadLine();
                            Console.WriteLine("Nombre cambiado");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nSeleccionaste: Apelido paterno");
                            Console.WriteLine("Ingresa tu nuevo apellido paterno: ");
                            usuario.apellidoPaterno = Console.ReadLine();
                            Console.WriteLine("Apellido paterno cambiado");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nSeleccionaste: Apellido materno");
                            Console.WriteLine("Ingresa tu nuevo apellido materno: ");
                            usuario.apellidoMaterno = Console.ReadLine();
                            Console.WriteLine("Apellido materno cambiado");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\nSeleccionaste: Correo electrónico");
                            Console.WriteLine("Ingresa tu nuevo correo electrónico: ");
                            usuario.correo = Console.ReadLine();
                            Console.WriteLine("Correo electrónico cambiado");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\nSeleccionaste: Contraseña");
                            Console.WriteLine("Ingresa tu nueva contraseña: ");
                            usuario.password = Console.ReadLine();
                            Console.WriteLine("Contraseña cambiada");
                            break;
                        }

                    case 6:
                        {
                            Console.WriteLine("\nSeleccionaste: Número telefónico");
                            Console.WriteLine("Ingresa tu nuevo número telefónico: ");
                            usuario.celular = Console.ReadLine();
                            Console.WriteLine("Número telefónico cambiado");
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("\nSeleccionaste: Nombre de usuario");
                            Console.WriteLine("Ingresa tu nuevo nombre de usuario: ");
                            usuario.userName = Console.ReadLine();
                            Console.WriteLine("Nombre de usuario cambiado");
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Seleccionaste: Dirección");
                            Console.WriteLine("Ingresa tu nueva dirección: ");
                            usuario.direccion = Console.ReadLine();
                            Console.WriteLine("Dirección cambiada");
                            break;
                        }

                    case 9:
                        {
                            Console.WriteLine("\nSeleccionaste: Todo");
                            Console.WriteLine("Ingresa tu nuevo nombre: ");
                            usuario.nombre = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nuevo apellido paterno: ");
                            usuario.apellidoPaterno = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nuevo apellido materno: ");
                            usuario.apellidoMaterno = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nuevo correo electrónico: ");
                            usuario.correo = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nueva contraseña: ");
                            usuario.password = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nuevo número telefónico: ");
                            usuario.celular = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nueva dirección: ");
                            usuario.direccion = Console.ReadLine();
                            Console.WriteLine("Ingresa tu nuevo nombre de usuario: ");
                            usuario.userName = Console.ReadLine();
                            Console.WriteLine("Todos los campos cambiados");
                            break;
                        }
                    case 0: bandera = true; break;

                    default: Console.WriteLine("Ingrese una opción válida"); break;
                }
                printUser(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        } while (bandera != true);
        
        return usuario;
    }

    public Usuario logIn(List<Usuario> listaUsuarios)
    {
        string usuario, contra;
        int i;
        Usuario user = new Usuario();

        Console.WriteLine("Ingresa tu nombre de usuario:");
        usuario = Console.ReadLine();
        Console.WriteLine("Ingresa tu contraseña:");
        contra = Console.ReadLine();
        for (i = 0; i < listaUsuarios.Count; i++)
        {
            if (usuario == listaUsuarios[i].userName && listaUsuarios[i].password == contra)
            {
                Console.WriteLine("\n¡¡¡Bienvenid@ " + listaUsuarios[i].Nombre + " !!!");
                user = listaUsuarios[i];
                listaUsuarios[i].iniciadoSesion = 0;
                listaUsuarios[i].asistencia = true;
                return listaUsuarios[i];
            }
        }
        Console.WriteLine("\nInicio de sesión no válido");
        Console.WriteLine("Es probable que los datos ingresados sean incorrectos o esta cuenta no existe\n");
        return user;
    }








    public void printUser(Usuario user)
    {
        Console.WriteLine($"Tu nombre es: {user.Nombre}");
        Console.WriteLine($"Tu apellido paterno es: {user.apellidoPaterno}");
        Console.WriteLine($"Tu tu apellido materno es: {user.apellidoMaterno}");
        Console.WriteLine($"Tu correo es: {user.correo}");
        Console.WriteLine($"Tu contraseña es: {user.password}");
        Console.WriteLine($"Tu número telefónico es: {user.celular}");
        Console.WriteLine($"Tu nombre de usuario es: {user.userName}");
        Console.WriteLine($"Tu dirección es: {user.direccion}\n");

    }

    public int sesionIniciada()
    {
        if (IniciadoSesion==0)
        {

            return 0;
        }
        else
        {
            return -1;
        }
    }

    public Usuario iniciarSesion(List<Usuario> listaUsuarios)
    {
        string usuario, contra;
        int i, index;
        Usuario user=new Usuario();

            Console.WriteLine("Ingresa tu nombre de usuario:");
            usuario = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña:");
            contra = Console.ReadLine();
            for (i = 0; i < listaUsuarios.Count; i++)
            {
                if (usuario == listaUsuarios[i].userName && listaUsuarios[i].password == contra)
                {
                    index = i;
                    Console.WriteLine("\n¡¡¡Bienvenid@ " + listaUsuarios[i].Nombre + " !!!");
                    user=listaUsuarios[i];
                    listaUsuarios[i].iniciadoSesion = 0;
                    VerifyAdmin(listaUsuarios[i]);
                    return listaUsuarios[i];
                }
            }
            Console.WriteLine("\nInicio de sesión no válido");
            Console.WriteLine("Es probable que los datos ingresados sean incorrectos o esta cuenta no existe\n");
            return user;
    }

    public void VerifyAdmin(Usuario usuario)
    {
        if (usuario.UserName == "FotoAdmon" && usuario.password== "F3C&2116fi_8e15ñ")
        {
            usuario.admin = true;
        }
        else
        {
            usuario.admin = false;
        }
    }

    public void verBoleto(Usuario usuario)
    {
        Console.WriteLine();
        for(int i=0; i<usuario.Funciones1.Count; i++)
        {
            Console.WriteLine("Nombre de la película: {0}", usuario.Funciones1[i].Nombre);
            Console.WriteLine("Horario: {0}", usuario.Funciones1[i].Horario);
            Console.WriteLine("Duración: {0}", usuario.Funciones1[i].Duracion);
            Console.WriteLine("Director: {0}", usuario.Funciones1[i].Director);
            Console.WriteLine("Clasificación: {0}", usuario.Funciones1[i].Clasificacion);
            Console.WriteLine("Reseña: {0}", usuario.Funciones1[i].Reseña);
            Console.WriteLine("Asiento: {0}", usuario.Asientos[i]);
            Console.WriteLine("Marca del auto: {0}",usuario.vehiculo.Marca);
            Console.WriteLine("Modelo del auto: {0}", usuario.vehiculo.Modelo);
            Console.WriteLine("Tipo de auto: {0}", usuario.vehiculo.TipoDeAuto);
            Console.WriteLine("Placas: {0}", usuario.vehiculo.Placas);
            Console.WriteLine("Número de pasajeros: {0}", usuario.vehiculo.Pasajeros);
            Console.WriteLine();

        }
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
    public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
    public string Correo { get => correo; set => correo = value; }
    public string Password { get => password; set => password = value; }
    public string Celular { get => celular; set => celular = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public Boolean YaRegistrado { get => yaRegistrado; set => yaRegistrado = value; }
    public Boolean Admin { get => admin; set => admin = value; }
    public string UserName { get => userName; set => userName = value; }
    public int IniciadoSesion { get => iniciadoSesion; set => iniciadoSesion = value; }
    public List<Producto> Productos { get => productos; set => productos = value; }
    public List<Funcion> Funciones { get => Funciones1; set => Funciones1 = value; }
    public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
    public Tarjeta Tarjeta { get => tarjeta; set => tarjeta = value; }
    public int NumVenta { get => numVenta; set => numVenta = value; }
    public float Total { get => total; set => total = value; }
    public string[] Asientos { get => asientos; set => asientos = value; }
    public List<List<Producto>> HistorialDeProductos { get => historialDeProductos; set => historialDeProductos = value; }
    public List<float> HistorialTotales { get => historialTotales; set => historialTotales = value; }
    public int NumPeli { get => numPeli; set => numPeli = value; }
    public bool Asistencia { get => asistencia; set => asistencia = value; }
    public List<Funcion> Funciones1 { get => funciones; set => funciones = value; }
}
