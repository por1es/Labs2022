namespace LAB1
{
    class Person: IDateAndCopy, IComparable<Person>, IComparer<Person>
    {
        //Объявление protected (можем обращаться к ниму из нашего или насследуемых классов) полей имени, фамилии и даты рождения
        protected string _Name;
        protected string _Surname;
        protected DateTime _BDate;
        //Определение конструктора Person с тремя параметрами: Имени, Фамилии и Даты рождения
        public Person(string StudentName, string StudentSurname, DateTime StudentBDate)
        {
            _Name = StudentName;
            _Surname = StudentSurname;
            _BDate = StudentBDate;
        }
        //Определение конструктора Person без параметров со значениями по умолчанию
        public Person() : this("DefName", "DefSurname", new DateTime(2003, 05, 21))
        { }
        //Определение свойств с методами get (действия при получении значения) и set (действия при установке значения)
        //для доступа к вышеобъявленным полям
        public string StudName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string StudSurname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }
        public DateTime StudBdate
        { 
            get { return _BDate; } 
            set { _BDate = value; }
        }
        public int intStudBDate
        {
            get { return Convert.ToInt32(_BDate); }
            set { _BDate = Convert.ToDateTime(value); } 
        }
        //public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //Определение перегруженной версии To String(), которой мы перезаписываем нашу стандартную ф-ию
        //Позволяет вывести нам фамилию, имя и дату рождения
        public override string ToString()
        {
            return string.Format("{0} {1}\nDate of birth: {2}", _Name, _Surname, _BDate);
        }
        //Определение виртуального метода ToShortString()
        //Позволяет нам вывестм имя и фамилию
        public string ToShortString()
        {
            return string.Format("{0} {1}", _Name, _Surname);
        }
        //переопределяем метод bool Equals, который определяет равенство объектов как равенство ссылок на объекты 
        //в классе System.String этот метод переопределен таким образом, что равными считаются строки, которые совпадают посимвольно
        //в работе требуется переопределить метод Equals так, чтобы объекты считались равными, если равны все данные объекты
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Person objPerson = obj as Person;
            if (obj as Person == null)
            { return false;}
            return objPerson.StudName == _Name && objPerson.StudSurname == _Surname && objPerson.StudBdate == _BDate;
        }
        //Определим операции == и !=. Критерии, по которым проверяется равенство объектов Equals используем при проверке равенства объектов в операциях
        //== и !=
        public static bool operator ==(Person leftperson, Person rightperson)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(leftperson, rightperson))
            { return true; }
            if ((object)leftperson == null || (object)rightperson == null)
            { return false; }
            return leftperson.StudName == rightperson.StudName && leftperson.StudSurname == rightperson.StudSurname && leftperson.StudBdate == rightperson.StudBdate;
        }
        public static bool operator !=(Person leftperson, Person rightperson)
        {
            return !(leftperson == rightperson);
        }
        public override int GetHashCode()
        {
            return StudName.GetHashCode() + StudSurname.GetHashCode() + StudBdate.GetHashCode();
        }
        //Метод для создания полной копии объекта полной копии объекта. Метод DeepCopy должен создать полные копии всех объектов, ссылки на которые
        //содержат поля тип. Должен создать как копии элементов коллекции ArrayList, так и полные копии объектов, на которые ссылаются элементы коллекции
        public object DeepCopy()
        {
            Person personcopy = new Person(this.StudName,this.StudSurname,this.StudBdate);
            return personcopy;
        }
        //Добавляем реализацию IComparable для сравнения объектов типа Person по полю с фамилией
        public int CompareTo(Person? other)
        { 
           return this.StudSurname.CompareTo(other.StudSurname);
        }
        //Добавляем реализацию IComparer для сравнения объектов типа Person по дате рождения
        public int Compare(Person? x, Person? y)
        {
            return x.StudBdate.CompareTo(y.StudBdate);
        }

        DateTime IDateAndCopy.Date { get; set; }
    }
}