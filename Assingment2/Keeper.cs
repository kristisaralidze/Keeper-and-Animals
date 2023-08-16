using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2
{
    public class Keeper
    {
        private string name;
        private List<Animal> animals;
        public int ChangingMood { get; set; }

        public Keeper(string name, List<Animal> animals, int changingMood)
        {
            this.name = name;
            this.animals = animals;
            this.ChangingMood = changingMood;
        }


        public List<Animal> OneDayCare(IMood mood)
        {
            List<Animal> maxAnimals = new List<Animal>();
            int maxExhilaration = 0;
            bool l = true;
            for (int i = 0; i < animals.Count && animals[i].Alive(); i++)
            {
                animals[i].AfterCare(mood);
                l = l && (animals[i].Exhilaration) >= 5;
                if (animals[i].Exhilaration > maxExhilaration)
                {
                    maxExhilaration = animals[i].Exhilaration;
                }
            }
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Exhilaration == maxExhilaration)
                {
                    maxAnimals.Add(animals[i]);
                }
            }
            if (l)
            {
                ChangingMood++;
            }
            return maxAnimals;
        }

    }
}
