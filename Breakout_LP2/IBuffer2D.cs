namespace Breakout_LP2 {
    public interface IBuffer2D<T> {
        int XDim { get; }
        int YDim { get; }
        T this[int x, int y] { get; }
    }
}
