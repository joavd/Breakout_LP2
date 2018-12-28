using System;
using System.Collections.Generic;
using System.Text;

namespace Breakout_LP2 {
    class Brick : IGameobject {
        public int X { get; private set; }

        public int Y { get; private set; }

        public string Img { get; } = "-";

        public Brick(int x, int y) {
            X = x;
            Y = y;
        }

        public void Update(DoubleBuffer2D<string> world) {
        }

        public void OnCollide() {

        }

        public void Render(DoubleBuffer2D<string> world) {
        }
    }
}
