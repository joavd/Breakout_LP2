using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// This class handle keyboard input, other objects can register themselves
    /// as observers to listen to specific keys
    /// </summary>
    public class InputHandler {

        // Observers for specific keys
        private Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>>
            observers;

        // The input thread
        private Thread inputThread;

        // A list of keys which cause the input handler to terminate
        private IEnumerable<ConsoleKey> quitKeys;

        /// <summary>
        /// Create a new input handler
        /// </summary>
        /// <param name="quitKeys">Keys that quit</param>
        public InputHandler(IEnumerable<ConsoleKey> quitKeys) {
            this.quitKeys = quitKeys;
            observers = new
                Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>>();
        }

        // Method which will run in a thread reading keys
        private void ReadInput() {
            ConsoleKey key;

            // Listen keys until a quit key is pressed
            do {
                // Read key
                key = Console.ReadKey(true).Key;

                // Notify observers listening for this key
                if (observers.ContainsKey(key)) {
                    foreach (IObserver<ConsoleKey> observer in
                        observers[key]) {
                        observer.Notify(key);
                    }
                }
            } while (!quitKeys.Contains(key));
        }

        /// <summary>
        /// Start thread which will read the input
        /// </summary>
        public void StartReadingInput() {
            inputThread = new Thread(ReadInput);
            inputThread.Start();
        }

        /// <summary>
        /// Wait for thread reading the input to terminate
        /// </summary>
        public void StopReadingInput() {
            inputThread.Join();
        }

        // Below are methods for registering and removing observers for this
        // subject

        /// <summary>
        /// Register an observer
        /// </summary>
        /// <param name="whatToObserve">What to observe</param>
        /// <param name="observer">The observer</param>
        public void RegisterObserver(
            IEnumerable<ConsoleKey> whatToObserve,
            IObserver<ConsoleKey> observer) {
            foreach (ConsoleKey key in whatToObserve) {
                if (!observers.ContainsKey(key)) {
                    observers[key] = new List<IObserver<ConsoleKey>>();
                }
                observers[key].Add(observer);
            }
        }

        /// <summary>
        /// Remove an observer
        /// </summary>
        /// <param name="whatToObserve">What to not observe</param>
        /// <param name="observer">The observer</param>
        public void RemoveObserver(
            ConsoleKey whatToObserve, IObserver<ConsoleKey> observer) {
            if (observers.ContainsKey(whatToObserve)) {
                observers[whatToObserve].Remove(observer);
            }
        }

        /// <summary>
        /// Remove an observer
        /// </summary>
        /// <param name="observer">The observer</param>
        public void RemoveObserver(IObserver<ConsoleKey> observer) {
            foreach (ICollection<IObserver<ConsoleKey>> theseObservers
                        in observers.Values) {
                theseObservers.Remove(observer);
            }
        }
    }
}
