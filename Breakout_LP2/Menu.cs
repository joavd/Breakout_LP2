using System;
using System.Runtime.InteropServices;

namespace Breakout_LP2 {

    // Class that shows the menu
    public class Menu {
        // World dimensions
        int xdim = 50, ydim = 40;

        private const string title = @"
____________ _____  ___   _   _______ _   _ _____ 
| ___ \ ___ \  ___|/ _ \ | | / /  _  | | | |_   _|
| |_/ / |_/ / |__ / /_\ \| |/ /| | | | | | | | |  
| ___ \    /|  __||  _  ||    \| | | | | | | | |  
| |_/ / |\ \| |___| | | || |\  \ \_/ / |_| | | |  
\____/\_| \_\____/\_| |_/\_| \_/\___/ \___/  \_/  
                                                  ";

        public const string alejandro = @"
    _   _      _              _         
   /_\ | |___ (_)__ _ _ _  __| |_ _ ___ 
  / _ \| / -_)| / _` | ' \/ _` | '_/ _ \
 /_/ \_\_\___|/ \__,_|_||_\__,_|_| \___/
            |__/                        
        _   _                           
       | | | |_ _ __ ___ _ _ __ _       
       | |_| | '_/ _/ -_) '_/ _` |      
        \___/|_| \__\___|_| \__,_|      
                                        ";

        private const string joao = @"
              _       /\/|         
           _ | |___  |/\/ ___      
          | || / _ \/ _` / _ \     
           \__/\___/\__,_\___/     
        ___                _       
       |   \ _  _ __ _ _ _| |_ ___ 
       | |) | || / _` | '_|  _/ -_)
       |___/ \_,_\__,_|_|  \__\___|";

        private const string controls = "HOW TO PLAY\n\n" +
            "In Breakout, a layer of bricks lines the top third of the" +
            " screen.\nA ball travels across the " +
            "screen, bouncing off the top and side walls of the screen.\n" +
            "When a brick is hit, the ball bounces away and the brick is " +
            "destroyed.\nThe player loses a turn when the ball touches the " +
            "bottom of the screen.\nTo prevent this from happening, the " +
            "player has a movable paddle to bounce the ball upward, keeping" +
            " it in play.\n\nYou play Breakout by using the LEFT and " +
            "RIGHT arrows ";

        public void ShowOptions() {
            bool end = false;
            short option;

            do {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    Console.SetWindowSize(xdim, ydim + 1);
                }
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                ShowMenu();
                Console.WriteLine("\n");
                AskOption();
                short.TryParse(Console.ReadLine(), out option);

                switch (option) {
                    case 1:
                        Breakout br = new Breakout(xdim, ydim);
                        br.Run();
                        break;
                    case 2:
                        Console.Clear();
                        ShowControls();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        ShowCredits();
                        Console.ReadKey();
                        break;
                    case 4:
                        end = true;
                        break;
                    default:
                        break;
                }

            } while (end == false);

            Bye();
            return;
        }

        private void ShowMenu() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n1. Play\n2. Controls\n3. Credits\n" +
                "4. Quit");
        }

        private void AskOption() {
            Console.WriteLine("What do you want to do?");
        }

        private void ShowControls() {
            Console.WriteLine(controls);
        }

        private void ShowCredits() {
            Console.WriteLine("This project was made by:\n");
            Console.WriteLine(alejandro);
            Console.WriteLine("\n\nand");
            Console.WriteLine(joao);
        }

        public void WrongOption(string option) {
            Console.Write("The option you chose (" + option + ") is not a " +
                "valid option.\n");
        }

        private void Bye() {
            Console.WriteLine("\nThanks for playing! Until next time!");
        }
    }
}
