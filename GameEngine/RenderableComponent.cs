using System.Collections.Generic;

namespace GameEngine {

    // Renderable components must extend this class
    public abstract class RenderableComponent : Component {

        public abstract IEnumerable<KeyValuePair<Vector2, ConsolePixel>>
            Pixels { get; }
    }
}
