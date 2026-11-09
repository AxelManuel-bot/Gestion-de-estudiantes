# Gestor de calificaciones

Programa de consola hecho en C# para registrar estudiantes, guardar sus calificaciones y consultar su promedio.

## Requisitos

- .NET 10 SDK

## Ejecutar

Abre una terminal en la carpeta del proyecto y ejecuta:

```powershell
dotnet run
```

## Clases

- `Estudiante`: guarda la matricula, el nombre y una coleccion privada de calificaciones. Tambien valida las notas y calcula el promedio cuando hay calificaciones.
- `GestorCalificaciones`: registra estudiantes, evita matriculas repetidas y permite buscarlos.
- `Program`: muestra el menu, lee las opciones y presenta los resultados.

## Pruebas sugeridas

1. Registra la matricula `001` con el nombre `Ana` y agrega `80` y `90`. Debe mostrar promedio `85.00` y estado `Aprobado`.
2. Registra la matricula `002` con el nombre `Luis` y agrega `50` y `60`. Debe mostrar promedio `55.00` y estado `Reprobado`.
3. Intenta registrar otra vez la matricula `001`.
4. Agrega `120` como calificacion y comprueba que el programa la rechace y vuelva a pedir un valor.
5. Consulta un estudiante antes de agregarle calificaciones.
6. Escribe una opcion que no aparezca en el menu.

## Capturas para la entrega

Toma una captura del menu principal y otra despues de registrar estudiantes y consultar sus promedios. Puedes usar `Windows + Shift + S` para guardar cada captura.
