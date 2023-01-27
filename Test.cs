using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    class Test
    {
        //создадим два автореализуемых свойства, доступных для чтения и записи
        string _nameofsubject { get; set; }
        bool _isPassed { get; set; }
        //определим конструктор с параметрами string и bool для инициализации свойств класса
        public Test (string nameofsubject, bool isPassed)
        {
            _nameofsubject = nameofsubject;
            _isPassed = isPassed;
        }
        //определим конструтор с параметрами по умолчанию
        public Test()
        {
            _nameofsubject = "Math";
            _isPassed = true;
        }
        //создадим перегруженную версию ToString(), в котором будем вывод наших параметров (названия предмета и информация, сдан он или нет)
        public override string ToString()
        {
            return "Test: " + _nameofsubject + "\tisPassed? " + _isPassed;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Test objPerson = obj as Test;
            if (obj as Test == null)
            { return false; }
            return objPerson._nameofsubject == _nameofsubject && objPerson._isPassed == _isPassed;
        }
        //Определим операции == и !=. Критерии, по которым проверяется равенство объектов Equals используем при проверке равенства объектов в операциях
        //== и !=
        public static bool operator ==(Test leftperson, Test rightperson)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(leftperson, rightperson))
            { return true; }
            if ((object)leftperson == null || (object)rightperson == null)
            { return false; }
            return leftperson._nameofsubject == rightperson._nameofsubject && leftperson._isPassed == rightperson._isPassed;
        }
        public static bool operator !=(Test leftperson, Test rightperson)
        {
            return !(leftperson == rightperson);
        }
        public override int GetHashCode()
        {
            return _nameofsubject.GetHashCode() + _isPassed.GetHashCode();
        }
    }
}
