using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2
{
    public abstract class Animal
    {
        public class ExhilarationOutOfRangeException : Exception { };
        public string Name { get; }
        public int Exhilaration { get; set; }
        public void ModifyExhilaration(int e)
        {
            if (Exhilaration > 0 && (Exhilaration + e) <= 70)
            {
                Exhilaration += e;
            }
        }
        public bool Alive() { return Exhilaration > 0; }
        protected Animal(string s, int n = 0)
        {
            if (n <= 0 || n > 70) throw new ExhilarationOutOfRangeException();
            Exhilaration = n;
            Name = s;
        }

        public abstract void AfterCare(IMood mood);

        public abstract override string ToString();


        //for comparing 2 animal objects! because my oneDayCare returns max animal 
        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Animal))
                return false;
            else
            {
                Animal? anm = obj as Animal;
                return anm.Name == this.Name && anm.Exhilaration == this.Exhilaration;
            }

        }
    }

    public class Tarantula : Animal
    {
        public Tarantula(string s, int n = 0) : base(s, n) { }
        public override void AfterCare(IMood mood)
        {
            mood.ChangeTarantula(this);
        }
        public override string ToString()
        {
            return "Tarantula, name: " + this.Name + ",  exhilaration level: " + this.Exhilaration;
        }
    }

    public class Hamster : Animal
    {
        public Hamster(string s, int n = 0) : base(s, n) { }
        public override void AfterCare(IMood mood)
        {
            mood.ChangeHamster(this);
        }
        public override string ToString()
        {
            return "Hamster, name: " + this.Name + ",  exhilaration level: " + this.Exhilaration;
        }
    }
    public class Cat : Animal
    {
        public Cat(string s, int n = 0) : base(s, n) { }
        public override void AfterCare(IMood mood)
        {
            mood.ChangeCat(this);
        }
        public override string ToString()
        {
            return "Cat, name: " + this.Name + ",  exhilaration level: " + this.Exhilaration;
        }
    }
}
