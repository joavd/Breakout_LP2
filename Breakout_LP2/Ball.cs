using System;
using System.Collections.Generic;
using System.Text;

namespace Breakout_LP2 {
    public class Ball : IGameobject {
        private int xMove;
        private int yMove;

        public int X { get; private set; }

        public int Y { get; private set; }

        public string Img { get; } = "o";

        public Ball(int x, int y) {
            X = x;
            Y = y;
            yMove = -1;
        }

        public void Update(DoubleBuffer2D<string> world) {
            // If detects another object changes direction
            if (world[X, Y + yMove] != null) {
                yMove *= -1;
            }
        }

        public void OnCollide() {

        }

        public void Render(DoubleBuffer2D<string> world) {
            if (world[X, Y + yMove] == null) {
                // Moves in the given direction
                X = X;
                Y += yMove;
            }
        }
    }
}
