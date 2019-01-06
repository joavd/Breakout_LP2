using GameEngine;

namespace Breakout_LP2 {
    /// <summary>
    /// Gameobject Brick
    /// </summary>
    public class Brick : Component {
        /// <summary>
        /// Destroys the brick
        /// </summary>
        public override void Finish() {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
