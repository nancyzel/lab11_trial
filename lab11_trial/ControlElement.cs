namespace lab10_LibraryControlElements
{
    public class ControlElement: IInit, IComparable<ControlElement>, ICloneable
    {
        /// <summary>
        /// ДСЧ для инициализации объекта со случайными значениями в параметрах
        /// </summary>
        protected static Random randomNumber = new Random();
        /// <summary>
        /// id элемента контроля
        /// </summary>
        protected int elementIdentificator;
        /// <summary>
        /// абсцисса координат расположения элемента контроля
        /// </summary>
        protected double abscissElementPlacement;
        /// <summary>
        /// ордината координат расположения элемента контроля
        /// </summary>
        protected double ordinateElementPlacement;

        /// <summary>
        /// свойство для поля elementIdentificator
        /// </summary>
        public int ElementIdentificator
        {
            get => elementIdentificator;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Исключение: идентификатор элемента контроля не может быть отрицательным числом.");
                }
                else
                {
                    elementIdentificator = value;
                }
            }
        }

        /// <summary>
        /// свойство для поля abscissElementPlacement
        /// </summary>
        public double AbscissElementPlacement
        {
            get => abscissElementPlacement;
            set => abscissElementPlacement = value;
        }

        /// <summary>
        /// свойство для поля ordinateElementPlacement
        /// </summary>
        public double OrdinateElementPlacement
        {
            get => ordinateElementPlacement;
            set => ordinateElementPlacement = value;
        }

        /// <summary>
        /// конструктор класса ControlElement по идентификатору, абсциссе и ординате
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">задаваемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">задаваемая ордината</param>
        public ControlElement(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement)
        {
            this.ElementIdentificator = currentElementIdentificator;
            this.AbscissElementPlacement = currentAbscissElementPlacement;
            this.OrdinateElementPlacement = currentOrdinateElementPlacement;
        }

        /// <summary>
        /// конструктор класса ControlElement по идентификатору
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор</param>
        public ControlElement(int currentElementIdentificator) : this(currentElementIdentificator, 0, 0) 
        { }

        /// <summary>
        /// конструктор класса ControlElement без параметров
        /// </summary>
        public ControlElement() : this(0, 0, 0)
        { }

        /// <summary>
        /// виртуальный метод для вывода значений атрибутов экземпляра класса ControlElement
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        virtual public string ShowControlElementAttributesVirtual ()
        {
            return $"Элемент контроля с идентификатором {ElementIdentificator} \nрасположен по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement}.";
        }

        /// <summary>
        /// обычный метод для вывода значений атрибутов экземпляра класса ControlElement
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        public string ShowControlElementAttributes()
        {
            return $"Элемент контроля с идентификатором {ElementIdentificator} \nрасположен по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement}.";
        }

        /// <summary>
        /// обычный метод для возврата значений атрибутов экземпляра класса ControlElement
        /// </summary>
        /// <param name="currentElementIdentificator">возвращаемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">возвращаемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">возвращаемая ордината</param>
        public void GetControlElementAttributes(out int currentElementIdentificator, out double currentAbscissElementPlacement, out double currentOrdinateElementPlacement)
        {
            currentElementIdentificator = ElementIdentificator;
            currentAbscissElementPlacement = AbscissElementPlacement;
            currentOrdinateElementPlacement = OrdinateElementPlacement;
        }
        
        /// <summary>
        /// метод для инициализации экземпляра класса через клавиатуру
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public ControlElement InitializeControlElementUsingKeyboard(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement)
        {
            ControlElement newControlElement = new ControlElement(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement);
            return newControlElement;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public ControlElement InitializeControlElementUsingRandom()
        {
            ControlElement newControlElement = new ControlElement(randomNumber.Next(0, 1000), randomNumber.Next(-10000, 10000) / (double)100, randomNumber.Next(-10000, 10000) / (double)100);
            return newControlElement;
        }
        
        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с клавиатуры
        /// </summary>
        public virtual void Initialize()
        {
            Console.WriteLine("Введите целое неотрицательное число - идентификатор элемента контроля:");
            ElementIdentificator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вещественное число - абсциссу координаты расположения элемента контроля:");
            AbscissElementPlacement = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите вещественное число - ординату координаты расположения элемента контроля:");
            OrdinateElementPlacement = Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        public virtual void InitializeUsingRandom()
        {
            ElementIdentificator = randomNumber.Next(0, 1000);
            AbscissElementPlacement = randomNumber.Next(-10000, 10000) / (double)100;
            OrdinateElementPlacement = randomNumber.Next(-10000, 10000) / (double)100;
        }

        /// <summary>
        /// виртуальный метод класса Object для вывода экземпляра класса через консоль
        /// </summary>
        /// <returns>строка для вывода экземпляра класса</returns>
        public override string ToString()
        {
            return "Идентификатор: " + this.ElementIdentificator.ToString()
                + ", абсцисса местоположения: " + this.AbscissElementPlacement.ToString()
                + ", ордината местоположения: " + this.OrdinateElementPlacement.ToString();
        }

        /// <summary>
        /// метод для сравнения двух экземпляров класса
        /// </summary>
        /// <param name="otherControlElement">экземпляр класса, с которым сравнивают объект</param>
        /// <returns>-1 --> первый объект меньше второго; 0 --> объекты равны; 1 --> первый объект больше второго</returns>
        public virtual int CompareTo(ControlElement? otherControlElement)
        {
            if (otherControlElement == null)
            {
                return -1;
            }
            return ElementIdentificator.CompareTo(otherControlElement.ElementIdentificator);
        }

        /// <summary>
        /// метод для сравнения двух экземпляров класса
        /// </summary>
        /// <param name="checkedObject">объект, с которым сравнивают текущий экземпляр класса</param>
        /// <returns>истинность факта, что экземпляры класса равны между собой</returns>
        public override bool Equals(object? checkedObject)
        {
            double maximumDifference = 0.0001;
            if (checkedObject == null)
            {
                return false;
            }
            if (checkedObject is ControlElement checkedControlElement)
            {
                return checkedControlElement.ElementIdentificator == this.ElementIdentificator
                    && Math.Abs(checkedControlElement.AbscissElementPlacement - this.AbscissElementPlacement) <= maximumDifference
                    && Math.Abs(checkedControlElement.OrdinateElementPlacement - this.OrdinateElementPlacement) <= maximumDifference;            
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ElementIdentificator.GetHashCode()^AbscissElementPlacement.GetHashCode()^OrdinateElementPlacement.GetHashCode();
        }

        /// <summary>
        /// метод для глубокого копирования объекта
        /// </summary>
        /// <returns>копия экземпляра класса типа object</returns>
        public virtual object Clone()
        {
            return new ControlElement(this.ElementIdentificator, this.AbscissElementPlacement, this.OrdinateElementPlacement);
        }

        /// <summary>
        /// метод для поверхностного копирования объекта
        /// </summary>
        /// <returns>копия экземпляра класса типа object</returns>
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
