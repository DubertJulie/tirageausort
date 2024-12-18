using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> participants = ["Brandon", "Kelly", "Dylan", "Brenda", "Steve", "Donna", "David", "Andrea", "Jessica", "Tyler", "Ashley", "Ryan", "Taylor", "Brooke", "Chase", "Madison", "Logan"];
            List<string> participantsDejaTires = new List<string>();

            int choixMenu;
            int choixValide;

            Random gagnant = new Random();

            do
            {
                Console.WriteLine("--- Le grand tirage au sort --- \n");
                Console.WriteLine("1 --- Effectuer un tirage \n2 --- Voir la liste des personnes déjà tirées (" + participantsDejaTires.Count + ") \n3 --- Voir la liste des personnes restantes (" + participants.Count + ") \n0 --- Quitter le programme");
                Console.Write("Faites votre choix : ");

                while (!int.TryParse(Console.ReadLine(), out choixValide))
                { Console.WriteLine("Merci de saisir une option du menu !"); }
                choixMenu = choixValide;

                switch (choixMenu)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        int resultatTirage = gagnant.Next(1, (participants.Count + 1));

                        string messageGagnant = "L'heureux(se) gagnant(e) est " + participants[resultatTirage] + "!";
                        int messageLongueur = messageGagnant.Length + 4;

                        Console.WriteLine("\u2554" + new string('\u2550', messageLongueur) + "\u2557");
                        Console.WriteLine("\u2551  " + messageGagnant + "  \u2551");
                        Console.WriteLine("\u255A" + new string('\u2550', messageLongueur) + "\u255D");

                        participantsDejaTires.Add(participants[resultatTirage]);
                        participants.Remove(participants[resultatTirage]);

                        Console.ResetColor();
                        break;
                    case 2:
                        Console.Clear();
                        if (participantsDejaTires.Any())
                        {
                            foreach (var prenom in participantsDejaTires)
                            {
                                Console.WriteLine(prenom);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aucun participant n'a été tiré pour l'instant.");
                        };
                        break;
                    case 3:

                        Console.Clear();
                        if (participants.Any())
                        {
                            foreach (var prenom in participants)
                            {
                                Console.WriteLine(prenom);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Il ne reste aucun participant n'ayant pas été tiré");
                        };
                        break;
                }

            } while (choixMenu != 0);

        }
    }
}

