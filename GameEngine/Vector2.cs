namespace GameEngine {
    /// <summary>
    /// Basic implementation of a 2D vector
    /// </summary>
    public class Vector2 {
        /// <summary>
        /// X position
        /// </summary>
        public float X { get; }
        /// <summary>
        /// Y position
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> class.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Vector2(float x, float y) {
            X = x;
            Y = y;
        }
    }
}
