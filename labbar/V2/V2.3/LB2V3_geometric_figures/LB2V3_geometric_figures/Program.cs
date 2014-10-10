using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2V3_geometric_figures
{
    class Program
    {
        private static readonly Random _randomSeed = new Random();

        //Metoden slumpar fram hur många figurer som ska presenteras i ett intervall mellan 5 och 21. Sedan skapas arrayen shapes utifrån det antalet.
        //För varje figur slumpas en längd och en bredd mellan 5 och 99.9. Det slumpas också fram vilken typ av figur som ska skapas, Ellips eller rektangel. 
        //Metoden returneras arrayen shapes.
        private static Shape[] RandomizeShapes()
        {
            Random rnd = new Random(_randomSeed.Next());
            int randomShapeCount = rnd.Next(5, 21);
            Shape[] shapes = new Shape[randomShapeCount];
            Shape shape = null;

            for (int i = 0; i < randomShapeCount; i++)
            {

                Random rnd2 = new Random(_randomSeed.Next());
                double length = Math.Round((5 + rnd2.NextDouble() * (99.9 - 5)), 1);

                Random rnd3 = new Random(_randomSeed.Next());
                double width = Math.Round((5 + rnd3.NextDouble() * (99.9 - 5)), 1);

                Random rnd4 = new Random(_randomSeed.Next());
                ShapeType shapeType = (ShapeType)rnd4.Next(0, 2);

                switch (shapeType)
                {
                    case (ShapeType)0:
                        shape = new Ellipse(length, width);
                        break;
                    case (ShapeType)1:
                        shape = new Rectangle(length, width);
                        break;
                }

                shapes[i] = shape;
            }
            return shapes;
        }

        //Presenterar figurerna med figurnamn vänsterjusterad och resten högerjusterade.
        private static void ViewShapes(Shape[] shapes)
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("{0, -10}{1, 10}{2, 10}{3, 10}{4, 10}", "Figur", "Längd", "Bredd", "Omkrets", "Area");
            Console.WriteLine("-----------------------------------------------------------");
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i].ToString());
            }
        }

        static void Main(string[] args)
        {
            do
            {
                // Skapa upp en array som innehåller slumptal från Randomize metod.
                Shape[] shapes = RandomizeShapes();

                //Sorterar figurerna genom att jämföra alla areor med varandra med hjälp av metoden CompareTo.
                //Om CompareTo returnerar ett värde mindre än noll är det aktuella värdet större än det det jämförs med och de byter plats.
                //Så går man igenom hela arrayen. Nästa genomgång minskas antalet platser som ska gå igenom med ett eftersom ett värde har hamnat på rätt plats.
                //När så gjorts med alla platser i arrayen kommer de vara i rätt ordning. En så kallad bubbelsortering.
                int n = shapes.Length - 1;
                for (int i = 0; i <= n; i++)
                {
                    for (int j = n; j > i; j--)
                    {
                        if (shapes[j - 1].CompareTo(shapes[j]) < 0)
                        {
                            Shape temp = shapes[j - 1];
                            shapes[j - 1] = shapes[j];
                            shapes[j] = temp;
                        }
                    }
                }

                ViewShapes(shapes);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck en tangent för ny beräkning. ESC avslutar");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}