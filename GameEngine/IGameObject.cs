namespace GameEngine {

    // Interface all game objects must obey
    public interface IGameObject {
        void Start();

        void Update();

        void Finish();
    }
}
