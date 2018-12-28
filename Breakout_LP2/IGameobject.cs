namespace Breakout_LP2 {
    public interface IGameobject {
        int X { get; }

        int Y { get; }

        string Img { get; }

        void Update(DoubleBuffer2D<string> world);

        void OnCollide();

        void Render(DoubleBuffer2D<string> world);
    }
}
