using ConsoleApp1;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// Созданиие тестовых обьектов
List<Roles> roles = new List<Roles>()
{
    new Roles(1, null,null, null)
};
List<Posts> posts = new List<Posts>()
{
    new Posts(1, "Это самый первый пост на платформе", DateTime.Now, roles[0])
};
List<Users> users = new List<Users>()
{
    new Users(1, "Виктор", "j67o09gw0", roles[0]),
    new Users(2, "Андрей", "lewakw0", roles[0]),
    new Users(3, "Иван", "numbersone", roles[0])
};
List<Readers> readers = new List<Readers>()
{
    new Readers(1,users[0], posts[0]),
    new Readers(2,users[2], posts[0]),
};
List<Writers> writers = new List<Writers>()
{
    new Writers(1,users[1], posts[0])
};
List<Admins> admins = new List<Admins>()
{
    new Admins(1, null)
};


// тестовая сущность в виде обьекта базы данных
using (DataContext dataContext = new DataContext(DatabaseType.Sqlite)) 
{
    dataContext.AddRange(roles);
    dataContext.AddRange(users);
    dataContext.AddRange(posts);
    dataContext.AddRange(writers);
    dataContext.AddRange(admins);
    dataContext.AddRange(readers);

    dataContext.SaveChanges();


    // получаем все что можно получить из базы одним статическим методом (возможно плохо, что метод статический я не знаю, уточнить)
    var allData = Dictionarys.GetAllData(dataContext);


    // выводим все это дело из базы, должно все работать, наверное, а может нет
    foreach (var table in allData) 
    {
        Console.WriteLine("\n");
        Console.WriteLine($" Таблица: {table.Key}");
        Console.WriteLine($" Записей: {table.Value.Count}");
        foreach (var identy in table.Value) 
        {
            Console.WriteLine($" Ключ словаря: {identy.Key} \n Значение словаря: {identy.Value}");


            // НЕ ПУБЛИЧНЫЕ СВОЙСТВА У ОБЬЕКТОВ, НИЧЕГО НЕ МОГУ ВЫВЕСТИ КРОМЕ ID, НАДО ЧТО-ТО С ЭТИМ ДЕЛАТЬ
            if (identy.Value is Users user)
            {
                Console.WriteLine($" Тут выводится юзер:  {user.Id}");
            }
            else if (identy.Value is Readers readers1) 
            {
                Console.WriteLine($" Тут выводится читатель:  {readers1.Id}");
            }
            else if (identy.Value is Writers writers1)
            {
                Console.WriteLine($" Тут выводится писатель:  {writers1.Id}");
            }
            else if (identy.Value is Posts posts1)
            {
                Console.WriteLine($" Тут выводится пост:  {posts1.Id}");
            }
            else if (identy.Value is Roles roles1)
            {
                Console.WriteLine($" Тут выводится роль:  {roles1.Id}");
            }
            else if (identy.Value is Admins admins1)
            {
                Console.WriteLine($" Тут выводится админ:  {admins1.Id}");
            }
        }
    }
}