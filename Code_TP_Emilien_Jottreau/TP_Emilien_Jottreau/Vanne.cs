using System.Drawing;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Classe representant une vanne physique
    /// </summary>
    internal class Vanne : IDrawable
    {
        private Graphics _container;
        private int x;
        private int y;

        private float scale;

        private bool etat; //0 : fermée, //1 ouverte

        public Vanne(Graphics graphic) { 
            this._container = graphic;

            this.scale = 1.0f;
        }
        public void drawGraphic()
        {
            // R : ratio
            // C : coté
            // D : diameter
            // L : length
            // W : width
            int C_CORE = (int)(32 * this.scale);
            int D_CIRCLE = (int)(8 * this.scale);
            int L_HANDLE = (int)(40 * this.scale);
            int W_HANDLE = (int)(10 * this.scale);
            int W_MARGIN = (int)((W_HANDLE - D_CIRCLE)/2);

            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.Red);


            Rectangle rect_outside = new Rectangle(x, y, C_CORE, C_CORE);
            Rectangle valve_handle = new Rectangle(x + C_CORE / 2 + W_HANDLE / 2 - L_HANDLE, y + C_CORE / 2 - W_HANDLE / 2, L_HANDLE, W_HANDLE);
            Rectangle circleValve_handle = new Rectangle(valve_handle.X + W_MARGIN, valve_handle.Y + W_MARGIN, D_CIRCLE, D_CIRCLE);

            if (this.etat == false) // vanne fermée
            {
                // deplacement de la poignée
                valve_handle.X = x + C_CORE / 2 + W_HANDLE / 2 - W_HANDLE;
                valve_handle.Width = W_HANDLE;
                valve_handle.Height = L_HANDLE;

                //deplacement du cercle sur la poignée
                circleValve_handle.X = valve_handle.X + W_MARGIN;
                circleValve_handle.Y = valve_handle.Y + L_HANDLE - D_CIRCLE - W_MARGIN;
            }

            this._container.FillRectangle(blackBrush, rect_outside);
            this._container.FillRectangle(redBrush, valve_handle);
            this._container.FillEllipse(grayBrush, circleValve_handle);
        }

        public object getValue()
        {
            return this.etat;
        }

        public void place(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void setValue(object val)
        {
            this.etat = (bool)val;
        }

        public void setScale(float scale)
        {
            this.scale = scale;
        }

        public override string ToString()
        {
            if (this.etat) return "ouverte";
            else return "fermée";
        }

        public Rectangle getArea()
        {
            return new Rectangle(x, y, (int)(32 * this.scale), (int)(32 * this.scale));
        }
    }
}
