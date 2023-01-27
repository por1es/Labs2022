using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    class StudentCollection
    {
        //создадим закрытое поле типа List<Student>, в котором будет хранится информация о студентах
        List<Student> students = new List<Student>();
        //создадим метод AddDefaults, с помощью которого будем добавлять элементы типа Student для инициализации по умолчанию
        public void AddDefaults()
        {
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student());
            }
        }
        //создадим метод AddStudents для добавления студентов в список
        public void AddStudents(params Student[] studentss)
        {
            students.AddRange(studentss);
        }
        //создадим перегруженную версию метода ToString() для формирования информации обо всех элементах списка List<Student>, включающий значения
        //всех полей, списко зачетов и экзаменов
        public override string ToString()
        {
            string StudentString = "";
            foreach (Student student in students)
            {
                StudentString += student.ToString();
            }
            return StudentString;
        }
        //создадим перегруженную версию метода ToShortString() для формирования информации обо всех элементах списка List<Student>, включающий значения
        //всех полей, средний балл, число зачетов и экзаменов, но без списка зачетов и экзаменов
        public string ToShortString()
        {
            string StudentString = "";
            foreach (Student student in students)
            {
                StudentString += student.ToShortString();
            }
            return StudentString;
        }
        //определим метод, который сортирует значения списка List<Student> по фамилиям с помощью IComparable
        public void SortBySurname()
        {
            for (int i = 0; i < students.Count-1; i++)
            {
                for (int j = 0; j < students.Count-1; j++) 
                    if (students[j].Information.CompareTo(students[j + 1].Information) > 0) 
                    {
                        (students[j+1], students[j]) = (students[j], students[j+1]); 
                    }
            }
        }
        //определим метод, который сортирует значения списка List<Student> по датам рождения с помощью IComparer
        public void SortByBirthDate()
        {
            for (int i = 0; i < students.Count - 1; i++)
                for (int j = 0; j < students.Count - 1; j++)
                    if (students[j].Compare(students[j].Information, students[j + 1].Information) > 0)
                    {
                        (students[j + 1], students[j]) = (students[j], students[j + 1]);
                    }
        }
        //определим метод, который сортирует значения списка List<Student> по среднему баллу с помощью IComparer
        public void SortByAverageScore()
        {
            CompareAverage comparer = new();
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - 1; j++)
                    if (comparer.Compare(students[i], students[i + 1]) > 0)
                    {
                        (students[i + 1], students[i]) = (students[i], students[i + 1]);
                    }
            }
        }
        //определим свойство типа double, возвращаемое максимальное значение среднего балла
        public double MaxAverageMark
        {
            get
            {
                if (students.Count == 0)
                {
                    return 0;
                }
                return students.Max(students => students.AverageMark);
            }
        }
        //определим свойство типа IEnumerable, возвращающее подмножество элементов с формой обучения Specialist
        public IEnumerable<Student> Specialist
        { 
            get
            {
                IEnumerable<Student> AllSpecialists = students.Where(education => education.Formofstudy == Education.Specialist);
                return AllSpecialists;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < students.Count; i++)
            {
                yield return students[i];
            }
        }
        //определим метод AverageMarkGroup, который возвращает список тех элементов с заданным значением среднего балла
        public List<Student> AverageMarkGroup(double value)
        {
            IEnumerable<IGrouping<double, Student>> someGroup = students.GroupBy(team => team.AverageMark);

            foreach (IGrouping<double, Student> teams in someGroup)
            {
                if (teams.Key == value)
                {
                    return teams.ToList();
                }
            }
            return null;
        }
    }
}
