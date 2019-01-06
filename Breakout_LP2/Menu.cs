using System;
using System.Runtime.InteropServices;

namespace Breakout_LP2 {
    /// <summary>
    /// Class that shows the menu
    /// </summary>
    public class Menu {
        // World dimensions
        private readonly int xdim = 60, ydim = 40;

        // Title to display
        private const string title = @"
____________ _____  ___   _   _______ _   _ _____ 
| ___ \ ___ \  ___|/ _ \ | | / /  _  | | | |_   _|
| |_/ / |_/ / |__ / /_\ \| |/ /| | | | | | | | |  
| ___ \    /|  __||  _  ||    \| | | | | | | | |  
| |_/ / |\ \| |___| | | || |\  \ \_/ / |_| | | |  
\____/\_| \_\____/\_| |_/\_| \_/\___/ \___/  \_/  
                                                  ";
        // Alejandro name to display
        private const string alejandro = @"
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

        // Joao name to display
        private const string joao = @"
              _       /\/|         
           _ | |___  |/\/ ___      
          | || / _ \/ _` / _ \     
           \__/\___/\__,_\___/     
        ___                _       
       |   \ _  _ __ _ _ _| |_ ___ 
       | |) | || / _` | '_|  _/ -_)
       |___/ \_,_\__,_|_|  \__\___|";

        // Controls to display
        private const string controls = "HOW TO PLAY\n\n" +
            "In Breakout, a layer of bricks lines\nthe top third of the" +
            " screen.\nA ball travels across the " +
            "screen, bouncing\noff the top and side walls of the screen.\n" +
            "When a brick is hit, the ball bounces away\nand the brick is " +
            "destroyed.\nThe player loses a turn when the ball\ntouches the " +
            "bottom of the screen.\nTo prevent this from happening, the " +
            "player\nhas a movable paddle to bounce the ball\nupward, keeping" +
            " it in play.\n\nYou play Breakout by using the\nLEFT and " +
            "RIGHT arrows ";

        /// <summary>
        /// Shows the options to choose from in the main menu
        /// </summary>
        public void ShowOptions() {
            // If ends the loop
            bool end = false;
            // Option the user chooses
            short option;

            do {
                // Resizes the window if it's in Windows
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    Console.SetWindowSize(xdim, ydim + 1);
                }
                Console.Clear();
                ShowMenu();
                Console.WriteLine("\n");
                AskOption();
                // Reads the input
                short.TryParse(Console.ReadLine(), out option);

                // Switches according to the option
                switch (option) {
                    case 1:
                        Breakout br = new Breakout(xdim, ydim);
                        br.Run();
                        Console.BackgroundColor = ConsoleColor.Black;
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

        // Shows the main menu
        private void ShowMenu() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n1. Play\n2. Controls\n3. Credits\n" +
                "4. Quit");
        }

        // Asks which option the user wants
        private void AskOption() {
            Console.WriteLine("What do you want to do?");
        }

        // Shows controls
        private void ShowControls() {
            Console.WriteLine(controls);
        }

        // Shows credits
        private void ShowCredits() {
            Console.WriteLine("This project was made by:\n");
            Console.WriteLine(alejandro);
            Console.WriteLine("\n\nand");
            Console.WriteLine(joao);
        }

        // Says Bye message
        private void Bye() {
            Console.WriteLine("\nThanks for playing! Until next time!");
        }
    }
}
