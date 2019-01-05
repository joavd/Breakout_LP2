using System;
using GameEngine;

namespace Breakout_LP2 {
    public class Ball : Component {

        private int xMove = 0;
        private int yMove = -1;

        // Ball script requries access to the key observer and position
        // components
        private Position position;

        // Initialize player
        public override void Start() {
            position = ParentGameObject.GetComponent<Position>();
        }

        // Update ball in the current frame
        public override void Update() {
            // Get ball position
            float x = position.Pos.X;
            float y = position.Pos.Y;

            // If detects another object changes direction
            // Não sei ver como se encontra outro gameobject
            if (y + yMove <= 0 || y + yMove >= ParentScene.ydim - 1) {
                yMove *= -1;
            }

            if (true) {
                // Moves in the given direction
                x += xMove;
                y += yMove;
            }




            // Make sure ball doesn't get outside of game area
            y = Math.Clamp(y, 1, ParentScene.ydim - 1);

            // Update ball position
            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}
