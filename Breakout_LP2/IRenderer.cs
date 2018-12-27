using System;
using System.Collections.Generic;
using System.Text;

namespace Breakout_LP2 {
    public interface IRenderer {
        // Método que faz o setup inicial antes da renderização começar
        void Setup(IBuffer2D<int> worldToRender);

        // Método que realiza a renderização do game of life
        void Render(IBuffer2D<int> worldToRender);
    }
}
