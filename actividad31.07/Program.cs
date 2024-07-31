using System;
using System.Collections.Generic;

class Biblioteca
{
    List<Receta> recetas = new List<Receta>();

    public void Agregar(string nombre)
    {
        recetas.Add(new Receta(nombre));
        Console.WriteLine("Producto agregado al inventario.");
    }

    public void Disponibles()
    {
        Console.Clear();
        foreach (var receta in recetas)
        {
            receta.Info();
            Console.WriteLine();
        }
    }

    public void Resumen(string nombre)
    {
        var producto = recetas.Find(p => p.Nombre.ToLower() == nombre.ToLower());
        if (producto != null)
        {
            producto.Info();
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
}

class Receta
{
    public string Nombre { get; set; }

    public Receta(string nombre)
    {
        Nombre = nombre;
    }

    public void Info()
    {
        Console.WriteLine($"Receta: {Nombre}");
    }
}

class Program
{
    static void Menu()
    {
        Biblioteca biblioteca = new Biblioteca();
        do
        {
            Console.WriteLine("Bienvenido, seleccione una opción");
            Console.WriteLine("1. Agregar una receta");
            Console.WriteLine("2. Buscar receta por nombre");
            Console.WriteLine("3. Mostrar todas las recetas");
            Console.WriteLine("4. Salir");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ingrese la receta que desea agregar:");
                    string nombre = Console.ReadLine();
                    biblioteca.Agregar(nombre);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre de la receta que desea buscar:");
                    string nombreBuscar = Console.ReadLine();
                    biblioteca.Resumen(nombreBuscar);
                    break;
                case 3:
                    Console.Clear();
                    biblioteca.Disponibles();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Programa terminado. ¡Gracias!");
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
        while (true);
    }

    static void Main(string[] args)
    {
        Menu();
    }
}