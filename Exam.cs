namespace LAB1
{
    class Exam: IDateAndCopy
    {
        //Определение свойств класса Exam, доступных для чтения и записи
        public string Exams { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        //Создание конструктора Exam с заданными параметрами для инициализации всех полей класса
        public Exam(string Exams, int Mark, DateTime Date)
        {
            this.Exams = Exams;
            this.Mark = Mark;
            this.Date = Date;
        }
        //Создание конструктора Exam без параметров со значениями по умолчанию
        public Exam(): this("OOP",5,new DateTime(2022,11,2,12,0,0))
        { }
        //Определение перегруженной версии To String()
        //Позволяет нам вывести экзамен, оценку и дату экзамена
        public override string ToString()
        {
            return "Exam : " + Exams + "\tMark: " + Mark.ToString() + "\tDate: " + Date.ToString("h:mm d-MM-yyyy");
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Exam objPerson = obj as Exam;
            if (obj as Exam == null)
            { return false; }
            return objPerson.Exams == Exams && objPerson.Mark == Mark && objPerson.Date == Date;
        }
        //Определим операции == и !=. Критерии, по которым проверяется равенство объектов Equals используем при проверке равенства объектов в операциях
        //== и !=
        public static bool operator ==(Exam leftperson, Exam rightperson)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(leftperson, rightperson))
            { return true; }
            if ((object)leftperson == null || (object)rightperson == null)
            { return false; }
            return leftperson.Exams == rightperson.Exams && leftperson.Mark == rightperson.Mark && leftperson.Date == rightperson.Date;
        }
        public static bool operator !=(Exam leftperson, Exam rightperson)
        {
            return !(leftperson == rightperson);
        }
        public override int GetHashCode()
        {
            return Exams.GetHashCode() + Mark.GetHashCode() + Date.GetHashCode();
        }

        public object DeepCopy()
        {
            return new Exam(Exams, Mark, Date);
        }
        //определим интерфейс IDateAndCopy
        DateTime IDateAndCopy.Date { get; set; }
    }
}