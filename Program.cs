namespace Practica1_GestorCalificaciones;

internal class Program
{
    private static readonly GestorCalificaciones Gestor = new();

    private static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "1":
                    RegistrarEstudiante();
                    break;
                case "2":
                    AgregarCalificacion();
                    break;
                case "3":
                    MostrarEstudiantes();
                    break;
                case "4":
                    ConsultarEstudiante();
                    break;
                case "5":
                    salir = true;
                    Console.WriteLine("Hasta luego.");
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Seleccione un numero del 1 al 5.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine();
            }
        }
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("=== Gestor de calificaciones ===");
        Console.WriteLine("1. Registrar estudiante");
        Console.WriteLine("2. Agregar calificacion");
        Console.WriteLine("3. Mostrar todos los estudiantes");
        Console.WriteLine("4. Consultar un estudiante");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opcion: ");
    }

    private static void RegistrarEstudiante()
    {
        string matricula = LeerTexto("Matricula: ");
        string nombre = LeerTexto("Nombre: ");

        if (Gestor.RegistrarEstudiante(matricula, nombre))
        {
            Console.WriteLine("Estudiante registrado correctamente.");
        }
        else
        {
            Console.WriteLine("No se pudo registrar: esa matricula ya existe.");
        }
    }

    private static void AgregarCalificacion()
    {
        string matricula = LeerTexto("Matricula del estudiante: ");
        Estudiante? estudiante = Gestor.BuscarEstudiante(matricula);

        if (estudiante is null)
        {
            Console.WriteLine("No existe un estudiante con esa matricula.");
            return;
        }

        while (true)
        {
            Console.Write("Calificacion (0 a 100): ");
            string entrada = Console.ReadLine() ?? string.Empty;

            if (decimal.TryParse(entrada, out decimal calificacion) &&
                estudiante.AgregarCalificacion(calificacion))
            {
                Console.WriteLine("Calificacion agregada.");
                return;
            }

            Console.WriteLine("Valor no valido. Escriba un numero entre 0 y 100.");
        }
    }

    private static void MostrarEstudiantes()
    {
        IReadOnlyList<Estudiante> estudiantes = Gestor.ObtenerEstudiantes();

        if (estudiantes.Count == 0)
        {
            Console.WriteLine("Todavia no hay estudiantes registrados.");
            return;
        }

        foreach (Estudiante estudiante in estudiantes)
        {
            MostrarDatosEstudiante(estudiante);
        }
    }

    private static void ConsultarEstudiante()
    {
        string matricula = LeerTexto("Matricula del estudiante: ");
        Estudiante? estudiante = Gestor.BuscarEstudiante(matricula);

        if (estudiante is null)
        {
            Console.WriteLine("No existe un estudiante con esa matricula.");
            return;
        }

        MostrarDatosEstudiante(estudiante);
    }

    private static void MostrarDatosEstudiante(Estudiante estudiante)
    {
        decimal? promedio = estudiante.ObtenerPromedio();

        if (promedio is null)
        {
            Console.WriteLine(
                $"Matricula: {estudiante.Matricula} | Nombre: {estudiante.Nombre} | Sin calificaciones");
            return;
        }

        string estado = promedio >= 70 ? "Aprobado" : "Reprobado";
        Console.WriteLine(
            $"Matricula: {estudiante.Matricula} | Nombre: {estudiante.Nombre} | " +
            $"Promedio: {promedio.Value:F2} | Estado: {estado}");
    }

    private static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Trim();
            }

            Console.WriteLine("Este dato no puede quedar vacio.");
        }
    }
}
