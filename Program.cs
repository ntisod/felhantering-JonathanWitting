using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felhantering
{
    class Program
    {
        /**
         * Felhantering & undantag
         * 
         * Materialet hämtat från csharpskolan.se
         * 
         **/

        static void Main(string[] args)
        {
            //Skriv ut menyalternativ
            Console.WriteLine("Felhantering och undantag");
            Console.WriteLine("*************************");
            Console.WriteLine("1. Exempel 1 - Utan felhantering med metoden Parse.");
            Console.WriteLine("2. Exempel 2 - Planera för fel med metoden TryParse.");
            Console.WriteLine("3. Exempel 3 - Felhantering med undantag.");
            Console.WriteLine("7. Övning 7 - For-Loop med stegräkning");

            Console.WriteLine();

            //Läs in menyval
            Console.Write("Ange siffra för vad du vill göra: ");
            string val = Console.ReadLine();

            //Ett par tomma rader
            Console.WriteLine();
            Console.WriteLine();

            //Använd en switch-sats för att anropa den metod som hör ihop med menyvalet.
            switch (val)
            {
                case "1":
                    Exempel1();
                    break;
                case "2":
                    Exempel2();
                    break;
                case "3":
                    Exempel3();
                    break;
                case "7":
                    Övning7();
                    break;
            }

            Console.ReadKey();
        }

        // Övning 1
        static void Exempel1()
        {
            #region OLD
            /*
             * Exempel 1. 
             * Beräkning av timlön.
             * Utan felhantering
             */

            //Console.Write("Ange din inkomst: ");
            //int inkomst = int.Parse(Console.ReadLine());
            //Console.Write("Ange antal timmar: ");
            //int timmar = int.Parse(Console.ReadLine());

            //Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
            #endregion OLD

            #region Exempel 1 Jonathan

            int inkomst = 0;
            int timmar = 0;
            bool exceptionFound = true;
            while (exceptionFound)
            {
                try
                {
                    Console.Write("Ange din inkomst: ");
                    inkomst = int.Parse(Console.ReadLine());
                    Console.Write("Ange antal timmar: ");
                    timmar = int.Parse(Console.ReadLine());

                    Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");

                    exceptionFound = false;
                }
                catch (ArgumentNullException)
                {
                    exceptionFound = true;
                    Console.WriteLine("ArgumentNullException");
                    Console.WriteLine("Försök igen...");
                }
                catch (FormatException)
                {
                    exceptionFound = true;
                    Console.WriteLine("FormatException");
                    Console.WriteLine("Försök igen...");
                }
                catch (OverflowException)
                {
                    exceptionFound = true;
                    Console.WriteLine("OverflowException");
                    Console.WriteLine("Försök igen...");
                }
                catch (System.DivideByZeroException)
                {
                    exceptionFound = true;
                    Console.WriteLine("System.DivideByZeroException");
                    Console.WriteLine("Försök igen...");
                }

                finally
                {
                    if (!exceptionFound)
                    {
                        Console.WriteLine("Success!");
                    }
                }
            }

            #endregion Exempel 1 Jonathan

        }

        // Övning 6 Metod
        // Exempel2 GetIntInput(), Metod
        static int GetIntInput(string inputString, bool canBeZero = true, string errorMessage="Mata in ett heltal tack!")
        {
            int inputResult = 0;
            bool inputCompleted = false;

            while (!inputCompleted)
            {
                Console.Write(inputString);
                inputCompleted = int.TryParse(Console.ReadLine(), out inputResult);
                if (!canBeZero && inputResult == 0) // Hanterar det möjliga exceptionet System.DivideByZeroException
                {
                    inputCompleted = false;
                    Console.WriteLine("Talet kan inte vara 0!");
                }
                if (!inputCompleted)
                    Console.WriteLine(errorMessage);
            }

            return inputResult;
        }

        // Övning 6
        static void Exempel2()
        {
            /*
             * Exempel 2. 
             * Beräkning av timlön.
             * Planera för fel med metoden TryParse.
             */

            #region OLD
            //bool inmatat = false;
            //int inkomst = 0;
            //int timmar = 0;

            //while (!inmatat)
            //{
            //    Console.Write("Ange din inkomst: ");
            //    inmatat = int.TryParse(Console.ReadLine(), out inkomst);
            //    if (!inmatat)
            //        Console.WriteLine("Mata in ett heltal tack!");
            //}

            ////Nollställ variabeln
            //inmatat = false;
            //while (!inmatat)
            //{
            //    Console.Write("Ange antal timmar: ");
            //    inmatat = int.TryParse(Console.ReadLine(), out timmar);
            //    if (!inmatat)
            //        Console.WriteLine("Mata in ett heltal tack!");
            //}

            //Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
            #endregion OLD

            #region Exempel2 Jonathan

            int inkomst = 0;
            int timmar = 0;

            inkomst = GetIntInput("Ange din inkomst: ");
            timmar = GetIntInput("Ange antal timmar: ", false);

            Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
            #endregion Exempel2 Jonathan
        }

        static void Exempel3()
        {
            /*
             * Exempel 3. 
             * De viktigaste ingredienserna i undantagshantering
             */

            try
            {
                Console.Write("Ange ett heltal: ");
                int heltal = int.Parse(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Programmet har stött på ett fel.");
            }


            Console.WriteLine("Programmet avslutades korrekt.");
        }

        // Övning 7
        static void Övning7()
        {
            int start = GetIntInput("Mata in start");
            int stop = GetIntInput("Mata in stop");
            int steg = GetIntInput("Mata in steg", false);

            Console.WriteLine("-----");
            for (int i = start; i < stop + steg; i += steg)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----");
        }
    }
}