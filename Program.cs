using System.Diagnostics;
namespace LAB1
{
    //Определяем тип Education перечислением со значениями
    public enum Education
    {
        Specialist, Bachelor, SecondEducation
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Создание объекта типа Student и вывод данных с помощью ToShortString
            Student student = new Student();
            student.AddExams(new Exam());
            Console.WriteLine(student.ToShortString());
            //Выводим значения индексатора. В моем случае у студента SecondEducation, у первых двух значений будет False,
            //у третьего - True
            Console.WriteLine(string.Format("{0} {1} {2}", student[Education.Specialist], student[Education.Bachelor], student[Education.SecondEducation]));
            //Присванивание значения всем определенным типам в Student свойствам и вывод их с помощью метода ToString()
            student.Information = new Person("Artem", "Freyman", new DateTime(2003, 05, 21));
            student.Formofstudy = Education.Specialist;
            student.NumberOfGroup = 13;
            student.getExams = new Exam[1] { new Exam("Math", 2, new DateTime(2022, 10, 3)) };
            Console.WriteLine(student.ToShortString());
            //Создание нового экзамена и добавление его и стандартного в список наших экзаменов
            Exam[] Exams = new Exam[1] { new Exam("Russian", 5, new DateTime(2022, 10, 4)) };
            student.AddExams(Exams);
            student.AddExams(new Exam());
            //Вывод информации об ученике с помощью метода ToString
            Console.WriteLine(student.ToString());
            Console.WriteLine("Введите количество строк и столбцов. В качестве разделителей используете пробел или запятую: ");
            string data = Console.ReadLine();
            //Ввод количества строк и столбцов наших массивов
            int rows = Convert.ToInt32(data.Split(' ', ',')[0]), columns = Convert.ToInt32(data.Split(' ', ',')[1]);
            //Задание одномерного, двумерного прямоугольного и двумерного ступенчатого массивов
            Exam[] One = new Exam[rows * columns]; 
            Exam[,] TwoSq = new Exam[rows, columns];
            Exam[][] TwoSteps = new Exam[rows][];
            //Считаем время выполнения операций с элементами наших массивов и выводим их
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < rows * columns; i++)
            {
                //Заполняем наш массив экзаменами по умолчанию
                One[i]=new Exam();
                int k = 0;
                while (k<10000)
                {
                    //Присваиваем каждому полю Mark в каждом элементе массива значение 4
                    One[i].Mark= 4;
                    k++;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Одномерный массив: {stopwatch.Elapsed}");
            Console.WriteLine($"Число строк: {rows}");
            //Для двумерного прямоугольного и двумерного ступенчатого массива сделаем аналогично
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            for (int i = 0; i < rows; i++)
            {
                 for (int j = 0; j < columns; j++)
                 {
                     TwoSq[i,j] = new Exam();
                     int k = 0;
                     while (k < 10000)
                     {
                        TwoSq[i,j].Mark = 4;
                        k++;
                     }
                 }
            }
            stopwatch1.Stop();
            Console.WriteLine($"Двумерный прямоугольный массив: {stopwatch1.Elapsed}");
            Console.WriteLine($"Число строк: {rows}. Число столбцов: {columns}");
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            for (int i = 0; i < rows; i++)
            {
                TwoSteps[i] = new Exam[columns];
                for (int j = 0; j < columns; j++)
                {
                    TwoSteps[i][j] = new Exam();
                    int k = 0;
                    while (k < 10000)
                    {
                        TwoSteps[i][j].Mark = 4;
                        k++;
                    }

                }
            }
            stopwatch2.Stop();
            Console.WriteLine($"Двумерный ступенчатый массив: {stopwatch2.Elapsed}");
            Console.WriteLine($"Число строк: {rows}. Число столбцов: {columns}");
        }*/
            //Создадим два типа Person с совпадающими данными и проверим, что ссылки на объекты не равны (будет выдавать false), а объекты равны
            //(будет выдавать true). 
            /*var person1 = new Person("Ivanov", "Ivan", new DateTime(1950, 01, 01));
            var person2 = new Person("Ivanov", "Ivan", new DateTime(1950, 01, 01));
            Console.WriteLine($"Сравнение объектов по ссылке: {ReferenceEquals(person2, person1)}");
            Console.WriteLine($"Сравнение объектов: {person1 == person2}");
            //Выведем хэш значения
            Console.WriteLine("Значение хэша: \n{0}  \n{1}", person1.GetHashCode(), person2.GetHashCode());
            Console.WriteLine();
            Console.WriteLine("Вывод данных объекта типа Student: ");
            //создаем объект типа Student, добавляем в список экзамены и зачеты
            var student = new Student(new Person("Artem", "Freyman", new DateTime(2003, 05, 21)), Education.Specialist, 165);
            student.AddExams(new Exam("OOP", 5, new DateTime(2023, 01, 21)));
            student.AddExams(new Exam("OOP", 2, new DateTime(2023, 01, 21)));
            student.AddTests(new Test("CPP", true));
            student.AddTests(new Test("Math", true));
            student.AddTests(new Test("ObjectOrientedProgramming", true));
            Console.WriteLine(student.ToString());
            Console.WriteLine("Значение свойства типа Person для объекта типа Student: ");
            Console.WriteLine();
            Console.WriteLine(student.Information);
            Console.WriteLine();
            Console.WriteLine("Оригинал и копия объекта типа Student: ");
            //создадим полную копию объекта Student 
            var studentClone = (Student)student.DeepCopy();
            //попытаемся изменить данные, но вывод у нас не поменяется
            student.StudName = "Vadim";
            student.StudSurname = "Yurkin";
            Console.WriteLine(student.ToString());
            Console.WriteLine(studentClone.ToString());
            Console.WriteLine("----------------------------------------------------------");
            //присвоим свойству с номером группы значение, не удовлетворяющие нашему условию (промежуток от 100 до 599) и выведем сообщение,
            //переданное через объект исключение
            try
            {
                student.NumberOfGroup = 600;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------------------");
            //с помощью итератора выведем список всех зачетов и экзаменов
            Console.WriteLine("Список всех экзаменов и зачетов: ");
            foreach (var task in student.GetResults())
                Console.WriteLine(task.ToString());
            Console.WriteLine("----------------------------------------------------------");
            //с помощью итератора выведем те экзамены, у которых оценка выше 3
            Console.WriteLine("Список экзаменов с оценкой выше 3: ");
            foreach (var task in student.ExamsOver(3))
                Console.WriteLine(task.ToString());*/
            //создаем объект типа StudentCollection и добавляем туда несколько различных элементов типа Student 
            StudentCollection studentCollection = new StudentCollection();
            var student1 = new Student(new Person("Artem", "Oreyman", new DateTime(2003, 05, 21)), Education.Specialist, 165);
            student1.AddExams(new Exam("OOP", 5, new DateTime(2022, 01, 21)));
            studentCollection.AddStudents(student1);
            var student2 = new Student(new Person("Artem", "Greyman", new DateTime(2004, 05, 21)), Education.Specialist, 165);
            student2.AddExams(new Exam("Math", 4, new DateTime(2022, 02, 20)));
            studentCollection.AddStudents(student2);
            var student3 = new Student(new Person("Artem", "Popov", new DateTime(2007, 05, 21)), Education.Specialist, 165);
            student3.AddExams(new Exam("Russian", 4, new DateTime(2022, 02, 19)));
            studentCollection.AddStudents(student3);
            var student4 = new Student(new Person("Artem", "Ginsburg", new DateTime(2003, 05, 22)), Education.Bachelor, 165);
            student4.AddExams(new Exam("OOP", 5, new DateTime(2022, 02, 13)));
            student4.AddExams(new Exam("Math", 2, new DateTime(2022, 02, 12)));
            studentCollection.AddStudents(student4);
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine();
            //вызовем сортировку списка по фамилии
            studentCollection.SortBySurname();
            Console.WriteLine("Sorted by Surname");
            Console.WriteLine(studentCollection.ToShortString());
            //вызовем сортировку списка по дате рождения
            studentCollection.SortByBirthDate();
            Console.WriteLine();
            Console.WriteLine("Sorted by BirthDate");
            Console.WriteLine(studentCollection.ToShortString());
            //вызовем сортировку по среднему баллу
            studentCollection.SortByAverageScore();
            Console.WriteLine();
            Console.WriteLine("Sorted by AverageScore");
            Console.WriteLine(studentCollection.ToShortString());
            //вычисляем максимальный балл для элементов из списка
            Console.WriteLine(studentCollection.MaxAverageMark.ToString());
            //запустим фильтрацию списка для отбора студентов с формой обучения Specialist
            Console.WriteLine("Students with form of study Specialist: ");
            foreach (var specialists in studentCollection.Specialist.ToList())
                Console.WriteLine(specialists.ToShortString());
            Console.WriteLine();
            //запустим фильтрайиб списка для отбора студентов по среднему баллу (5,4,3)
            Console.WriteLine("Students with average mark 5: ");
            //studentCollection.AverageMarkGroup(5);
            foreach (var specialists in studentCollection.AverageMarkGroup(5).ToList())
                Console.WriteLine(specialists.ToShortString());
            Console.WriteLine();
            Console.WriteLine("Students with average mark 4: ");
            foreach (var specialists in studentCollection.AverageMarkGroup(4).ToList())
                Console.WriteLine(specialists.ToShortString());
            Console.WriteLine();
            Console.WriteLine("Students with average mark 3.5: ");
            foreach (var specialists in studentCollection.AverageMarkGroup(3.5).ToList())
                Console.WriteLine(specialists.ToShortString());
            TestCollections test = new TestCollections(1);
            test.TimeOfSearching();

        }
    }
}
