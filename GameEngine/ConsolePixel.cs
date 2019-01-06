using System;

namespace GameEngine {
    /// <summary>
    /// Represents a console pixel with the shape (char), foreground color and
    /// brackground color
    /// </summary>
    public struct ConsolePixel {
        /// <summary>
        /// Shape of the object
        /// </summary>
        public readonly char shape;
        /// <summary>
        /// Foreground color
        /// </summary>
        public readonly ConsoleColor foregroundColor;
        /// <summary>
        /// Background color
        /// </summary>
        public readonly ConsoleColor backgroundColor;
        
        /// <summary>
        /// Is this pixel renderable?
        /// </summary>
        public bool IsRenderable {
            get {
                // The pixel is renderable if any of its fields is not the
                // default to the speficic type
                return !shape.Equals(default(char))
                    && !foregroundColor.Equals(default(ConsoleColor))
                    && !backgroundColor.Equals(default(ConsoleColor));
            }
        }

        // Below there are several constructor for building a console pixel

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsolePixel"/> class.
        /// </summary>
        /// <param name="shape">Shape</param>
        /// <param name="foregroundColor">Foreground color</param>
        /// <param name="backgroundColor">Background color</param>
        public ConsolePixel(char shape, ConsoleColor foregroundColor,
            ConsoleColor backgroundColor) {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsolePixel"/> class.
        /// </summary>
        /// <param name="shape">Shape</param>
        /// <param name="foregroundColor">Foreground color</param>
        public ConsolePixel(char shape, ConsoleColor foregroundColor) {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            backgroundColor = Console.BackgroundColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsolePixel"/> class.
        /// </summary>
        /// <param name="shape">Shape</param>
        public ConsolePixel(char shape) {
            this.shape = shape;
            foregroundColor = Console.ForegroundColor;
            backgroundColor = Console.BackgroundColor;
        }
    }
}
