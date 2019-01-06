using System;
using System.Linq;
using System.Collections.Generic;

namespace GameEngine {
    /// <summary>
    /// This class represents a game scene
    /// </summary>
    public class Scene {
        /// <summary>
        /// X dimension of the scene
        /// </summary>
        public readonly int xdim;
        /// <summary>
        /// Y dimension of the scene
        /// </summary>
        public readonly int ydim;

        public int points = 0;

        /// <summary>
        /// Input handler for this scene
        /// </summary>
        public readonly InputHandler inputHandler;

        /// <summary>
        /// Game objects in this scene
        /// </summary>
        public Dictionary<string, GameObject> gameObjects;

        // Is the scene terminated?
        private bool terminate;

        // Renderer for this scene
        private ConsoleRenderer renderer;


        /// <summary>
        /// Create a new scene
        /// </summary>
        /// <param name="xdim">X dimension</param>
        /// <param name="ydim">Y dimension</param>
        /// <param name="inputHandler">The input handler</param>
        /// <param name="renderer">The renderer</param>
        public Scene(int xdim, int ydim, InputHandler inputHandler,
            ConsoleRenderer renderer) {
            this.xdim = xdim;
            this.ydim = ydim;
            this.inputHandler = inputHandler;
            this.renderer = renderer;
            terminate = false;
            gameObjects = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// Add a game object to this scene
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject) {
            gameObject.ParentScene = this;
            gameObjects.Add(gameObject.Name, gameObject);
        }

        /// <summary>
        /// Find a game object by name in this scene
        /// </summary>
        /// <param name="name">Name of the object</param>
        /// <returns>The object</returns>
        public GameObject FindGameObjectByName(string name) {
            return gameObjects[name];
        }

        /// <summary>
        /// Destroys an object by name in this scene
        /// </summary>
        /// <param name="gameObject"></param>
        public void DestroyObject(GameObject gameObject) {
            gameObjects.Remove(gameObject.Name, out gameObject);
        }

        /// <summary>
        /// Terminate scene
        /// </summary>
        public void Terminate() {
            terminate = true;
        }

        /// <summary>
        /// Game loop using gaffer on game's implementation
        /// </summary>
        public void GameLoop() {
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

                // Update game objects
                foreach (GameObject gameObject in gameObjects.Values.ToList()) {
                    gameObject.Update();
                }

                while (lag >= ms) {
                    lag -= ms;
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

            return;
        }
    }
}
