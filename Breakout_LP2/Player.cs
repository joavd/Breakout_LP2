using System;
using System.Collections.Generic;
using System.Text;

namespace Breakout_LP2 {
    class Player : IGameobject {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Player(int x, int y) {
            X = x;
            Y = y;
        }

        public void Update(DoubleBuffer2D<IGameobject> world) {
            world[X, Y] = this;
        }

        public void OnCollide() {

        }

        public string Render() {
            return "=";
        }
    }
}
