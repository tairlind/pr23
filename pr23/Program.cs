using System;

class Program
{
    static void Main()
    {
        CacheSystem cache = CacheSystem.GetInstance();

        cache.RegisterEntityType("Человек");
        cache.AddEntity("Человек", new { Name = "Alice", Age = 30 });

        bool exists = cache.CheckEntityExistence("Человек", new { Name = "Alice", Age = 30 });
        Console.WriteLine($"Объект существует в кэше: {exists}");

        cache.RemoveEntity("Человек", new { Name = "Alice", Age = 30 });

        cache.RemoveEntityType("Человек");

        bool typeExists = cache.CheckEntityTypeExistence("Человек");
        Console.WriteLine($"Тип объекта существует в кэше: {typeExists}");

        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }
}
