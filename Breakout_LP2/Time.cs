using GameEngine;

namespace Breakout_LP2 {
    /// <summary>
    /// Displays the time class
    /// </summary>
    public class Time : Component {
        /// <summary>
        /// Destroys the Time component
        /// </summary>
        public override void Finish() {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
