using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// Renderable components must extend this class
    /// </summary>
    public abstract class RenderableComponent : Component {

        /// <summary>
        /// Component to render
        /// </summary>
        public abstract IEnumerable<KeyValuePair<Vector2, ConsolePixel>>
            Pixels { get; }
    }
}
