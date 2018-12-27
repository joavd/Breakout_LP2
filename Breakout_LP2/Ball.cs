using System;
using System.Collections.Generic;
using System.Text;

namespace Breakout_LP2 {
    public class Ball : IGameobject {
        private int xMove;
        private int yMove;

        public int X { get; private set; }

        public int Y { get; private set; }

        public Ball(int x, int y) {
            X = x;
            Y = y;
            yMove = -1;
        }

        public void Update(DoubleBuffer2D<IGameobject> world) {
            if (world[X, Y + yMove] == null) {
                world[X, Y + yMove] = this;
                world[X, Y] = null;
                Y += yMove;
            } else {
                yMove *= -1;
            }
        }

        public void OnCollide() {

        }

        public string Render() {
            return "o";
        }
    }
}
