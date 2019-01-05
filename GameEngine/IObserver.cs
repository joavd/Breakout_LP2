namespace GameEngine {

    // Interface to be implemented by observer subjects
    public interface IObserver<T> {

        void Notify(T notification);
    }
}
