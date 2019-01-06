namespace GameEngine {
    /// <summary>
    /// Interface all game objects must obey
    /// </summary>
    public interface IGameObject {

        /// <summary>
        /// Start method for gameobjects
        /// </summary>
        void Start();

        /// <summary>
        /// Update method for gameobjects
        /// </summary>
        void Update();

        /// <summary>
        /// Finish method for gameobjects
        /// </summary>
        void Finish();
    }
}
