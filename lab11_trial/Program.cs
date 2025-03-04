using lab10_LibraryControlElements;
using System.Collections;
namespace lab11_trial
{
    internal class Program
    {
        static void AddNewElementToSortedList(SortedList currentSortedList)
        {
            if (currentSortedList == null)
            {
                Console.WriteLine("Список пустой, поэтому в него нельзя добавить элемент");
            }
            else
            {
                Console.WriteLine("Введите ключ");
            }
        }

        static void Main(string[] args)
        {
            //Task 1
            SortedList controlElementsSortedList = new SortedList();
            ControlElement currentControlElement = new ControlElement();
            currentControlElement.InitializeUsingRandom();
            controlElementsSortedList.Add(currentControlElement.ElementIdentificator, currentControlElement);

            Button currentButton = new Button();
            currentButton.InitializeUsingRandom();
            controlElementsSortedList.Add(currentButton.ElementIdentificator, currentButton);

            MultipleChoiceButton currentMultipleChoiceButton = new MultipleChoiceButton();
            currentMultipleChoiceButton.InitializeUsingRandom();
            controlElementsSortedList.Add(currentMultipleChoiceButton.ElementIdentificator, currentMultipleChoiceButton);

            for (int i = 0; i < controlElementsSortedList.Count; i++)
            {
                Console.WriteLine(controlElementsSortedList.GetKey(i) + " " + controlElementsSortedList.GetByIndex(i));
            }

            // ввод и удаление объектов по ключу здесь>>>>
            SortedList controlElementsSortedList1 = null;
            controlElementsSortedList1.Add("5", "6");

            Console.WriteLine(controlElementsSortedList.Capacity);
        }
    }
}
