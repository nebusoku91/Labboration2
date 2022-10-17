// See https://aka.ms/new-console-template for more information

using KitchenAppliances;

MyKitchen kitchen = new MyKitchen();
kitchen.welcomeMessageEdit();
kitchen.Menu();
namespace KitchenAppliances
{
    

    
    public class MyKitchen : Room
    {
        List<MyAppliances> listOfAppliances = new List<MyAppliances>()
    {
    new MyAppliances ("Brödrost", "Philips", true),
    new MyAppliances ("Diskmaskin", "Bosch", true),
    new MyAppliances ("Tekokare", "OBH Nordica", false)
    };

        public override void welcomeMessageEdit()
        {
            Console.WriteLine("Välkommen till köket!\n");
        }
        public void Menu()
        {
            bool running = true;
            int menuChoice;
            Console.WriteLine("*** Köket - Huvudmeny ***\n" +
                "1. Använd köksapparat\n" +
                "2. Lägg till köksapparat\n" +
                "3. Lista köksapparater\n" +
                "4. Ta bort köksapparat\n" +
                "5. Avsluta");
            Console.Write(">");
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
                Console.WriteLine("\nVilken köksapparat vill du använda?\n");
                Console.Write(">");
                for (int i = 0; i < listOfAppliances.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + listOfAppliances[i].Type);
                }
                int useChoice = int.Parse(Console.ReadLine());

                if (listOfAppliances[useChoice - 1].IsFunctioning == true)
                {
                    Console.WriteLine($"\nLyckades använda {listOfAppliances[useChoice - 1].Type} gjord av {listOfAppliances[useChoice - 1].Brand}.\n");
                }
                else
                {
                    Console.WriteLine($"\nFörsöker använda {listOfAppliances[useChoice - 1].Type} gjord av {listOfAppliances[useChoice - 1].Brand}, men den är trasig...\n");
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
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            Menu();
        }
        private void MakeAppliance()
        {
            string makeChoiceType = "";
            string makeChoiceBrand = "";
            string makeWorkingInput;
            bool workingInputTrue = true;
            bool makeChoiceFunctioning = true;

            // Add appliance
            try
            {
                while (makeChoiceType == "")
                {
                    Console.WriteLine("\nVad vill du lägga till?");
                    Console.Write(">");
                    makeChoiceType = Console.ReadLine();
                }

                while (makeChoiceBrand == "")
                {
                    Console.WriteLine("\nVilket märke?\n");
                    Console.Write(">");
                    makeChoiceBrand = Console.ReadLine();
                }

                while (workingInputTrue == true)
                {
                    Console.WriteLine("\nFungerar den? j/n\n");
                    Console.Write(">");
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

                listOfAppliances.Add(new MyAppliances(makeChoiceType, makeChoiceBrand, makeChoiceFunctioning));
                if (makeChoiceFunctioning == true)
                {
                    Console.WriteLine($"\nSkapade en {makeChoiceType} av märket {makeChoiceBrand}, och den är i fungerande skick.\n");
                }
                else if (makeChoiceFunctioning == false)
                {
                    Console.WriteLine($"\nSkapade en {makeChoiceType} av märket {makeChoiceBrand}, och den är trasig.\n");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Menu();
        }
        private void ListAppliance()
        {
            // List appliances
            Console.WriteLine("\nLista på köksapparater:\n");
            try
            {
                for (int i = 0; i < listOfAppliances.Count; i++)
                {
                    string isFunctioningList;

                    if (listOfAppliances[i].IsFunctioning == true)
                    {
                        isFunctioningList = "Denna apparat är i fungerande skick.\n";
                    }
                    else
                    {
                        isFunctioningList = "Denna apparat är trasig.\n";
                    }

                    Console.WriteLine(i + 1 + ". " + $"{listOfAppliances[i].Type}." + $" Märke: {listOfAppliances[i].Brand}. {isFunctioningList}");

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Menu();
        }
        private void DeleteAppliance()
        {
            // Delete appliances

            int deleteChoice;

            try
            {
                Console.WriteLine("Vilken köksapparat vill du ta bort?");
                Console.Write(">");
                for (int i = 0; i < listOfAppliances.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + listOfAppliances[i].Type);
                }
                deleteChoice = int.Parse(Console.ReadLine());
                Console.WriteLine(listOfAppliances[deleteChoice - 1].Type + " har tagits bort från listan.");
                listOfAppliances.RemoveAt(deleteChoice - 1);
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
            catch (OutOfMemoryException e)
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
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        bool IsFunctioning { get; set; }
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
    public abstract class Room
    {
        public abstract void welcomeMessageEdit();
        protected void welcomeMessageDefault()
        {
            Console.WriteLine("Välkommen till rummet!");
        }
    }
    
}
