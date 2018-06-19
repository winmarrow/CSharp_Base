using System;
using System.Collections.Generic;
using L_2_4.Task1;
using L_2_4.Task2;
using L_2_4.Task3;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleColor();
            CH.SetConsoleOutputEncoding();

            TaskOne();
            CH.WriteSeparator();
            CH.WriteSeparator();
            TaskTwo();
            CH.WriteSeparator();
            CH.WriteSeparator();
            TaskThree();

            Console.ReadKey();
        }

        static void
            TaskOne() //Тут я тупо не мог ппонять задание, то ли нужна сортировка, а может выборка -Ю налепил лишних методов
        {
            // TODO Задача 1 Делегаты и методы
            /*
             1. Объявить делегат для работы с выборками.
             2. Создать метод, в классе каталог, позволяющий делать выборки из каталога.
             3. Создать класс BookSorter и объявить в нём методы необходимые для 
                выполнения задач по сортировке книг
             3. Вывести в консоль книги написанные до 85ого года. Передав статический метод и BookSorter-a
             4. Вывести книги написаны в названии которых есть слово "мир"
             */
            var catalog = new Catalog();
            catalog.Books = new List<Book>()
            {
                // TODO Добавить книги
                new Book() {Title = "Book 1 About eat", DoP = new DateTime(1984, 1, 1)},
                new Book() {Title = "Book 2 About our little world", DoP = new DateTime(1983, 1, 1)},
                new Book() {Title = "Book 3 About cars", DoP = new DateTime(1988, 1, 1)},
                new Book() {Title = "Book 4 Around the world in One tick", DoP = new DateTime(1999, 1, 1)},
            };

            var booksBefore85Year = catalog.SelectBooks(BookSorter.IsBookBefore85Year);
            foreach (var book in booksBefore85Year)
                Console.WriteLine(book);

            CH.WriteSeparator();

            var booksWithWordWorld = catalog.SelectBooks(BookSorter.IsContainsWordWoldInTitle);
            foreach (var book in booksWithWordWorld)
                Console.WriteLine(book);
        }

        static void TaskTwo()
        {
            // TODO Задача 2 Делегаты и анонимные методы и/или лямбда выражения
            /* 
             1. Объявить делегаты для работы со студентами
             2. Создать метод, в классе группа, позволяющий сортировать студентов.
             3. Создать метод, в классе группа, предоставляющий возможность выполнить действие
                с приватной коллекцией студентов.
             4. Используя метод из пункта 2, отсортировать студентов по средней оценке
             5. Используя метод из пункта 3, всем студентам с оценкой от 4 до 6 добавить 1 балл.
             */

            const string studentTemplate = "{0} {1} - Avg mark: {2}";

            var group = new Group(new Student[]
            {
                new Student(),
                new Student(),
                new Student(),
                new Student(),
                new Student(),
                new Student(),
                new Student(),
            });

            group.Sort((student1, student2) => (int) (student1.AvgMark - student2.AvgMark));

            group.DoSomethingWith(
                student => true,
                student => Console.WriteLine(studentTemplate, student.FirstName, student.LastName, student.AvgMark));

            CH.WriteSeparator();

            group.DoSomethingWith(
                student => student.AvgMark >= 4 && student.AvgMark <= 6,
                student =>
                {
                    Console.Write(studentTemplate, student.FirstName, student.LastName, student.AvgMark);
                    student.AddToMark(1);
                    Console.Write(" -> ");
                    Console.WriteLine(studentTemplate, student.FirstName, student.LastName, student.AvgMark);
                });
        }

        static void TaskThree()
        {
            // TODO Задача 3* Func, Action + =>
            // В задаче нельзя объявлять делегаты
            /*
             1. Создать методы расширения для класса CarPark:
                а. Производит выборку из внутренней коллекции используя передаваемую функцию
                б. Производит сортировку внутренней коллекции используя передаваемую функцию
             2. Создать внутреннее свойство в классе CarPark для хранение действия.
             3. Вызывать это действие при добавлении новой машины в парк:
                 => Как вариант выводить в консоль информацию о машине 
                 Console: Toyota RAV4 was added to the park. It costs ... $. 
             */

            const string carTempolate = " {0} - {1} Price: {2}";

            var group = new CarPark()
            {
                AddNewCarAction = (car) =>
                {
                    Console.WriteLine($"- {car.Brand} {car.Model} was added to the park. It costs {car.Price} $");
                },
                Cars = new List<Car>()
                {
                    // TODO add cars
                    new FuelCar()
                    {
                        Brand = "Brand 1",
                        Model = "Model A",
                        Price = 12000m,
                        ReleasedYead = 1990,
                        TankSize = 100
                    },
                    new FuelCar()
                    {
                        Brand = "Brand 2",
                        Model = "Model A",
                        Price = 1200m,
                        ReleasedYead = 1990,
                        TankSize = 100
                    },
                    new FuelCar()
                    {
                        Brand = "Brand 3",
                        Model = "Model A",
                        Price = 15000m,
                        ReleasedYead = 1990,
                        TankSize = 100
                    },
                    new FuelCar()
                    {
                        Brand = "Brand 1",
                        Model = "Model A",
                        Price = 23400m,
                        ReleasedYead = 1990,
                        TankSize = 100
                    },
                }
            };
            //Before sort
            foreach (var car in group.Cars)
                Console.WriteLine(carTempolate, car.Brand, car.Model, car.Price);

            CH.WriteSeparator();

            group.SortCars((car1, car2) => (int) (car1.Price - car2.Price));
            //After sort
            foreach (var car in group.Cars)
                Console.WriteLine(carTempolate, car.Brand, car.Model, car.Price);

            CH.WriteSeparator();

            var brand1Cars = group.SelectCars(car => car.Brand == "Brand 1");
            //Selected
            foreach (var car in brand1Cars)
                Console.WriteLine(carTempolate, car.Brand, car.Model, car.Price);
        }
    }
}