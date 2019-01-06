using System;
using GameEngine;

namespace Breakout_LP2 {
    /// <summary>
    /// A script which controls the player, implemented as a component
    /// </summary>
    public class Player : Component {

        // Player script requries access to the key observer and position
        // components
        private KeyObserver keyObserver;
        private Position position;
        
        /// <summary>
        /// Initialize player
        /// </summary>
        public override void Start() {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();
        }
        
        /// <summary>
        /// Update player in the current frame
        /// </summary>
        public override void Update() {
            // Get player position
            float x = position.Pos.X;

            // Check what keys were pressed and update position accordingly
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys()) {
                switch (key) {
                    case ConsoleKey.RightArrow:
                        x += 2;
                        break;
                    case ConsoleKey.LeftArrow:
                        x -= 2;
                        break;
                }
            }

            // Make sure player doesn't get outside of game area
            x = Math.Clamp(x, 1, ParentScene.xdim - 8);

            // Update player position
            position.Pos = new Vector3(x, position.Pos.Y, position.Pos.Z);
        }

        /// <summary>
        /// Destroys the player
        /// </summary>
        public override void Finish() {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
