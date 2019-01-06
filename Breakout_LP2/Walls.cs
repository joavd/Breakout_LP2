using GameEngine;

namespace Breakout_LP2 {
    /// <summary>
    /// Walls Gameobject
    /// </summary>
    public class Walls : Component {
        /// <summary>
        /// Destroys the walls
        /// </summary>
        public override void Finish() {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
