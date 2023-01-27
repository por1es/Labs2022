using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LAB1
{
    class TestCollections
    {
        //Определяем поля типа Test, string, (Test, Student), (string, Student)
        //Опрелеяем два list и два dictionary
        List<Test> ListOfTest = new List<Test>();
        List<string> ListOfString = new List<string>();
        Dictionary<Test, Student> DictionaryOfTestAndStudent = new Dictionary<Test, Student>();
        Dictionary<string, Student> DictionaryOfStringAndStudent = new Dictionary<string, Student>();
        public static Student GenerateElement(int value)
        {
            Student a = new Student();
            a.NumberOfGroup = value;
            return a;
        }
        //создадим конструктор с параметром int для создания коллекции с заданным числом элементов
        public TestCollections(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                ListOfTest.Add(new Test());
                DictionaryOfTestAndStudent.Add(new Test(), new Student());
                ListOfString.Add(" ");
                DictionaryOfStringAndStudent.Add(" ", new Student());
            }
        }
        //метод, вычисляющий время поиска элемента
        public void TimeOfSearching()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var temp = ListOfTest.Contains(ListOfTest[0]);
            temp = ListOfTest.Contains(ListOfTest[ListOfTest.Count / 2]);
            temp = ListOfTest.Contains(ListOfTest[ListOfTest.Count - 1]);
            stopwatch.Stop();
            Console.WriteLine($"Time to find element in List<Person>: {stopwatch.Elapsed}");
            var first = DictionaryOfTestAndStudent.First();
            Test key = first.Key;
            var middle = DictionaryOfTestAndStudent.ElementAt(DictionaryOfTestAndStudent.Count / 2);
            Test keymiddle = middle.Key;
            var last = DictionaryOfTestAndStudent.Last();
            Test keylast = last.Key;
            var first1 = DictionaryOfStringAndStudent.First();
            Student key1 = first1.Value;
            var middle1 = DictionaryOfStringAndStudent.ElementAt(DictionaryOfStringAndStudent.Count / 2);
            Student keymiddle1 = middle1.Value;
            var last1 = DictionaryOfStringAndStudent.Last();
            Student keylast1 = last1.Value;
            //Dictionary<string, Student> val = first.Value;
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            var temp1 = DictionaryOfTestAndStudent.ContainsKey(key);
            temp1 = DictionaryOfTestAndStudent.ContainsKey(keymiddle);
            temp1 = DictionaryOfTestAndStudent.ContainsKey(keylast);
            stopwatch1.Stop();
            Console.WriteLine($"Time to find element in Dictionary<Team, Person>: {stopwatch1.Elapsed}");
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var temp2 = DictionaryOfStringAndStudent.ContainsValue(key1);
            temp2 = DictionaryOfStringAndStudent.ContainsValue(keymiddle1);
            temp2 = DictionaryOfStringAndStudent.ContainsValue(keylast1);
            stopwatch2.Stop();
            Console.WriteLine($"Time to find element in Dictionary<string,Person>: {stopwatch2.Elapsed}");

        }
    }
}
