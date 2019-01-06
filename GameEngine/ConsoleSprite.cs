using System;
using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// Represents a console sprite
    /// </summary>
    public class ConsoleSprite : RenderableComponent {
        /// <summary>
        /// Since a console sprite is a renderable component, it must implement
        /// this property, which returns an ienumerable of position-pixel pairs
        /// to render
        /// </summary>
        public override
        IEnumerable<KeyValuePair<Vector2, ConsolePixel>> Pixels => pixels;

        // The position-pixel pairs are actually kept here
        private IDictionary<Vector2, ConsolePixel> pixels;

        // Below there are several constructors for this class

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleSprite"/> class.
        /// </summary>
        /// <param name="pixels">Pixels to draw</param>
        public ConsoleSprite(IDictionary<Vector2, ConsolePixel> pixels) {
            this.pixels = new Dictionary<Vector2, ConsolePixel>(pixels);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleSprite"/> class.
        /// </summary>
        /// <param name="pixels">Pixels to draw</param>
        public ConsoleSprite(ConsolePixel[,] pixels) {
            this.pixels = new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < pixels.GetLength(0); x++) {
                for (int y = 0; y < pixels.GetLength(1); y++) {
                    ConsolePixel cpixel = pixels[x, y];
                    if (cpixel.IsRenderable) {
                        this.pixels[new Vector2(x, y)] = cpixel;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleSprite"/> class.
        /// </summary>
        /// <param name="pixels">Pixels to draw</param>
        public ConsoleSprite(char[,] pixels) {
            this.pixels = new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < pixels.GetLength(0); x++) {
                for (int y = 0; y < pixels.GetLength(1); y++) {
                    char shape = pixels[x, y];
                    if (!shape.Equals(default(char))) {
                        this.pixels[new Vector2(x, y)] =
                            new ConsolePixel(shape);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleSprite"/> class.
        /// </summary>
        /// <param name="pixels">Pixels to draw</param>
        /// <param name="fgColor">Foreground color</param>
        /// <param name="bgColor">Background color</param>
        public ConsoleSprite(char[,] pixels,
            ConsoleColor fgColor, ConsoleColor bgColor) {
            this.pixels = new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < pixels.GetLength(0); x++) {
                for (int y = 0; y < pixels.GetLength(1); y++) {
                    char shape = pixels[x, y];
                    if (!shape.Equals(default(char))) {
                        this.pixels[new Vector2(x, y)] =
                            new ConsolePixel(shape, fgColor, bgColor);
                    }
                }
            }
        }
    }
}
