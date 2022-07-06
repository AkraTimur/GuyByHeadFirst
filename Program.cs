using System;

namespace GuyByHeadFirst
{
     class Guy
    {
        public string Name;
        public int Cash;    // в полях хранятся имя парня и сумма денег у него в кармане
        
         static void Main (string[] args)
        {
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };
            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();
                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "")
                {
                    return;
                }
                 if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        var cashGiven = joe.GiveCash(amount);
                        bob.ReceiveCash(cashGiven);
                    }
                    else if (whichGuy == "Bob")
                    {
                        var cashGiven = bob.GiveCash(amount);
                        joe.ReceiveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
                
            }
        }
        /// <summary>
        /// Выводит значение моих полей Name и Cash на консоль.
        /// </summary>
        public void WriteMyInfo ()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
            // иногда бывает нужно приказать объекту выполнить некоторую операцию- например, вывести описание этого объекта на консоль.
        }
        /// <summary>
        /// Выдает часть моих денег, удаляя их из кармана ( или выводит на консоль сообщение о том, что денег недостаточно.
        /// </summary>
        /// <param name="amount">Выдаваемая сумма</param>
        /// <returns>
        /// Сумма денег, взятая из кармана, или 0, если денег не хватает
        /// </returns>
        public int GiveCash (int amount)
        {
            if (amount <=0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount.");
            }
            if (amount > Cash) 
            {
                Console.WriteLine(Name + " says: " + " I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }
        /// <summary>
        /// Получает деньги, добавляя их в мой карман (или выводит сообщение на консоль, если сумма недействительна).
        /// </summary>
        /// <param name="amount"> Получаемая сумма</param>
        public void ReceiveCash (int amount)
        {
            if (amount <=0)
            {
                Console.WriteLine(Name + " says: " + "isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }
        // Методы ReceiveCash и GiveCash проверяют, что сумма , которую требуется выдавать или получить действительна.
        // это делается для того, чтобы нельзя было вызвать метод получения денег с отрицательным значением, что привело бы к потере средств.
    }
}
