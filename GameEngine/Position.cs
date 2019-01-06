namespace GameEngine {
    /// <summary>
    /// This component defines the position of a game object
    /// </summary>
    public class Position : Component {
        /// <summary>
        /// Position in the form of vector3
        /// </summary>
        public Vector3 Pos { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        public Position() {
            Pos = new Vector3(0f, 0f, 0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="z">Z position</param>
        public Position(float x, float y, float z) {
            Pos = new Vector3(x, y, z);
        }
    }
}
