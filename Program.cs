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
            
            Guestbook guestbook = new Guestbook();
            int i = 0;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("Å S A ´ S  G Ä S T B O K\n\n");

                Console.WriteLine("1. Skriv ett inlägg");
                Console.WriteLine("2. Radera inlägg\n");
                Console.WriteLine("X. Avsluta\n");


                i = 0;
                foreach (Message message in guestbook.getMessages())
                {
                    Console.WriteLine("[" + i++ + "] " + message.TextMessage);
                }


                int inp = (int)Console.ReadKey(true).Key;
                switch (inp)
                {
                    case '1':
                        Console.CursorVisible = true;
                        string? name;
                        while (true)
                        {
                            Console.Write("Ditt namn: ");
                            name = Console.ReadLine();
                            if (!string.IsNullOrEmpty(name))
                                break;
                            Console.WriteLine("Vänligen ange ditt namn.");
                        }
                        string? messageText;
                        while (true)
                        {
                            Console.Write("Ditt meddelande: ");
                            messageText = Console.ReadLine();
                            if (!string.IsNullOrEmpty(messageText))
                                break;
                            Console.WriteLine("Vänligen skriv ett meddelande.");
                        }
                        guestbook.addMessage($"{name}: {messageText}");
                        break;

                    case '2':
                
                        Console.CursorVisible = true;
                        Console.Write("Ange ett index att radera: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                            try
                            {
                                guestbook.delMessage(Convert.ToInt32(index));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Detta index finns inte. Tryck på valfri tangent för att fortsätta.");
                                Console.ReadKey();
                            }
                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}
