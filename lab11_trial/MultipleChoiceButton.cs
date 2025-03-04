namespace lab10_LibraryControlElements
{
    public class MultipleChoiceButton : ControlElement, IInit, ICloneable
    {
        /// <summary>
        /// показатель, является ли кнопка нажатой (выбрана или нет)
        /// </summary>
        protected bool isTicked;
        /// <summary>
        /// свойство для поля isTicked
        /// </summary>
        public bool IsTicked
        {
            get => isTicked;
            set => isTicked = value;
        }

        /// <summary>
        /// конструктор для создания экземпляра класса MultipleChoiceButton через идентификатор и значение чекбокса
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор кнопки</param>
        /// <param name="isCurrentlyTicked">задаваемое значение (выбрана/не выбрана)</param>
        public MultipleChoiceButton(int currentElementIdentificator, bool isCurrentlyTicked) : base(currentElementIdentificator)
        {
            IsTicked = isCurrentlyTicked;
        }

        /// <summary>
        /// конструктор для создания экземпляра класса MultipleChoiceButton через идентификатор, абсциссу и ординату кнопки, значение чекбокса
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">задаваемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">задаваемая ордината</param>
        /// <param name="currentButtonText">задаваемый текст на кнопке</param>
        public MultipleChoiceButton(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement, bool isCurrentlyTicked) : base(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement)
        {
            IsTicked = isCurrentlyTicked;
        }
        /// <summary>
        /// конструктор для создания экземпляра класса MultipleChoiceButton без параметров
        /// </summary>
        public MultipleChoiceButton() : base()
        {
            IsTicked = false;
        }

        /// <summary>
        /// виртуальный метод для возврата значений атрибутов экземпляра класса MultipleChoiceButton
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        override public string ShowControlElementAttributesVirtual()
        {
            return $"Кнопка множественного выбора с идентификатором {ElementIdentificator} \nрасположена по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement};\nкнопка{String.Join("", Enumerable.Repeat(" не", IsTicked ? 0 : 1))} является нажатой.";
        }

        /// <summary>
        /// обычный метод для вывода значений атрибутов экземпляра класса MultipleChoiceButton
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        public new string ShowControlElementAttributes()
        {
            return $"Кнопка множественного выбора с идентификатором {ElementIdentificator} \nрасположена по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement};\nкнопка{String.Join("", Enumerable.Repeat(" не", IsTicked ? 0 : 1))} является нажатой.";
        }

        /// <summary>
        /// обычный метод для возврата значений атрибутов экземпляра класса MultipleChoiceButton
        /// </summary>
        /// <param name="currentElementIdentificator">возвращаемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">возвращаемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">возвращаемая ордината</param>
        /// <param name="isCurrentlyTicked">возвращаемое значение чекбокса</param>
        public void GetControlElementAttributes(out int currentElementIdentificator, out double currentAbscissElementPlacement, out double currentOrdinateElementPlacement, out bool isCurrentlyTicked)
        {
            base.GetControlElementAttributes(out currentElementIdentificator, out currentAbscissElementPlacement, out currentOrdinateElementPlacement);
            isCurrentlyTicked = IsTicked;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса через клавиатуру
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public MultipleChoiceButton InitializeMultipleChoiceButtonUsingKeyboard(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement, bool currentButtonText)
        {
            MultipleChoiceButton newMultipleChoiceButton = new MultipleChoiceButton(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement, currentButtonText);
            return newMultipleChoiceButton;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public MultipleChoiceButton InitializeMultipleChoiceButtonUsingRandom()
        {
            MultipleChoiceButton newMultipleChoiceButton = new MultipleChoiceButton(randomNumber.Next(0, 100000), randomNumber.Next(-10000, 10000) / (double)100, randomNumber.Next(-10000, 10000) / (double)100, randomNumber.Next(2) == 0);
            return newMultipleChoiceButton;
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с клавиатуры
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Введите, является ли кнопка выбранной (если да, введите \"true\", иначе \"false\"):");
            IsTicked = Convert.ToBoolean(Console.ReadLine());
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        public override void InitializeUsingRandom()
        {
            base.InitializeUsingRandom();
            IsTicked = randomNumber.Next(2) == 0;
        }

        /// <summary>
        /// виртуальный метод класса Object для вывода экземпляра класса через консоль
        /// </summary>
        /// <returns>строка для вывода экземпляра класса</returns>
        public override string ToString()
        {
            return base.ToString() + ", кнопка множественного выбора" + String.Join("", Enumerable.Repeat(" не", this.IsTicked ? 0 : 1)) + " нажата";
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
            if (checkedObject is MultipleChoiceButton checkedMultipleChoiceButton)
            {
                return checkedMultipleChoiceButton.ElementIdentificator == this.ElementIdentificator
                    && Math.Abs(checkedMultipleChoiceButton.AbscissElementPlacement - this.AbscissElementPlacement) <= maximumDifference
                    && Math.Abs(checkedMultipleChoiceButton.OrdinateElementPlacement - this.OrdinateElementPlacement) <= maximumDifference
                    && checkedMultipleChoiceButton.IsTicked == this.IsTicked;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^IsTicked.GetHashCode();
        }

        /// <summary>
        /// метод для глубокого копирования объекта
        /// </summary>
        /// <returns>копия экземпляра класса типа object</returns>
        public override object Clone()
        {
            return new MultipleChoiceButton(this.ElementIdentificator, this.AbscissElementPlacement, this.OrdinateElementPlacement, this.IsTicked);
        }
    }
}
