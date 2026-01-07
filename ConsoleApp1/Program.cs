using ConsoleApp1;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// Созданиие тестовых обьектов
List<Role> roles = new List<Role>()
{
    new Role(1, Roles.Писатель)
};
List<User> users = new List<User>()
{
    new User(1, "Виктор", "j67o09gw0", roles[0]),
    new User(2, "Андрей", "lewakw0", roles[0]),
    new User(3, "Иван", "numbersone", roles[0])
};
List<Post> posts = new List<Post>()
{
    new Post(1, "Это самый первый пост на платформе", "Тут интро...", DateTime.Now, users[1], roles[0])
};
List<Reader> readers = new List<Reader>()
{
    new Reader(1,users[0], posts[0]),
    new Reader(2,users[2], posts[0]),
};
List<Writer> writers = new List<Writer>()
{
    new Writer(1,users[1], posts[0])
};
List<Admin> admins = new List<Admin>()
{
    new Admin(1, null)
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
    var allData = Dictionaries.GetAllData(dataContext);


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
            if (identy.Value is User user)
            {
                Console.WriteLine($" Тут выводится юзер:  {user.Id}");
            }
            else if (identy.Value is Reader readers1) 
            {
                Console.WriteLine($" Тут выводится читатель:  {readers1.Id}");
            }
            else if (identy.Value is Writer writers1)
            {
                Console.WriteLine($" Тут выводится писатель:  {writers1.Id}");
            }
            else if (identy.Value is Post posts1)
            {
                Console.WriteLine($" Тут выводится пост:  {posts1.Id}");
            }
            else if (identy.Value is Role roles1)
            {
                Console.WriteLine($" Тут выводится роль:  {roles1.Id}");
            }
            else if (identy.Value is Admin admins1)
            {
                Console.WriteLine($" Тут выводится админ:  {admins1.Id}");
            }
        }
    }
}