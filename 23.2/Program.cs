using System;
using System.Collections.Generic;

public class CacheSystem
{
    static void Main()
    { }
    private static CacheSystem instance;
    private Dictionary<string, List<object>> cache;

    private CacheSystem()
    {
        cache = new Dictionary<string, List<object>>();
    }

    public static CacheSystem GetInstance()
    {
        if (instance == null)
        {
            instance = new CacheSystem();
        }
        return instance;
    }

    public void RegisterEntityType(string entityType) //Зарегистрировать тип объекта
    {
        if (!cache.ContainsKey(entityType))
        {
            cache.Add(entityType, new List<object>());
            Console.WriteLine($"Тип объекта '{entityType}' зарегистрирован.");
        }
        else
        {
            Console.WriteLine($"Тип объекта '{entityType}'уже зарегистрирован.");
        }
    }

    public void AddEntity(string entityType, object entity) //Добавить объект
    {
        if (cache.ContainsKey(entityType))
        {
            cache[entityType].Add(entity);
            Console.WriteLine("Объект успешно добавлен.");
        }
        else
        {
            Console.WriteLine($"Тип объекта '{entityType}' не зарегистрирован. Пожалуйста, сначала зарегистрируйте его.");
        }
    }

    public bool CheckEntityExistence(string entityType, object entity) //Проверить существование объекта
    {
        return cache.ContainsKey(entityType) && cache[entityType].Contains(entity);
    }

    public bool CheckEntityTypeExistence(string entityType) //Проверьте наличие типа объекта
    {
        return cache.ContainsKey(entityType);
    }

    public void RemoveEntity(string entityType, object entity) //Удалить объект
    {
        if (cache.ContainsKey(entityType))
        {
            cache[entityType].Remove(entity);
            Console.WriteLine("Объект успешно удален.");
        }
        else
        {
            Console.WriteLine($"Тип объекта '{entityType}' не зарегистрирован. Не удается удалить объект.");
        }
    }

    public void RemoveEntityType(string entityType) //Удалить тип объекта
    {
        if (cache.ContainsKey(entityType))
        {
            cache.Remove(entityType);
            Console.WriteLine($"Тип объекта '{entityType}' и все связанные объекты удаляются из кэша.");
        }
        else
        {
            Console.WriteLine($"Тип объекта '{entityType}' не зарегистрирован. Не удается удалить тип объекта.");
        }
    }
}