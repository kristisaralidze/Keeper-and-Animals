using TextFile;

namespace Assingment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new("inpt.txt");

            // populating animals
            reader.ReadLine(out string line); int n = int.Parse(line);
            List<Animal> animals = new();
            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
                Animal animal = null;

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    char animalChar = char.Parse(tokens[0]);
                    string animalName = tokens[1];
                    int animalExhilaration = int.Parse(tokens[2]);

                    switch (animalChar)
                    {
                        case 'T': animal = new Tarantula(animalName, animalExhilaration); break;
                        case 'H': animal = new Hamster(animalName, animalExhilaration); break;
                        case 'C': animal = new Cat(animalName, animalExhilaration); break;
                    }
                }
                animals.Add(animal);
            }


            // populating the moods
            reader.ReadLine(out line);
            int m = line.Length;
            List<IMood> moods = new();
            for (int j = 0; j < m; ++j)
            {
                switch (line[j])
                {
                    case 'u': moods.Add(Usual.Instance()); break;
                    case 'j': moods.Add(Joyful.Instance()); break;
                    case 'b': moods.Add(Blue.Instance()); break;
                }
            }

            try
            {
                Keeper keeper = new Keeper("Steve", animals, 0);

                for (int j = 0; j < m; j++)
                {
                    
                    Console.WriteLine("Day {0}: ", (j + 1));
                    Console.WriteLine("");
                    Console.WriteLine("Before keeper takes care on animals:");
                    for (int k = 0; k < animals.Count; k++)
                    {
                        Console.WriteLine(animals[k].ToString() + " ");
                    }
                    Console.WriteLine("");
                    List<Animal> maxAnimals = keeper.OneDayCare(moods[j]);
                    Console.WriteLine("");
                    Console.WriteLine("After keeper takes care on animals:");
                    for (int k = 0; k < animals.Count; k++)
                    {
                        Console.WriteLine(animals[k].ToString() + " ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Animals with maximum exhilaration level:");
                    for (int i = 0; i < maxAnimals.Count; i++)
                    {
                        Console.Write(maxAnimals[i].ToString() + " ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.ToString());
            }
        }
    }
}