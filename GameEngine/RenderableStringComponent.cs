using System;
using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// This component renders a string given by a delegate method
    /// </summary>
    public class RenderableStringComponent : RenderableComponent {
        /// <summary>
        /// Since this is a renderable component, it must implement the Pixels
        /// property
        /// </summary>
        public override IEnumerable<KeyValuePair<Vector2, ConsolePixel>>
            Pixels {
            get {
                // Get the string to render
                string strToRender = getStr();

                // Cycle through the string
                for (int i = 0; i < strToRender.Length; i++) {
                    // Get position for the current character
                    Vector2 pos = getPos(i);

                    // Create a console pixel for the current character
                    ConsolePixel pix =
                        new ConsolePixel(strToRender[i], fgColor, bgColor);

                    // Return the position and the pixel to be rendered
                    yield return new
                        KeyValuePair<Vector2, ConsolePixel>(pos, pix);
                }
            }
        }

        // Delegate which returns a string to be rendered
        private Func<string> getStr;

        // Delegate which returns a position for every character in the string
        private Func<int, Vector2> getPos;

        // The foreground and background colors of the string to be rendered
        private ConsoleColor fgColor, bgColor;

        /// <summary>
        /// Create a new renderable string component
        /// </summary>
        /// <param name="getStr">The string</param>
        /// <param name="getPos">The position</param>
        /// <param name="fgColor">Foreground color</param>
        /// <param name="bgColor">Background color</param>
        public RenderableStringComponent(
            Func<string> getStr, Func<int, Vector2> getPos,
            ConsoleColor fgColor, ConsoleColor bgColor) {
            this.getStr = getStr;
            this.getPos = getPos;
            this.fgColor = fgColor;
            this.bgColor = bgColor;
        }
    }
}
