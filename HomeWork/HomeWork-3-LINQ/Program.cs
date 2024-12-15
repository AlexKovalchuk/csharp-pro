namespace HomeWork_3_LINQ;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Home Work 3: LINQ exercises");
        
        List<string> listOfNames = new List<string>
        {
            "Abba", "Bobby", "Adam", "Aharon", "Akiva (Akiba)", "Alexander", "Aron", "Arik", "Oren", "Ore", "Arel",
            "Arele", "Orel", "Arke", "Orke", "Arush", "Orush", "Arushka", "Arushke", "Leib", "Leibel", "Leibele",
            "Leibish", "Leibush", "Lev", "Levke", "Aryeh", "Ari", "Arik", "Artze", "Artzi", "Arke", "Arel",
            "Lavi", "Raphael", "Ehud", "Eitan", "Moshe", "Avigal", "Yael", "Noah", "Daniel", "Rovoam", "Elisabeth",
            "Oleksander", "Ihor", "John", "Zorovavel", "Raphael", "Ruvim", "Zavulon"
        };
        
        // 1. Написати програму на C#, яка отримує набір рядків зі словами та фільтрує лише ті,
        // які починаються з літери "A". Вивести результат на екран.
        Console.WriteLine("-----------------1-----------------");
        List<string> names = (from stringItem in listOfNames
                where stringItem[0] == 'A'
                select stringItem)
            .ToList();
        foreach (var aWord in names)
        {
            Console.WriteLine($"Starts from A: {aWord}");
        }
        
        // 2. Створити два масиви цілих чисел різної довжини. Використовуючи LINQ,
        // знайти всі значення, які містяться в обох масивах та відобразити їх на екран.
        Console.WriteLine("-----------------2-----------------");
        List<string> arrayA = new List<string>
        {
            "Abba", "Bobby", "Adam", "Aharon", "Akiva (Akiba)", "Alexander", "Aron", "Arik", "Oren", "Ore", "Arel",
            "Arele", "Orel", "Arke", "Orke", "Arush", "Artzi", "Arke", "Arel",
            "Lavi", "Raphael", "Ehud", "Eitan", "Moshe", "Avigal", "Yael", "Noah", "Daniel", "Rovoam", "Elisabeth",
            "Oleksander", "Ihor", "John", "Zorovavel", "Raphael", "Ruvim", "Zavulon"
        };
        List<string> arrayB = new List<string>
        {
            "Leibele",
            "Leibish", "Leibush", "Lev", "Levke", "Aryeh", "Ari", "Arik", "Artze", "Artzi", "Arke", "Arel",
            "Lavi", "Raphael", "Ehud", "Eitan", "Moshe", "Avigal", "Yael", "Noah", "Daniel", "Rovoam", "Elisabeth",
            "Oleksander", "Ihor", "John", "Zorovavel", "Raphael", "Ruvim", "Zavulon"
        };
        var intersects = arrayA.Intersect(arrayB).ToList();
        foreach (var inter in intersects)
        {
            Console.WriteLine($"Intersect values between two Lists: {inter}");
        }
        
        // 3. Написати програму, яка створює колекцію об'єктів класу Student, в яких є поля "Ім'я", "Прізвище" та "Оцінка".
        // Використовуючи LINQ, знайти студента з максимальною оцінкою та вивести його на екран.
        Console.WriteLine("-----------------3-----------------");
        List<Student> students = new List<Student>();
        var random = new Random();
        for (int i = 0; i < listOfNames.Count; i++)
        {
            var nameIndex = random.Next(listOfNames.Count);
            var name = listOfNames[nameIndex];

            var surnameIndex = random.Next(listOfNames.Count);
            var surname = listOfNames[surnameIndex];

            var score = Math.Round(random.NextDouble() * 5, 2);
            students.Add(new Student(name, surname, score));
        }
        var bestStudent = students.MaxBy(st => st.Score);
        Console.WriteLine($"Best Student: {bestStudent?.Name} {bestStudent?.Surname}, score = {bestStudent?.Score}");

        foreach (var st in students)
        {
            Console.WriteLine($"Student: {st.Name} {st.Surname}, score = {st.Score}");
        }
        
        // 4. Створити колекцію об'єктів класу Product, в яких є поля "Назва", "Ціна" та "Категорія".
        // Використовуючи LINQ, згрупувати продукти за категорією та обчислити середню ціну кожної категорії.
        Console.WriteLine("-----------------4-----------------");
        string[] pTitles = new []{"jacket", "trauses", "t-short", "hat", "cap", "socks", "shorts", "sweter", "jeense", "coat"};
        string[] pCategory = new []{"summer", "demiseason", "winter"};
        List<Product> products = new List<Product>();
        for (int i = 0; i < listOfNames.Count; i++)
        {
            var titleIndex = random.Next(pTitles.Length);
            var title = pTitles[titleIndex];

            var categoryIndex = random.Next(pCategory.Length);
            var category = pCategory[categoryIndex];
            int maxPrice = 100;
            int numbersAfterDot = 2;
            var price = Math.Round(random.NextDouble() * maxPrice, numbersAfterDot);
            products.Add(new Product(title, category, price));
            Console.WriteLine($"{products[i].Title} {products[i].Price}, {products[i].Category}");
        }
        // Group by category and calculate average price per category
        var averagePricePerCategory = products
            .GroupBy(p => p.Category)
            .Select(grp => new 
            { 
                Category = grp.Key, 
                AveragePrice = grp.Average(p => p.Price) 
            })
            .ToList();

        // Display average prices by category
        foreach (var categoryAvg in averagePricePerCategory)
        {
            Console.WriteLine($"Average price for {categoryAvg.Category}: {categoryAvg.AveragePrice}");
        }
        
        // 5. Створити колекцію об'єктів класу Employee, в яких є поля "Ім'я", "Прізвище",
        //  "Дата народження" та "Дата працевлаштування". Використовуючи LINQ, знайти робітників,
        //  які працюють в компанії більше 5 років.
        Console.WriteLine("-----------------5-----------------");
        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < listOfNames.Count; i++)
        {
            var employeeIndex = random.Next(arrayA.Count);
            var name = arrayA[employeeIndex];

            var surnameIndex = random.Next(arrayB.Count);
            var surname = arrayB[surnameIndex];
            DateTime birthday = DateGenerator.GenerateRandomDate(18, 81);
            DateTime employedDate = DateGenerator.GenerateRandomDate(1, 21);

            employees.Add(new Employee(name, surname, birthday, employedDate));
        }
        DateTime fiveYearsAgo = DateTime.Today.AddYears(-5);
        Console.WriteLine($"First year ago: {fiveYearsAgo.Year}");
        var seniorEmployees = (from emp in employees
                where emp.EmployedDate <= fiveYearsAgo
                select emp
            ).ToList();
        foreach(var senior in seniorEmployees){
            Console.WriteLine($"Senior: {senior.Name} {senior.Surname} birthday {senior.Birthday.Day}:{senior.Birthday.Month}:{senior.Birthday.Year}, employed date {senior.EmployedDate.Day}:{senior.EmployedDate.Month}:{senior.EmployedDate.Year}");
        }
        
        // 6. Створити колекцію об'єктів класу Book, в яких є поля "Назва", "Автор", "Рік видання" та "Жанр".
        // Використовуючи LINQ, знайти книги, які були видані після 2010 року та належать до жанру "Фантастика".
        Console.WriteLine("-----------------6-----------------");
        string[] bookTitles = new[] { "Lord of the Rings 1", "Lord of the Rings 2", "Lord of the Rings 3", "Hobbit", "Baren and Luthien", "Unfinished Tales of Numenor", "Dune 1", "Dune 2", "Dune 3", "Dune 4", "Dune 5", "TIch and pure father", "5 languages of love", "7 skills of extra efficient people", "power of self confident", "path of samurai", "Love of God", "Kalvin biik", "Basic Theology", "War of words", "History of German", "History of England", "History of Ukraine"};
        string[] genreList = new[] {"Fantasy", "History", "Non fiction", "Fantastic", "Adventure"};
        List<Book> books = new List<Book>();

        for (int i = 0; i < listOfNames.Count; i++)
        {
            var titleIndex = random.Next(bookTitles.Length);
            var title = bookTitles[titleIndex];

            var genreIndex = random.Next(genreList.Length);
            var genre = genreList[genreIndex];

            var employeeIndex = random.Next(arrayA.Count);
            var name = arrayA[employeeIndex];

            var surnameIndex = random.Next(arrayB.Count);
            var surname = arrayB[surnameIndex];
            DateTime promotionDate = DateGenerator.GenerateRandomDate(1, 121);
            books.Add(new Book(title, $"{name} {surname}", genre, promotionDate));
            Console.WriteLine($"Title: {books[i].Title}, Author: {books[i].Author}, Genre: {books[i].Genre}, Promotion Year: {books[i].PromotionDate.Year}");
        }
        var booksYoungerThan2010 = books.Where(b => b is { Genre: "Fantastic", PromotionDate.Year: > 2010 }).ToList();
        Console.WriteLine("--------Next will be books that are younger than 2010 year-------");

        foreach (var book in booksYoungerThan2010)
        {
            Console.WriteLine($"{book.Title} {book.Author} {book.Genre} {book.PromotionDate.Year}");
        }
        
        // 7. Створити колекцію об'єктів класу Customer, в яких є поля "Ім'я", "Прізвище", "Адреса" та "Замовлення".
        // Використовуючи LINQ, знайти клієнтів, які зробили замовлення на суму
        // більше 1000 грн та вивести їх замовлення у вигляді переліку.
        Console.WriteLine("-----------------6-----------------");
        List<Customer> customers = new List<Customer>();
        for (int i = 0; i < listOfNames.Count; i++)
        {
            var titleIndex = random.Next(bookTitles.Length);
            var title = bookTitles[titleIndex];

            var employeeIndex = random.Next(arrayA.Count);
            var name = arrayA[employeeIndex];

            var surnameIndex = random.Next(arrayB.Count);
            var surname = arrayB[surnameIndex];

            DateTime orderDate = DateGenerator.GenerateRandomDate(0, 3);

            customers.Add(new Customer(name, surname, "some address of the customer", GenerateProducts(), title));
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Name} {customer.Surname} {customer.Address}");
            Console.WriteLine($"Order title = {customer.Order.Title} Order date: {customer.Order.OrderDate} {customer.Order.Title}");
            Console.WriteLine($"TotalPrice: {customer.Order.TotalPrice}");
        }

        var expensiveOrderPrice = 1000;
        var richClients = customers.Where(c => c.Order.TotalPrice > expensiveOrderPrice).Select(c => new { c.Name, c.Order });
        Console.WriteLine("------------------Rich Clients--------------------");
        foreach (var rich in richClients)
        {
            Console.WriteLine($"Customer: {rich.Name}, Order Title {rich.Order.Title}, Order Price:{rich.Order.TotalPrice}");
        }
    }
    
    static List<Product> GenerateProducts()
    {
        var random = new Random();
        string[] pTitles = new []{"jacket", "trauses", "t-short", "hat", "cap", "socks", "shorts", "sweter", "jeense", "coat"};
        string[] pCategory = new []{"summer", "demiseason", "winter"};
        List<Product> products = new List<Product>();
        var titleIndex = random.Next(pTitles.Length);
        var title = pTitles[titleIndex];

        var categoryIndex = random.Next(pCategory.Length);
        var category = pCategory[categoryIndex];
        int maxPrice = 5000;
        int numbersAfterDot = 2;
        var price = Math.Round(random.NextDouble() * maxPrice, numbersAfterDot);
        products.Add(new Product(title, category, price));

        return products;
    }
    
}