using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2
{
        // class of abstract moods
        public interface IMood
        {
            public void ChangeTarantula(Tarantula p);
            public void ChangeHamster(Hamster p);
            public void ChangeCat(Cat p);
        }

        //class of joyful
        public class Joyful : IMood
        {

            public void ChangeTarantula(Tarantula p)
            {
                p.ModifyExhilaration(1);
            }
            public void ChangeHamster(Hamster p)
            {
                p.ModifyExhilaration(2);
            }
            public void ChangeCat(Cat p)
            {
                p.ModifyExhilaration(3);
            }
            private Joyful() { }

            private static Joyful instance = null;
            public static Joyful Instance()
            {
                if (instance == null)
                {
                    instance = new Joyful();
                }
                return instance;
            }
        }

        //class of usual day
        public class Usual : IMood
        {
            public void ChangeTarantula(Tarantula p)
            {
                p.ModifyExhilaration(-2);
            }
            public void ChangeHamster(Hamster p)
            {
                p.ModifyExhilaration(-3);
            }
            public void ChangeCat(Cat p)
            {
                p.ModifyExhilaration(3);
            }
            private Usual() { }

            private static Usual instance = null;
            public static Usual Instance()
            {
                if (instance == null)
                {
                    instance = new Usual();
                }
                return instance;
            }
        }
        //class of blue day
        public class Blue : IMood
        {
            public void ChangeTarantula(Tarantula p)
            {
                p.ModifyExhilaration(-3);
            }
            public void ChangeHamster(Hamster p)
            {
                p.ModifyExhilaration(-5);
            }
            public void ChangeCat(Cat p)
            {
                p.ModifyExhilaration(-7);
            }
            private Blue() { }

            private static Blue instance = null;
            public static Blue Instance()
            {
                if (instance == null)
                {
                    instance = new Blue();
                }
                return instance;
            }
        }
}
