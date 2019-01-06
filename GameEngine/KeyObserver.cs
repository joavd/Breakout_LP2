using System;
using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// This component is an key observer
    /// </summary>
    public class KeyObserver : Component, IObserver<ConsoleKey> {
        // Keys to observe
        private IEnumerable<ConsoleKey> keysToObserve;
        // Observed keys
        private Queue<ConsoleKey> observedKeys;
        // Lock to prevent simultaneous changes
        private object queueLock;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyObserver"/> class.
        /// </summary>
        /// <param name="keysToObserve">The key to observe</param>
        public KeyObserver(IEnumerable<ConsoleKey> keysToObserve) {
            this.keysToObserve = keysToObserve;
            observedKeys = new Queue<ConsoleKey>();
            queueLock = new object();
        }

        /// <summary>
        /// Start to register observers
        /// </summary>
        public override void Start() {
            ParentScene.inputHandler.RegisterObserver(keysToObserve, this);
        }

        /// <summary>
        /// This method will be called by the subject when an observed key is
        /// pressed
        /// </summary>
        /// <param name="notification"></param>
        public void Notify(ConsoleKey notification) {
            lock (queueLock) {
                observedKeys.Enqueue(notification);
            }
        }

        /// <summary>
        /// Return the currently observed keys
        /// </summary>
        /// <returns>IEnumerable with the keys</returns>
        public IEnumerable<ConsoleKey> GetCurrentKeys() {
            IEnumerable<ConsoleKey> currentKeys;
            lock (queueLock) {
                currentKeys = observedKeys.ToArray();
                observedKeys.Clear();
            }

            return currentKeys;
        }
    }
}
