using System.Collections;

namespace LAB1
{
    //класс Student определим как производный от класса Person
    class Student: Person, IDateAndCopy
    {
        //Определение закрытых полей типов для хранения данных о студенте, включая ранее объявленные значения Person и Exam
        Person _Info;
        Education _Formofstudy;
        int _numberOfGroup;
        Exam[] Exams;
        Test _test;
        //создадим два поля типа ArrayList, в которых хранятся список зачетов (Tests) и экзаменов (Examens)
        //ArrayList Tests = new ArrayList();
        //ArrayList Examens = new ArrayList();
        List<Test> tests = new List<Test>();
        List<Exam> exams = new List<Exam>();
        //public ArrayList ListOfStudents { get { return Tests; } set { Tests = value; } }
        //public ArrayList ListOfExamens{ get { return Examens; } set { Examens = value; } }
        //Создание конструктора Student с заданными параметрами для инициализации всех полей класса
        public Student (Person info, Education formofstudy, int numberofgroup)
        {
            _Info = info;
            _Formofstudy = formofstudy;
            _numberOfGroup = numberofgroup;
            //Создаем пустой массив, который будем заполнять экзаменами
            //Tests = new ArrayList();
            //Examens = new ArrayList();
            tests = new List<Test> ();
            exams = new List<Exam> ();
        }
        //Создание конструктора Student без параметров со значениями по умолчанию
        public Student() : this(new Person(), Education.SecondEducation, 1)
        { }
        //Определение свойств с методами get и set для для доступа к закрытым полям
        public Person Information
        {
            get { return _Info; }
            set { _Info = value;}
        }

        public Education Formofstudy
        {
            get { return _Formofstudy;}
            set { _Formofstudy = value;}
        }
        //добавим исключение, которое будет срабатывать, если мы попытаемся ввести номер группы меньше 100 и больше 599
        public int NumberOfGroup
        {
            get { return _numberOfGroup; }
            set
            {
                if (value <=100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Error! Number of group is out of range (100;599");
                }
            }
        }
        public Exam[] getExams
        {
            get { return Exams;}
            set { Exams = value;}
        }
        public Test Test
        {
            get { return _test; }
            set { _test = value; }
        }
        //Определение свойства типа double для вычисления среднего значения оценок в списке сданных экзаменов путем
        //деления суммы оценок на кол-во экзаменов
        public double AverageMark
        {
            get
            {
                int sum = 0;
                foreach (Exam Exams in exams)
                {
                    sum = sum + Exams.Mark;
                }
                //Делим сумму наших оценок на количество экзаменов
                return (double) sum / exams.Count();
            }
        }
        //Создаем индексатор булевского типа, который показывает - совпадает ли значения из поля с формой обучения со значением
        //индекса если да - true, если нет - false
        public bool this [Education Education]
        {
            get { return Education == _Formofstudy; }
        }
        //Создаем метод, позволяющий нам добавлять экзамены в наш созданный ранее массив
        public void AddExams(Exam Examss)
        {
            exams.Add(Examss);
            //Examens.Add(Examss);
        }
        public void AddTests(Test _test)
        {
            tests.Add(_test);
            //Tests.Add(_test);
        }
        //Определение перегруженной версии To String()
        //Позволяет нам вывести информацию про студента, форму обучения и номер группы
        public override string ToString()
        {
            foreach (Exam getexams in exams)
            {
                Console.WriteLine(getexams.ToString());
            }
            foreach (Test test in tests)
            {
                Console.WriteLine(test.ToString());
            }
            return "\nStudent : " + _Info + "  Education : " + _Formofstudy + "  NumberOfGroup : " + NumberOfGroup;
        }
        //Определение виртуального метода ToShortString()
        //Позволяет нам вывестм информацию про студента, форму обучения, номер группы и среднюю оценку
        public string ToShortString()
        {
            return "\nStudent : " + _Info + "  Education :" + _Formofstudy + "  NumberOfGroup :" + NumberOfGroup.ToString()
                + "  Avg. Mark : " + AverageMark.ToString();
        }
        //определим метод DeepCopy, который будет копировать информацию про студента 
        /*public object DeepCopy()
        {
            Student CopyStudent = new Student(this.Information, this.Formofstudy, this.NumberOfGroup);
            CopyStudent.ListOfStudents = ListOfStudents;
            CopyStudent.ListOfExamens = ListOfExamens;
            return CopyStudent;
        }*/
        public bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Student objStudent = obj as Student;
            if (obj as Person == null)
            { return false; }
            return objStudent.Information == _Info && objStudent.Formofstudy== _Formofstudy && objStudent.NumberOfGroup == _numberOfGroup && objStudent.Exams == Exams && objStudent.Test == _test;
        }
        //Определим операции == и !=. Критерии, по которым проверяется равенство объектов Equals используем при проверке равенства объектов в операциях
        //== и !=
        public static bool operator ==(Student leftperson, Student rightperson)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(leftperson, rightperson))
            { return true; }
            if ((object)leftperson == null || (object)rightperson == null)
            { return false; }
            return leftperson._Info == rightperson._Info && leftperson.NumberOfGroup == rightperson.NumberOfGroup && leftperson.Formofstudy == rightperson.Formofstudy && leftperson.Exams == rightperson.Exams && leftperson.tests == rightperson.tests;
        }
        public static bool operator !=(Student leftperson, Student rightperson)
        {
            return !(leftperson == rightperson);
        }
        public override int GetHashCode()
        {
            return _Info.GetHashCode() + NumberOfGroup.GetHashCode() + Formofstudy.GetHashCode() + Exams.GetHashCode() + tests.GetHashCode();
        }
        //Определим итератор для последовательного перебора всех элементов (экзаменов и зачетов)
        public IEnumerable GetResults()
        {
            foreach (var exam in exams)
                yield return exam;
            foreach (var test in tests)
                yield return test;
        }
        //Опеределим итератор для перебора  экзаменов с оценкой, выше заданной
        public IEnumerable ExamsOver(int minRate)
        {
            foreach (var exam in exams)
            {
                Exam ex = (Exam)exam;
                if (ex.Mark > minRate)
                    yield return exam;
            }
        }
    }
}