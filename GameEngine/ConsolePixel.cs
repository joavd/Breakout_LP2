﻿using System;

namespace GameEngine {

    // Represents a console pixel with the shape (char), foreground color and
    // brackground color
    public struct ConsolePixel {

        public readonly char shape;
        public readonly ConsoleColor foregroundColor;
        public readonly ConsoleColor backgroundColor;

        // Is this pixel renderable?
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

        public ConsolePixel(char shape, ConsoleColor foregroundColor,
            ConsoleColor backgroundColor) {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
        }

        public ConsolePixel(char shape, ConsoleColor foregroundColor) {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            backgroundColor = Console.BackgroundColor;
        }

        public ConsolePixel(char shape) {
            this.shape = shape;
            foregroundColor = Console.ForegroundColor;
            backgroundColor = Console.BackgroundColor;
        }
    }
}
