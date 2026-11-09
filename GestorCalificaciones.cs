namespace Practica1_GestorCalificaciones;

public class GestorCalificaciones
{
    private readonly List<Estudiante> _estudiantes = new();

    public bool RegistrarEstudiante(string matricula, string nombre)
    {
        if (string.IsNullOrWhiteSpace(matricula) ||
            string.IsNullOrWhiteSpace(nombre) ||
            BuscarEstudiante(matricula) is not null)
        {
            return false;
        }

        _estudiantes.Add(new Estudiante(matricula, nombre));
        return true;
    }

    public Estudiante? BuscarEstudiante(string matricula)
    {
        foreach (Estudiante estudiante in _estudiantes)
        {
            if (estudiante.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase))
            {
                return estudiante;
            }
        }

        return null;
    }

    public IReadOnlyList<Estudiante> ObtenerEstudiantes()
    {
        return _estudiantes.AsReadOnly();
    }
}
