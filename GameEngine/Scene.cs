using System;
using System.Threading;
using System.Linq;
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

        public void DestroyObject(GameObject gameObject) {
            gameObjects.Remove(gameObject.Name, out gameObject);
        }

        // Terminate scene
        public void Terminate() {
            terminate = true;
        }

        // Game loop
        public void GameLoop(int msFramesPerSecond) {
            double previous = DateTime.Now.Ticks;
            double lag = 0.0;
            double ms = 16;

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
                double current = DateTime.Now.Ticks;
                double elapsed = current - previous;
                previous = current;
                lag += elapsed;

                while (lag >= ms) {
                    lag -= ms;
                }

                // Update game objects
                foreach (GameObject gameObject in gameObjects.Values.ToList()) {
                    gameObject.Update();
                }

                // Render current frame
                renderer?.Render(gameObjects.Values);
            }

            // Teardown the game objects in this scene
            foreach (GameObject gameObject in gameObjects.Values.ToList()) {
                gameObject.Finish();
            }

            // Render current frame
            renderer?.Render(gameObjects.Values);

            // Stop reading input
            inputHandler.StopReadingInput();

            // Teardown renderer
            renderer?.Finish();
        }
    }
}
