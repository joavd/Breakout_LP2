namespace GameEngine {
    /// <summary>
    /// Interface to be implemented by observer subjects
    /// </summary>
    /// <typeparam name="T">Type of the notification</typeparam>
    public interface IObserver<T> {
        /// <summary>
        /// Notify the observer
        /// </summary>
        /// <param name="notification">The notification to give</param>
        void Notify(T notification);
    }
}
