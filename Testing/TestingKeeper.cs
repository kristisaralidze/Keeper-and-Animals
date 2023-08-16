using Assingment2;

namespace Testing
{
    [TestClass]
    public class TestingKeeper
    {
        [TestClass]
        public class KeeperTest
        {
            [TestMethod]
            public void OneDayCare()//Should return animals with maximum exhilaration
            {
                //zero animal
                List<Animal> animals1 = new();

                //one animal
                List<Animal> animals2 = new List<Animal>
            {
                new Tarantula("Webster", 20)
            };

                //multiple animals
                List<Animal> animals3 = new List<Animal>
            {
                new Tarantula("Webster", 20),
                new Hamster("Butterscotch", 30),
                new Cat("Cat-man-do", 50),
            };
                IMood mood = Usual.Instance();


                Keeper keeper1 = new Keeper("Steve", animals1, 0);//zero
                Keeper keeper2 = new Keeper("Steve", animals2, 0);//one
                Keeper keeper3 = new Keeper("Steve", animals3, 0);//multiple


                List<Animal> maxAnimals1 = keeper1.OneDayCare(mood);//zero
                List<Animal> maxAnimals2 = keeper2.OneDayCare(mood);//one
                List<Animal> maxAnimals3 = keeper3.OneDayCare(mood);//multiple


                Assert.AreEqual(0, maxAnimals1.Count);//zero
                Assert.AreEqual(1, maxAnimals2.Count);//two
                Assert.AreEqual(1, maxAnimals3.Count);//multiple

                Assert.AreEqual(new Tarantula("Webster", 18), maxAnimals2[0]);

                Assert.AreEqual(new Cat("Cat-man-do", 53), maxAnimals3[0]);

                //testing tostring+OneDayCare
                Assert.AreEqual("Tarantula, name: Webster,  exhilaration level: 18", maxAnimals2[0].ToString());
                Assert.AreEqual("Cat, name: Cat-man-do,  exhilaration level: 53", maxAnimals3[0].ToString());
            }
            //testing isAlive method
            [TestMethod]
            public void Alive()
            {
                List<Animal> animals = new List<Animal>
            {
                new Tarantula("Webster", 13),
                new Hamster("Butterscotch", 21),
                new Cat("Cat-man-do", 50),
            };

                List<IMood> moods = new();
                moods.Add(Usual.Instance());
                moods.Add(Usual.Instance());
                moods.Add(Blue.Instance());
                moods.Add(Blue.Instance());
                moods.Add(Blue.Instance());

                Keeper keeper = new Keeper("Steve", animals, 0);

                for (int j = 0; j < moods.Count; j++)
                {
                    keeper.OneDayCare(moods[j]);
                }

                Assert.AreEqual(false, animals[0].Alive());
                Assert.AreEqual(false, animals[1].Alive());
                Assert.AreEqual(true, animals[2].Alive());
            }
            //testing if mood modifies correctly
            [TestMethod]
            public void ModifyMood()
            {
                List<Animal> animals = new List<Animal>
            {
                new Tarantula("Webster", 13),
                new Hamster("Butterscotch", 21),
                new Cat("Cat-man-do", 50),
            };
                Keeper keeper = new Keeper("Steve", animals, 0);
                IMood mood = Usual.Instance();
                for (int j = 0; j < animals.Count; j++)
                {
                    keeper.OneDayCare(mood);
                }
                Assert.AreEqual(3, keeper.ChangingMood);

            }
            //test animal constructor
            [TestMethod]
            public void AnimalConstructor()
            {
                try
                {
                    Animal animal = new Tarantula("Webster", -2);
                    Assert.Fail("no exception thrown");
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex is Animal.ExhilarationOutOfRangeException);
                }
                try
                {
                    Animal animal = new Tarantula("Webster", 75);
                    Assert.Fail("no exception thrown");
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex is Animal.ExhilarationOutOfRangeException);
                }
            }
            //test moods separately
            [TestMethod]
            public void JoyfulMood()
            {
                Animal tarantula = new Tarantula("Webster", 1);
                Animal hamster = new Hamster("Butterscotch", 1);
                Animal cat = new Cat("Cat-man-do", 1);

                IMood mood = Joyful.Instance();

                tarantula.AfterCare(mood);
                hamster.AfterCare(mood);
                cat.AfterCare(mood);

                Assert.AreEqual(2, tarantula.Exhilaration);
                Assert.AreEqual(3, hamster.Exhilaration);
                Assert.AreEqual(4, cat.Exhilaration);

            }
            [TestMethod]
            public void UsualMood()
            {
                Animal tarantula = new Tarantula("Webster", 1);
                Animal hamster = new Hamster("Butterscotch", 3);
                Animal cat = new Cat("Cat-man-do", 50);

                IMood mood = Usual.Instance();

                tarantula.AfterCare(mood);//should die
                hamster.AfterCare(mood);//should die = 0
                hamster.AfterCare(mood);//let's do on dead 
                cat.AfterCare(mood);

                Assert.AreEqual(53, cat.Exhilaration);
                Assert.AreEqual(0, hamster.Exhilaration);
                Assert.AreEqual(-1, tarantula.Exhilaration);
            }

            [TestMethod]
            public void BlueMood()
            {
                Animal tarantula = new Tarantula("Webster", 3);
                Animal hamster = new Hamster("Butterscotch", 5);
                Animal cat = new Cat("Cat-man-do", 7);

                IMood mood = Blue.Instance();

                tarantula.AfterCare(mood);
                hamster.AfterCare(mood);
                cat.AfterCare(mood);

                Assert.AreEqual(0, cat.Exhilaration);
                Assert.AreEqual(0, hamster.Exhilaration);
                Assert.AreEqual(0, tarantula.Exhilaration);
            }



        }

    }
}