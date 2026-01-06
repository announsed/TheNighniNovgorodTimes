using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    // Интерфейс для общего доступа к любому Id
    public interface IId
    {
        uint Id { get;}
    }


    // Класс для получения всяких коллекций
    internal static class Dictionarys
    {

        // Метод для получения всех элементов
        public static Dictionary<string, Dictionary<uint, object>> GetAllData(DataContext context)
        {
            return new Dictionary<string, Dictionary<uint, object>>() 
            {
                ["Users"] = ToDictionary(context.Users),
                ["Readers"] = ToDictionary(context.Readers),
                ["Writers"] = ToDictionary(context.Writers),
                ["Posts"] = ToDictionary(context.Posts),
                ["Roles"] = ToDictionary(context.Roles),
                ["Admins"] = ToDictionary(context.Admins)
            };
        }


        // метод для получения коллекции из любой таблицы
        private static Dictionary<uint, object> ToDictionary<T>(DbSet<T> table)
        where T : class, IId
        {
            return table.ToDictionary(index => index.Id, entityTable => (object)entityTable);
        }
    }
}
