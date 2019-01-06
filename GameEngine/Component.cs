namespace GameEngine {
    /// <summary>
    /// All game object components must implement this interface
    /// </summary>
    public abstract class Component : BaseGameObject {
        /// <summary>
        /// Reference to the parent game object
        /// </summary>
        public GameObject ParentGameObject { get; internal set; }

        /// <summary>
        /// Reference to the parent scene
        /// </summary>
        public Scene ParentScene => ParentGameObject.ParentScene;
    }
}
