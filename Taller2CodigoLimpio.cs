class Programa
{

    static void Main(string[] args)
    {
        List<IdeaNegocio> ideasDeNegocio = new List<IdeaNegocio>();

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar una nueva idea de negocio");
            Console.WriteLine("2. Mostrar ideas de negocio");
            Console.WriteLine("3. Agregar o eliminar integrantes del equipo");
            Console.WriteLine("4. Modificar el valor de inversión y total de ingresos");
            Console.WriteLine("5. Mostrar idea con mayor rentabilidad en 3 años");
            Console.WriteLine("6. Mostrar idea con más departamentos");
            Console.WriteLine("7. Mostrar las 3 ideas de negocio con más rentabilidad");
            Console.WriteLine("8. Mostrar la suma total de los ingresos de todas las ideas " +
                "de negocio");
            Console.WriteLine("9. Mostrat el total de inversión que se debe hacer");
            Console.WriteLine("10. Salir");
            Console.Write("Ingrese una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AgregarIdeaNegocio(ideasDeNegocio);
                    break;

                case "2":
                    MostrarIdeaNegocio(ideasDeNegocio);
                    break;

                case "3":
                    ModificarIntegrante(ideasDeNegocio);
                    break;

                case "4":
                    ModificarValores(ideasDeNegocio);
                    break;

                case "5":
                    MostrarIdeaMayorIngreso(ideasDeNegocio);
                    break;

                case "6":
                    MostrarIdeaMasDepartamentos(ideasDeNegocio);
                    break;

                case "7":
                    TresMasRentables(ideasDeNegocio);
                    break;

                case "8":
                    SumaTotalIngresos(ideasDeNegocio);
                    break;


                case "9":
                    SumaTotalInversion(ideasDeNegocio);
                    break;


                case "10":
                    Environment.Exit(0);
                    break;



                default:
                    Console.WriteLine("Opción no valida, por favor  " +
                        "ingrese una opción valida");
                    break;


            }
        }
    }

    static void AgregarIdeaNegocio(List<IdeaNegocio> ideasDeNegocio)
    {
        Console.WriteLine("\n");
        Console.WriteLine("Ingrese los datos de una nueva idea de negocio: ");
        IdeaNegocio idea = new IdeaNegocio();

        Console.Write("Código: ");
        idea.Codigo = Console.ReadLine();

        Console.Write("Nombre de la idea de negocio: ");
        idea.Nombre = Console.ReadLine();

        Console.Write("Ingrese el impacto social o económico que genera: ");
        idea.ImpactoSocial = Console.ReadLine();

        Console.WriteLine("Departamentos que se benefician con la idea de negocio: ");

        while (true)
        {
            Console.Write("Nombre del departamento (Escribir exit para salir): ");
            string nombreDepartamento = Console.ReadLine();
            if (nombreDepartamento.ToLower() == "exit")
            {
                break;
            }

            Console.Write("Código del departamento: ");
            string codigoDepartamento = Console.ReadLine();

            idea.Departamentos.Add(new Departamento
            {
                Nombre = nombreDepartamento,
                Codigo = codigoDepartamento
            });
        }

        Console.Write("Valor de la inversión: ");
        idea.Inversion = double.Parse(Console.ReadLine());

        Console.Write("Ingresos totales en los primeros 3 años: ");
        idea.Ingresos = double.Parse(Console.ReadLine());

        Console.WriteLine("Integrantes del equipo: ");
        while (true)
        {
            Console.Write("Identificación del integrante(Escriba exit para salir): ");
            string idenfiticacionIntegrante = Console.ReadLine();
            if (idenfiticacionIntegrante.ToLower() == "exit")
            {
                break;
            }
            Console.Write("Nombre del integrante: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido del integrante: ");
            string apellidos = Console.ReadLine();

            Console.Write("Rol del integrante: ");
            string rol = Console.ReadLine();

            Console.Write("Email del integrante: ");
            string email = Console.ReadLine();
            idea.Equipos.Add(new IntegrantesEquipo
            {
                Identificacion = idenfiticacionIntegrante,
                Nombre = nombre,
                Apellidos = apellidos,
                Rol = rol,
                Email = email
            });
        }

        Console.Write("Herramienta de la 4 Revolución industrial utilizada: ");
        idea.Herramientas4RI = Console.ReadLine();

        ideasDeNegocio.Add(idea);
        Console.WriteLine("");
        Console.Write("Idea de negocio agregada exictosamente");
        Console.WriteLine("");
    }

    static void MostrarIdeaNegocio(List<IdeaNegocio> ideasDeNegocio)
    {
            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Resumen de las idea de negocio ingresadas: ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n");
        foreach (var idea in ideasDeNegocio)
            {
                Console.WriteLine($"Código: {idea.Codigo}");
                Console.WriteLine($"Nombre: {idea.Nombre}");
                Console.WriteLine($"Impacto: {idea.ImpactoSocial}");
                Console.WriteLine($"Departamentos beneficiados:");
                foreach (var departamentos in idea.Departamentos)
                {
                    Console.WriteLine($" Nombre: {departamentos.Nombre}, " +
                        $"Código: {departamentos.Codigo}");
                }
                Console.WriteLine($"Valor de la inversión: {idea.Inversion}");
                Console.WriteLine($"Total de ingresos " +
                    $"en los primeros 3 años: {idea.Ingresos}");

                Console.WriteLine("Integrantes del equipo:");
                foreach (var integrante in idea.Equipos)
                {
                    Console.WriteLine($"Identificación: {integrante.Identificacion}, " +
                        $"Nombre: {integrante.Nombre} {integrante.Apellidos}," +
                        $" Rol: {integrante.Rol}, Email: {integrante.Email}");
                }

                Console.WriteLine($"Herramientas de la 4RI utilizadas: {idea.Herramientas4RI}");
                Console.WriteLine("\n");
            }
    }

    static void ModificarIntegrante(List<IdeaNegocio> ideasDeNegocio)
    {
        Console.Write("Ingrese el código de la idea de negocio a la cual le quiere " +
            "agregar o eliminar un integrante: ");
        string codigoIdea = Console.ReadLine();

        var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigoIdea);

        if ( idea == null )
        {
            Console.WriteLine("No se encontro una idea de negocio con ese código");
            return;
        }

        Console.WriteLine("\n");
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Agregar integrante al equipo");
        Console.WriteLine("2. Eliminar integrante del equipo");
        Console.Write("Ingrese un número:");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":

                Console.WriteLine("Ingrese los datos del nuevo integrante");
                Console.Write("Identificación: ");
                string identifiacion = Console.ReadLine();

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();

                Console.Write("Rol: ");
                string rol = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                idea.Equipos.Add(new IntegrantesEquipo
                {
                    Identificacion = identifiacion,
                    Nombre = nombre,
                    Apellidos = apellido,
                    Rol = rol,
                    Email = email
                });

                Console.WriteLine("\n");
                Console.WriteLine("Integrante agregado exitosamente");
                break;

            case "2":

                Console.WriteLine("Integrantes actuales del equipo: ");

                for(int i = 0; i < idea.Equipos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {idea.Equipos[i].Nombre} " +
                        $"{idea.Equipos[i].Apellidos}");
                }

                Console.Write("Ingrese el número del integrante que desea eliminar: ");
                int integranteAEliminar = int.Parse( Console.ReadLine()) - 1;

                if ( integranteAEliminar >= 0 && integranteAEliminar < idea.Equipos.Count)
                {
                    idea.Equipos.RemoveAt(integranteAEliminar);
                    Console.WriteLine("Integrante eliminado exitosamente");
           
                }
                else
                {
                    Console.WriteLine("Número del integrante invalido");
                }
                break;

            default:
                Console.WriteLine("Opción no valida");
                break;

        }
    }

    static void ModificarValores(List<IdeaNegocio> ideasDeNegocio)
    {
        Console.Write("Ingrese el código de la idea de negocio que desea cambiar los " +
            "valores: ");
        string codigoIdea = Console.ReadLine();

        var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigoIdea);

        if ( idea == null)
        {
            Console.WriteLine("No se encontró esa ide de negocio");
            return;
        }
        Console.Write("Ingrese nuevo valor de inversión: ");
        idea.Inversion = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el nuevo total de ingresos en los primeros 3 años: ");
        idea.Ingresos = double.Parse(Console.ReadLine());

        Console.WriteLine("Valores cambiados exitosamente");

    }

    static void MostrarIdeaMayorIngreso(List<IdeaNegocio> ideasDeNegocio)
    {
        var idea = ideasDeNegocio.OrderByDescending(i => i.Ingresos).FirstOrDefault();

        if ( idea != null)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Idea con mayor total de ingresos en 3 años: ");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"Código: {idea.Codigo}");
            Console.WriteLine($"Nombre: {idea.Nombre}");
            Console.WriteLine($"Impacto: {idea.ImpactoSocial}");
            Console.WriteLine($"Departamentos beneficiados");
            foreach (var departamentos in idea.Departamentos)
            {
                Console.WriteLine($" Nombre: {departamentos.Nombre}, " +
                    $"Código: {departamentos.Codigo}");
            }
            Console.WriteLine($"Valor de inversión {idea.Inversion}");
            Console.WriteLine($"Total de ingresos en 3 años: {idea.Ingresos}");
            Console.WriteLine("Integrantes del equipo:");
            foreach (var integrante in idea.Equipos)
            {
                Console.WriteLine($" Identificación: {integrante.Identificacion}, " +
                    $"Nombre: {integrante.Nombre} {integrante.Apellidos}, " +
                    $"Rol: {integrante.Rol}, Email: {integrante.Email}");
            }

            Console.WriteLine($"Herramientas de la 4RI utilizadas: {idea.Herramientas4RI}");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("No hay ideas de negocio registradas");
            Console.WriteLine("");
        }
    }

    static void MostrarIdeaMasDepartamentos(List<IdeaNegocio> ideasDeNegocio)
    {
        var numDepartamentos = 
            ideasDeNegocio.OrderByDescending(i => i.Departamentos.Count).FirstOrDefault();

        if ( numDepartamentos != null)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Idea con más departamentos: ");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"Código: {numDepartamentos.Codigo}");
            Console.WriteLine($"Nombre: {numDepartamentos.Nombre}");
            Console.WriteLine($"Impacto: {numDepartamentos.ImpactoSocial}");
            Console.WriteLine($"Departamentos beneficiados");
            foreach (var departamentos in numDepartamentos.Departamentos)
            {
                Console.WriteLine($" Nombre: {departamentos.Nombre}, " +
                    $"Código: {departamentos.Codigo}");
            }
            Console.WriteLine($"Valor de inversión {numDepartamentos.Inversion}");
            Console.WriteLine($"Total de ingresos en 3 años: {numDepartamentos.Ingresos}");
            Console.WriteLine("Integrantes del equipo:");
            foreach (var integrante in numDepartamentos.Equipos)
            {
                Console.WriteLine($" Identificación: {integrante.Identificacion}, " +
                    $"Nombre: {integrante.Nombre} {integrante.Apellidos}, " +
                    $"Rol: {integrante.Rol}, Email: {integrante.Email}");
            }

            Console.WriteLine($"Herramientas de la 4RI utilizadas: " +
                $"{numDepartamentos.Herramientas4RI}");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("No hay ideas de negocio registradas");
            Console.WriteLine("");
        }
    }

    static void TresMasRentables(List<IdeaNegocio> ideasDeNegocio)
    {
        var ideasRentables = ideasDeNegocio.OrderByDescending(i => i.Ingresos).Take(3);
        if (ideasRentables.Any())
        {
            Console.WriteLine("Estas son las 3 ideas de negocio más rentables:");
            foreach (var idea in ideasRentables)
            {
                Console.WriteLine($"Nombre: {idea.Nombre}");
                Console.WriteLine($"Total de ingresos en 3 años: {idea.Ingresos}");
                Console.WriteLine("---------------------------------------------");
                
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("No hay ideas de negocio ingresadas");
            Console.WriteLine("");
        }
    }



    static void SumaTotalIngresos(List<IdeaNegocio> ideasDeNegocio)
    {
        if (ideasDeNegocio.Any())
        {
            double sumaIngresos = ideasDeNegocio.Sum(i => i.Ingresos);
            Console.WriteLine($"Los ingresos totales de todas " +
                $"las ideas de negocio son: {sumaIngresos}");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("No hay ideas de negocio ingresadas");
            Console.WriteLine("");

        }
    }

    static void SumaTotalInversion(List<IdeaNegocio> ideasDeNegocio)
    {
        if (ideasDeNegocio.Any())
        {

            double sumaInversion = ideasDeNegocio.Sum(i => i.Inversion);
            Console.WriteLine($"Suma total de las inversiones " +
                $"que se deben hacer: {sumaInversion}");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("No hay ideas de negocio ingresadas");
            Console.WriteLine("");
        }

    }




}

class IdeaNegocio
{
    public string Codigo { get; set; }
    public string Nombre { get; set;}
    public string ImpactoSocial { get; set;}
    public List<Departamento> Departamentos { get; set; } = new List<Departamento>();
    public double Inversion { get; set; }
    public double Ingresos { get; set; }
    public List<IntegrantesEquipo> Equipos { get; set; } = new List<IntegrantesEquipo>();
    public string Herramientas4RI { get; set; }

}
class Departamento
{
    public String Nombre { get; set; }
    public String Codigo { get; set; }

}
class IntegrantesEquipo
{
    public String Identificacion { get; set;}
    public String Nombre { get; set;}
    public String Apellidos { get; set;}
    public String Rol { get; set;}
    public String Email { get; set;}

}