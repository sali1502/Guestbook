/* DT201G Programmering med C#.NET, moment 3. Åsa Lindskog sali1502@student.miun.se. */
/* En konsollapplikation som fungerar som en gästbok där användare kan posta och radera inlägg. */

using System;
using System.Text;

namespace messages
{
    class Program

    {
        static void Main(string[] args)
        {
            // Gör svenska tecken läsbara
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            // Skapa en ny instans av gästboken som hanterar inlägg
            Guestbook guestbook = new Guestbook();
            int i = 0;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("Å S A ´ S  G Ä S T B O K\n\n");

                // Visa menyval för användaren
                Console.WriteLine("1. Skriv ett inlägg");
                Console.WriteLine("2. Radera inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                // Skriv ut befintliga meddelanden i gästboken
                i = 0;
                foreach (Message message in guestbook.getMessages())
                {
                    Console.WriteLine("[" + i++ + "] " + message.TextMessage);
                }

                // Menyval genom tangenttryck
                int inp = (int)Console.ReadKey(true).Key;
                switch (inp)
                {
                    case '1':
                        // Användaren väljer att skriva ett nytt inlägg
                        Console.Clear();
                        Console.CursorVisible = true;
                        // Be användaren skriva i sitt namn samt kontroll av att fältet inte är tomt
                        string? name;
                        while (true)
                        {
                            Console.Write("Ditt namn: ");
                            name = Console.ReadLine();
                            if (!string.IsNullOrEmpty(name))
                                break;
                            Console.WriteLine("Vänligen ange ditt namn.");
                        }
                        // Be användaren skriva in ett inlägg samt kontroll av att fältet inte är tomt
                        string? messageText;
                        while (true)
                        {
                            Console.Write("Ditt meddelande: ");
                            messageText = Console.ReadLine();
                            if (!string.IsNullOrEmpty(messageText))
                                break;
                            Console.WriteLine("Vänligen skriv ett meddelande.");
                        }
                        // Lägg till ett inlägg i gästboken
                        guestbook.addMessage($"{name}: {messageText}");
                        break;

                    case '2':
                        // Användaren väljer att radera ett inlägg
                        Console.Clear();
                        Console.CursorVisible = true;

                        string? index;
                        while (true)
                        {
                            // Be användaren välja ett index för det inlägg som ska raderas
                            Console.Write("Ange ett index att radera: ");
                            index = Console.ReadLine();

                            // Kontroll av att fältet inte är tomt
                            if (!String.IsNullOrEmpty(index))
                            {
                                try
                                {
                                    // Radera inlägget och avsluta loopen om det lyckas
                                    guestbook.delMessage(Convert.ToInt32(index));
                                    break;
                                }
                                catch (Exception)
                                {
                                    // Felmeddelande om siffran inte är ett giltigt index
                                    Console.WriteLine("Detta index finns inte. Tryck på valfri tangent för fortsätta.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                // Felneddelande om fältet är tomt
                                Console.WriteLine("Vänligen skriv in ett indexnummer. Tryck på valfri tangent för fortsätta.");
                                Console.ReadKey();
                            }
                            // Rensar konsollen
                            Console.Clear();
                        }
                        break;

                    case 88:
                        // Användaren väljer att avsluta programmet genom att trycka X
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}