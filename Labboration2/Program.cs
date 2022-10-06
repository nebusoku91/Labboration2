// See https://aka.ms/new-console-template for more information

using KitchenAppliances;

MyKitchen kitchen = new MyKitchen();
kitchen.Menu();

namespace KitchenAppliances
{
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        bool IsFunctioning { get; set; }
    }
    public class MyKitchen
    {
        List<MyAppliances> listOfStuff = new List<MyAppliances>()
{
    new MyAppliances ("Brödrost", "Philips", true),
    new MyAppliances ("Diskmaskin", "Bosch", true),
    new MyAppliances ("Tekokare", "OBH Nordica", false)
};

        int menuChoice;
        bool running = true;
        public void Menu()
        {
            Console.WriteLine("*** Köket - Huvudmeny ***\n" +
                "1. Använd köksapparat\n" +
                "2. Lägg till köksapparat\n" +
                "3. Lista köksapparater\n" +
                "4. Ta bort köksapparat\n" +
                "5. Avsluta");
            try
            {
                while (running == true)

                    switch (menuChoice = int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            UseAppliance();
                            break;
                        case 2:
                            MakeAppliance();
                            break;
                        case 3:
                            ListAppliance();
                            break;
                        case 4:
                            DeleteAppliance();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Menu();
        }
        public void UseAppliance()
        {
            // Using appliance
            try
            {
                Console.WriteLine("Vilken köksapparat vill du använda?");
                for (int i = 0; i < listOfStuff.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + listOfStuff[i].Type);
                }
                int useChoice = int.Parse(Console.ReadLine());
                if (listOfStuff[useChoice - 1].IsFunctioning == true)
                {
                    Console.WriteLine($"Använder {listOfStuff[useChoice - 1].Type} gjord av {listOfStuff[useChoice - 1].Brand}, och den är i fungerande skick.");
                }
                else
                {
                    Console.WriteLine($"Försöker använda {listOfStuff[useChoice - 1].Type} gjord av {listOfStuff[useChoice - 1].Brand}, men den är trasig...");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Menu();
        }
        public void MakeAppliance()
        {
            string makeChoiceType = "";
            string makeChoiceBrand = "";
            string makeWorkingInput = "";
            bool workingInputTrue = true;
            bool makeChoiceFunctioning = true;

            // Add appliance
            try
            {
                while (makeChoiceType == "")
                {
                    Console.WriteLine("Vad vill du lägga till?");
                    makeChoiceType = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                while (makeChoiceBrand == "")
                {
                    Console.WriteLine("Vilket märke?");
                    makeChoiceBrand = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                while (workingInputTrue == true)
                {
                    Console.WriteLine("Fungerar den? j/n");
                    makeWorkingInput = Console.ReadLine();
                    makeWorkingInput = makeWorkingInput.ToLower();
                    if (makeWorkingInput == "j")
                    {
                        makeChoiceFunctioning = true;
                        workingInputTrue = false;
                    }
                    else if (makeWorkingInput == "n")
                    {
                        makeChoiceFunctioning = false;
                        workingInputTrue = false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                listOfStuff.Add(new MyAppliances(makeChoiceType, makeChoiceBrand, makeChoiceFunctioning));
                if (makeChoiceFunctioning == true)
                {
                    Console.WriteLine($"Skapade en {makeChoiceType} av märket {makeChoiceBrand}, och den är i fungerande skick.");
                }
                else if (makeChoiceFunctioning == false)
                {
                    Console.WriteLine($"Skapade en {makeChoiceType} av märket {makeChoiceBrand}, och den är trasig.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Menu();
        }
        public void ListAppliance()
        {
            // List appliances

            try
            {
                for (int i = 0; i < listOfStuff.Count; i++)
                {
                    string isFunctioningList;

                    if (listOfStuff[i].IsFunctioning == true)
                    {
                        isFunctioningList = "Denna apparat är i fungerande skick.\n";
                    }
                    else
                    {
                        isFunctioningList = "Denna apparat är trasig.\n";
                    }

                    Console.WriteLine(i + 1 + ". " + $"Köksapparat: {listOfStuff[i].Type}." + $" Märke: {listOfStuff[i].Brand}. {isFunctioningList}");

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Menu();
        }
        public void DeleteAppliance()
        {
            // Delete appliances

            int deleteChoice;

            try
            {
                Console.WriteLine("Vilken köksapparat vill du ta bort?");
                for (int i = 0; i < listOfStuff.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + listOfStuff[i].Type);
                }
                deleteChoice = int.Parse(Console.ReadLine());
                Console.WriteLine(listOfStuff[deleteChoice - 1].Type + " har tagits bort från listan.");
                listOfStuff.RemoveAt(deleteChoice - 1);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Menu();
        }
    }
    public class MyAppliances : IKitchenAppliance
    {
        public MyAppliances(string type, string brand, bool isfunctioning)
        {
            this.Type = type;
            this.Brand = brand;
            this.IsFunctioning = isfunctioning;
        }
        public string Type { get; set; }
        public string Brand { get; set; }
        public bool IsFunctioning { get; set; }
    }
}
