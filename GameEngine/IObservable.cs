using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// Interface to be implemented by observable subjects
    /// </summary>
    /// <typeparam name="T">Type of the observale</typeparam>
    public interface IObservable<T> {
        /// <summary>
        /// Register an observer
        /// </summary>
        /// <param name="whatToObserve">What to not observe</param>
        /// <param name="observer">The observer</param>
        void RegisterObserver(IEnumerable<T> whatToObserve,
            IObserver<T> observer);

        /// <summary>
        /// Remove an observer
        /// </summary>
        /// <param name="whatToObserve">What to not observe</param>
        /// <param name="observer">The observer</param>
        void RemoveObserver(T whatToObserve, IObserver<T> observer);

        /// <summary>
        /// Remove observer
        /// </summary>
        /// <param name="observer">The observer</param>
        void RemoveObserver(IObserver<T> observer);
    }
}
