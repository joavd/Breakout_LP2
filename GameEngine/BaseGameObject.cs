namespace GameEngine {
    /// <summary>
    /// Abstract base game object class which provides default implementations
    /// of the methods invoked before, during and after the game loop
    /// </summary>
    public abstract class BaseGameObject : IGameObject {
        /// <summary>
        /// Virtual method for when the game object is created
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// Virtual method to update the game object
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Virtual method to delete the object
        /// </summary>
        public virtual void Finish() { }
    }
}
