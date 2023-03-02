namespace List
{
    public class TestingList
    {
        static void Main(string[] args)
        {
            ShoppingList.ListOfObjects();
        }
    }
    
    public class ShoppingList
    {

        public static void ListOfObjects()
        {

            ObjectsController obj = new ObjectsController();

            string repeat = "Do you want to do another action? y/n";
            string answer = "Y";

            do
            {
                Console.WriteLine("Write down what you want to do: Add, Remove, Show.");
                string? instruction = Console.ReadLine();

                switch (instruction)
                {

                    case "Add":
                        Console.WriteLine("Write the Id: ");
                        string? inputId = Console.ReadLine();

                        Console.WriteLine("Write the name of the object: ");
                        string? inputNombre = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(inputId) && !string.IsNullOrWhiteSpace(inputNombre))
                        {
                            obj.AddObject(new Shoppingitems(
                                int.Parse(inputId),
                                inputNombre
                                ));
                            Console.WriteLine(repeat);
                            answer = Console.ReadLine().ToUpper();
                        }
                        break;

                    case "Remove":
                        Console.WriteLine("Enter the index number of the list:");
                        string? indice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(indice))
                        {
                            Console.WriteLine("No number entered...");
                            break;
                        }

                        int indice1 = int.Parse(indice);

                        obj.RemoveObject(indice1);

                        Console.WriteLine(repeat);
                        answer = Console.ReadLine().ToUpper();
                        break;

                    case "Show":
                        Console.WriteLine("This is the list: \n");
                        Console.WriteLine(obj.ShowList());
                        Console.WriteLine(repeat);
                        answer = Console.ReadLine().ToUpper();
                        break;

                    default:
                        Console.WriteLine("You did not type the instruction correctly");
                        Console.WriteLine(repeat);
                        answer = Console.ReadLine().ToUpper();
                        break;
                }
            } while (answer != "N");

        }

    }

    //Model
    public class Shoppingitems
    {
        public Shoppingitems(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Controller
    public class ObjectsController
    {
        List<Shoppingitems> ListObjects = new List<Shoppingitems>();
        
        public void AddObject(Shoppingitems object1)
        {
            if (object1 != null)
            {
                ListObjects.Add(object1);
            }
        }

        public void RemoveObject(int object0)
        {
            if (object0 != null)
            {
                ListObjects.RemoveAt(object0); 
            }
        }

        public string ShowList()
        {
            string text = "Shopping List: \n";

            foreach (Shoppingitems Object in ListObjects)
            {
                text += Object.Id + ". " + Object.Name + "\n";
            }

            return text;
        }
    } 

}