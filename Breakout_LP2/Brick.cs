using System;
using System.Collections.Generic;
using System.Text;

namespace Breakout_LP2 {
    class Brick : IGameobject {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Brick(int x, int y) {
            X = x;
            Y = y;
        }

        public void Update(DoubleBuffer2D<IGameobject> world) {

        }

        public void OnCollide() {

        }

        public string Render() {
            return "-";
        }
    }
}
