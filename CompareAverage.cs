using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    //определим вспомогательный класс, который будем использовать для сравнения объектов типа Student по среднему баллу
    class CompareAverage : IComparer<Student>
    {
        //через CompareTo будем сравнивать среднюю оценку у двух объектов
        public int Compare(Student? x, Student? y)
        {
            return x.AverageMark.CompareTo(y.AverageMark);
        }
    }
}
