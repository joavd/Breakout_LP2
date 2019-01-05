using System.Collections.Generic;

namespace GameEngine {

    // Abstract base game object class which provides default implementations
    // of the methods invoked before, during and after the game loop
    public abstract class BaseGameObject : IGameObject {

        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void Finish() { }
    }
}
