namespace Breakout_LP2 {
    public interface IGameobject {
        int X { get; }

        int Y { get; }

        void Update(DoubleBuffer2D<IGameobject> world);

        void OnCollide();

        string Render();
    }
}
