using System;
using System.Threading;
using System.Collections.Generic;

namespace GameEngine {

    // This class represents a game scene
    public class Scene {

        // Scene dimensions
        public readonly int xdim;
        public readonly int ydim;

        // Input handler for this scene
        public readonly InputHandler inputHandler;

        // Game objects in this scene
        public Dictionary<string, GameObject> gameObjects;

        // Is the scene terminated?
        private bool terminate;

        // Renderer for this scene
        private ConsoleRenderer renderer;

        // Create a new scene
        public Scene(int xdim, int ydim, InputHandler inputHandler,
            ConsoleRenderer renderer) {
            this.xdim = xdim;
            this.ydim = ydim;
            this.inputHandler = inputHandler;
            this.renderer = renderer;
            terminate = false;
            gameObjects = new Dictionary<string, GameObject>();
        }

        // Add a game object to this scene
        public void AddGameObject(GameObject gameObject) {
            gameObject.ParentScene = this;
            gameObjects.Add(gameObject.Name, gameObject);
        }

        // Find a game object by name in this scene
        public GameObject FindGameObjectByName(string name) {
            return gameObjects[name];
        }

        // Terminate scene
        public void Terminate() {
            terminate = true;
        }

        // Game loop
        public void GameLoop(int msFramesPerSecond) {

            // Initialize all game objects
            foreach (GameObject gameObject in gameObjects.Values) {
                gameObject.Start();
            }

            // Initialize renderer
            renderer?.Start();

            // Start reading input
            inputHandler.StartReadingInput();

            // Perform the game loop until the scene is terminated
            while (!terminate) {
                // Time to wait until next frame
                int timeToWait;

                // Get real time in ticks (10000 ticks = 1 milisecond)
                long start = DateTime.Now.Ticks;

                // Update game objects
                foreach (GameObject gameObject in gameObjects.Values) {
                    gameObject.Update();
                }

                // Render current frame
                renderer?.Render(gameObjects.Values);

                // Time to wait until next frame
                timeToWait = (int)(start / 10000 + msFramesPerSecond
                    - DateTime.Now.Ticks / 10000);

                // If this time is negative, we cheat by making it zero
                // Note this should be handled with a more robust game loop
                // and not like this
                timeToWait = timeToWait > 0 ? timeToWait : 0;

                // Wait until next frame
                Thread.Sleep(timeToWait);
            }

            // Stop reading input
            inputHandler.StopReadingInput();

            // Teardown the game objects in this scene
            foreach (GameObject gameObject in gameObjects.Values) {
                gameObject.Finish();
            }

            // Teardown renderer
            renderer?.Finish();
        }
    }
}
