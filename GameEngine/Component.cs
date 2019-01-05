namespace GameEngine {

    // All game object components must implement this interface
    public abstract class Component : BaseGameObject {

        // Reference to the parent game object
        public GameObject ParentGameObject { get; internal set; }
        // Reference to the parent scene
        public Scene ParentScene => ParentGameObject.ParentScene;
    }
}
