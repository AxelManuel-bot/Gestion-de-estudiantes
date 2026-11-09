namespace Practica1_GestorCalificaciones;

public class Estudiante
{
    private readonly List<decimal> _calificaciones = new();

    public string Matricula { get; }
    public string Nombre { get; }
    public IReadOnlyList<decimal> Calificaciones => _calificaciones.AsReadOnly();

    public Estudiante(string matricula, string nombre)
    {
        Matricula = matricula;
        Nombre = nombre;
    }

    public bool AgregarCalificacion(decimal calificacion)
    {
        if (calificacion < 0 || calificacion > 100)
        {
            return false;
        }

        _calificaciones.Add(calificacion);
        return true;
    }

    public decimal? ObtenerPromedio()
    {
        if (_calificaciones.Count == 0)
        {
            return null;
        }

        return _calificaciones.Average();
    }
}
