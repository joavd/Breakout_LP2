using System;
using GameEngine;

namespace Breakout_LP2 {
    /// <summary>
    /// Simple component which listens for the escape key and terminates the
    /// parent scene
    /// </summary>
    public class Quitter : Component {
        // Key observer to check for ESC
        private KeyObserver keyObserver;

        /// <summary>
        /// Start the observer
        /// </summary>
        public override void Start() {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        /// <summary>
        /// Update the observer with the given key
        /// </summary>
        public override void Update() {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys()) {
                if (key == ConsoleKey.Escape) {
                    Console.WriteLine("Bye :(");
                    ParentScene.Terminate();
                }
            }
        }

        /// <summary>
        /// Destroy the observer
        /// </summary>
        public override void Finish() {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
