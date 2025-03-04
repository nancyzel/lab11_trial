namespace lab10_LibraryControlElements
{
    public class Button: ControlElement, IInit, ICloneable
    {
        /// <summary>
        /// варианты текста на кнопке (при инициализации с помощью Random)
        /// </summary>
        private static string[] variantsButtonText = { "OK", "Yes", "No", "Agree", "Cancel", "Decline", "Read more" };
        /// <summary>
        /// текст на кнопке
        /// </summary>
        protected string buttonText;

        /// <summary>
        /// свойство для поля buttonText
        /// </summary>
        public string ButtonText
        {
            get => buttonText;
            set => buttonText = value;
        }

        /// <summary>
        /// конструктор для создания экземпляра класса Button через идентификатор и текст кнопки
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор кнопки</param>
        /// <param name="currentButtonText">задаваемый текст на кнопке</param>
        public Button(int currentElementIdentificator, string currentButtonText) : base(currentElementIdentificator)
        {
            ButtonText = currentButtonText;
        }

        /// <summary>
        /// конструктор для создания экземпляра класса Button через идентификатор, абсциссу и ординату кнопки, текст кнопки
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">задаваемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">задаваемая ордината</param>
        /// <param name="currentButtonText">задаваемый текст на кнопке</param>
        public Button(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement, string? currentButtonText): base(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement)
        {
            ButtonText = currentButtonText;
        }
        /// <summary>
        /// конструктор для создания экземпляра класса Button без параметров
        /// </summary>
        public Button() : base()
        {
            ButtonText = "Click";
        }

        /// <summary>
        /// виртуальный метод для возврата значений атрибутов экземпляра класса Button
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        override public string ShowControlElementAttributesVirtual()
        {
            return $"Кнопка с идентификатором {ElementIdentificator} \nрасположена по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement};\nтекст кнопки: \"{ButtonText}\".";
        }

        /// <summary>
        /// обычный метод для вывода значений атрибутов экземпляра класса Button
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        public new string ShowControlElementAttributes()
        {
            return $"Кнопка с идентификатором {ElementIdentificator} \nрасположена по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement};\nтекст кнопки: \"{ButtonText}\".";
        }

        /// <summary>
        /// обычный метод для возврата значений атрибутов экземпляра класса Button
        /// </summary>
        /// <param name="currentElementIdentificator">возвращаемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">возвращаемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">возвращаемая ордината</param>
        /// <param name="currentButtonText">возвращаемый текст на кнопке</param>
        public void GetControlElementAttributes(out int currentElementIdentificator, out double currentAbscissElementPlacement, out double currentOrdinateElementPlacement, out string currentButtonText)
        {
            base.GetControlElementAttributes(out currentElementIdentificator, out currentAbscissElementPlacement, out currentOrdinateElementPlacement);
            currentButtonText = ButtonText;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса через клавиатуру
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public Button InitializeButtonUsingKeyboard(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement, string currentButtonText)
        {
            Button newButton = new Button(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement, currentButtonText);
            return newButton;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public Button InitializeButtonUsingRandom()
        {
            string alphabetRandom = "abcdefghijklmnopqrstuvwxyz";
            int randomButtonTextLength = 10;
            string randomButtonText = "";
            for (int i = 0; i < randomButtonTextLength; i++)
            {
                // Случайное определение индекса буквы в алфавите
                int x = randomNumber.Next(26);
                // Добавление символа по указанному индексу в случайную строку
                randomButtonText = randomButtonText + alphabetRandom[x];
            }
            Button newButton = new Button(randomNumber.Next(0, 100000), randomNumber.Next(-10000, 10000) / (double)100, randomNumber.Next(-10000, 10000) / (double)100, randomButtonText);
            return newButton;
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с клавиатуры
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Введите строку - текст кнопки:");
            ButtonText = Console.ReadLine();
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        public override void InitializeUsingRandom()
        {
            base.InitializeUsingRandom();
            ButtonText = variantsButtonText[randomNumber.Next(variantsButtonText.Length)];
        }

        /// <summary>
        /// виртуальный метод класса Object для вывода экземпляра класса через консоль
        /// </summary>
        /// <returns>строка для вывода экземпляра класса</returns>
        public override string ToString()
        {
            return base.ToString() + ", текст кнопки: \"" + this.ButtonText + "\"";
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
            if (checkedObject is Button checkedButton)
            {
                return checkedButton.ElementIdentificator == this.ElementIdentificator
                    && Math.Abs(checkedButton.AbscissElementPlacement - this.AbscissElementPlacement) <= maximumDifference
                    && Math.Abs(checkedButton.OrdinateElementPlacement - this.OrdinateElementPlacement) <= maximumDifference
                    && checkedButton.ButtonText == this.ButtonText;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^ButtonText.GetHashCode();
        }

        /// <summary>
        /// метод для глубокого копирования объекта
        /// </summary>
        /// <returns>копия экземпляра класса типа object</returns>
        public override object Clone()
        {
            return new Button(this.ElementIdentificator, this.AbscissElementPlacement, this.OrdinateElementPlacement, this.ButtonText);
        }
    }
}
