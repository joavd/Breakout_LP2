namespace GameEngine {
    /// <summary>
    /// Basic implementation of a 3D vector
    /// </summary>
    public class Vector3 {
        /// <summary>
        /// X position
        /// </summary>
        public float X { get; }
        /// <summary>
        /// Y position
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// Z position
        /// </summary>
        public float Z { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="z">Z position</param>
        public Vector3(float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
