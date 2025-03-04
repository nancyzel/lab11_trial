namespace lab10_LibraryControlElements
{
    public class TextField: ControlElement, IInit, ICloneable
    {
        /// <summary>
        /// варианты текста в текстовом поле (при инициализации с помощью Random)
        /// </summary>
        private static string[] variantsFieldContents = { "animal", "dog", "book", "film", "video", "soundtrack", "music" };
        /// <summary>
        /// варианты подсказок для текстового поля (при инициализации с помощью Random)
        /// </summary>
        private static string[] variantsHintText = { "domestic animals", "big dog", "old book", "new film", "video cut", "soundtrack from", "pop music" };
        /// <summary>
        /// текст, введенный в поле
        /// </summary>
        protected string fieldContents;
        /// <summary>
        /// текст подсказки
        /// </summary>
        protected string hintText;

        /// <summary>
        /// свойство для поля fieldContents
        /// </summary>
        public string FieldContents
        {
            get => fieldContents;
            set => fieldContents = value;
        }

        public string HintText
        {
            get => hintText;
            set => hintText = value;
        }

        /// <summary>
        /// конструктор для создания экземпляра класса TextField через идентификатор и текст кнопки
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор кнопки</param>
        /// <param name="currentFieldContents">введенный текст</param>
        public TextField(int currentElementIdentificator, string currentFieldContents, string currentHintText) : base(currentElementIdentificator)
        {
            FieldContents = currentFieldContents;
            HintText = currentHintText;
        }

        /// <summary>
        /// конструктор для создания экземпляра класса TextField через идентификатор, абсциссу и ординату кнопки, текст кнопки
        /// </summary>
        /// <param name="currentElementIdentificator">задаваемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">задаваемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">задаваемая ордината</param>
        /// <param name="currentFieldContents">введенный текст</param>
        public TextField(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement, string currentFieldContents, string currentHintText) : base(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement)
        {
            FieldContents = currentFieldContents;
            HintText = currentHintText;
        }
        /// <summary>
        /// конструктор для создания экземпляра класса TextField без параметров
        /// </summary>
        public TextField() : base()
        {
            FieldContents = "Type something";
            HintText = "Start typing to get a hint";
        }

        /// <summary>
        /// виртуальный метод для возврата значений атрибутов экземпляра класса TextField
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        override public string ShowControlElementAttributesVirtual()
        {
            return $"Текстовое поле с идентификатором {ElementIdentificator} \nрасположено по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement};\nтекст, введенный в поле: \"{FieldContents}\", текст подсказки: \"{HintText}\".";
        }

        /// <summary>
        /// обычный метод для вывода значений атрибутов экземпляра класса TextField
        /// </summary>
        /// <returns>Строка со значениями атрибутов экземпляра класса</returns>
        public new string ShowControlElementAttributes()
        {
            return $"Текстовое поле с идентификатором {ElementIdentificator} \nрасположено по координатам с абсциссой {AbscissElementPlacement} и ординатой {OrdinateElementPlacement};\nтекст, введенный в поле: \"{FieldContents}\", текст подсказки: \"{HintText}\".";
        }

        /// <summary>
        /// обычный метод для возврата значений атрибутов экземпляра класса TextField
        /// </summary>
        /// <param name="currentElementIdentificator">возвращаемый идентификатор</param>
        /// <param name="currentAbscissElementPlacement">возвращаемая абсцисса</param>
        /// <param name="currentOrdinateElementPlacement">возвращаемая ордината</param>
        /// <param name="currentFieldContents">введенный текст</param>
        public void GetControlElementAttributes(out int currentElementIdentificator, out double currentAbscissElementPlacement, out double currentOrdinateElementPlacement, out string currentFieldContents, out string currentHintText)
        {
            base.GetControlElementAttributes(out currentElementIdentificator, out currentAbscissElementPlacement, out currentOrdinateElementPlacement);
            currentFieldContents = FieldContents;
            currentHintText = HintText;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса через клавиатуру
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public TextField InitializeTextFieldUsingKeyboard(int currentElementIdentificator, double currentAbscissElementPlacement, double currentOrdinateElementPlacement, string currentFieldContents, string currentHintText)
        {
            TextField newTextField = new TextField(currentElementIdentificator, currentAbscissElementPlacement, currentOrdinateElementPlacement, currentFieldContents, currentHintText);
            return newTextField;
        }

        /// <summary>
        /// метод для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        /// <returns>инициализированный экземпляр класса</returns>
        static public TextField InitializeTextFieldUsingRandom()
        {
            string alphabetRandom = "abcdefghijklmnopqrstuvwxyz";
            int randomFieldContentsLength = randomNumber.Next(20);
            string randomFieldContents = "";
            for (int i = 0; i < randomFieldContentsLength; i++)
            {
                // Случайное определение индекса буквы в алфавите
                int x = randomNumber.Next(26);
                // Добавление символа по указанному индексу в случайную строку
                randomFieldContents = randomFieldContents + alphabetRandom[x];
            }
            int randomHintTextLength = randomNumber.Next(20);
            string randomHintText = "";
            for (int i = 0; i < randomHintTextLength; i++)
            {
                // Случайное определение индекса буквы в алфавите
                int x = randomNumber.Next(26);
                // Добавление символа по указанному индексу в случайную строку
                randomHintText = randomHintText + alphabetRandom[x];
            }
            TextField newTextField = new TextField(randomNumber.Next(0, 100000), randomNumber.Next(-10000, 10000) / (double)100, randomNumber.Next(-10000, 10000) / (double)100, randomFieldContents, randomHintText);
            return newTextField;
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с клавиатуры
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Введите строку - текст, введенный в текстовое поле:");
            FieldContents = Console.ReadLine();
            Console.WriteLine("Введите строку - текст подсказки для текстового поля:");
            HintText = Console.ReadLine();
        }

        /// <summary>
        /// метод интерфейса для инициализации экземпляра класса с помощью ДСЧ
        /// </summary>
        public override void InitializeUsingRandom()
        {
            base.InitializeUsingRandom();
            FieldContents = variantsFieldContents[randomNumber.Next(variantsFieldContents.Length)];
            HintText = variantsHintText[randomNumber.Next(variantsHintText.Length)];
        }

        /// <summary>
        /// виртуальный метод класса Object для вывода экземпляра класса через консоль
        /// </summary>
        /// <returns>строка для вывода экземпляра класса</returns>
        public override string ToString()
        {
            return base.ToString() + ", текст, введенный в текстовое поле: \"" + this.FieldContents
                + "\", текст подсказки для текстового поля: \"" + this.HintText + "\"";
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
            if (checkedObject is TextField checkedTextField)
            {
                return checkedTextField.ElementIdentificator == this.ElementIdentificator
                    && Math.Abs(checkedTextField.AbscissElementPlacement - this.AbscissElementPlacement) <= maximumDifference
                    && Math.Abs(checkedTextField.OrdinateElementPlacement - this.OrdinateElementPlacement) <= maximumDifference
                    && checkedTextField.FieldContents == this.FieldContents
                    && checkedTextField.HintText == this.HintText;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^FieldContents.GetHashCode()^HintText.GetHashCode();
        }

        /// <summary>
        /// метод для глубокого копирования объекта
        /// </summary>
        /// <returns>копия экземпляра класса типа object</returns>
        public override object Clone()
        {
            return new TextField(this.ElementIdentificator, this.AbscissElementPlacement, this.OrdinateElementPlacement, this.FieldContents, this.HintText);
        }
    }
}
