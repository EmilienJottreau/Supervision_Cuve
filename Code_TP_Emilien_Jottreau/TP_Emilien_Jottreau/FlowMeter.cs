using System;
using System.Drawing;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Classe representant un debitmetre physique
    /// </summary>
    internal class FlowMeter : IDrawable
    {
        private Graphics _container;
        private int x;
        private int y;

        private float scale;

        private const int MAX_DEBIT = 10;

        private float _debit;

        public FlowMeter(Graphics graphic) 
        {
            this._container = graphic;

            this.scale = 1.0f;
        }

        public void drawGraphic()
        {
            // C : coté
            // W : width
            // L : length
            // R : ratio
            // D : diameter
            int C_CORE = (int)(32* this.scale);
            int W_PIPE = (int)(16 * this.scale);
            int W_WATER = (int)(6 * this.scale);
            int W_EDGE = (int)(4 * this.scale);
            int L_PIPE = (int)(20 * this.scale);
            float R_EDGE = 0.625f;
            int D_CIRCLE = (int)(24 * this.scale);


            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush grayBrush = new SolidBrush(Color.White);
            Pen redPen = new Pen(Color.Red);


            Rectangle edgeStart = new Rectangle(x - L_PIPE - W_EDGE, y + (C_CORE - (int)(C_CORE * R_EDGE)) /2, W_EDGE, (int)(C_CORE * R_EDGE));
            Rectangle pipeStart = new Rectangle(x - L_PIPE ,y + C_CORE / 4 , L_PIPE, W_PIPE);
            Rectangle boxContainer = new Rectangle(x, y, C_CORE, C_CORE);
            Rectangle upperCircle = new Rectangle(x+ (C_CORE-D_CIRCLE) / 2, y+ (C_CORE - D_CIRCLE) / 2, D_CIRCLE, D_CIRCLE);
            Point startIndicator = new Point(x+C_CORE/2,y+C_CORE/2);
            Point endIndicator = calculateEndIndicator();
            Rectangle lowerRectangle = new Rectangle(x + C_CORE/8, y + 5*C_CORE /8, 6*C_CORE / 8, 3 * C_CORE / 8);
            Rectangle pipeEnd = new Rectangle(x + C_CORE , y + C_CORE / 4, L_PIPE, W_PIPE);
            Rectangle edgeEnd = new Rectangle(x + C_CORE + L_PIPE, y + (C_CORE - (int)(C_CORE * R_EDGE)) / 2, W_EDGE, (int)(C_CORE * R_EDGE));


            this._container.FillRectangle(blackBrush, edgeStart);
            this._container.FillRectangle(blackBrush, pipeStart);
            this._container.FillRectangle(blackBrush, boxContainer);
            this._container.FillRectangle(blackBrush, pipeEnd);
            this._container.FillRectangle(blackBrush, edgeEnd);
            this._container.FillEllipse(grayBrush, upperCircle);
            this._container.DrawLine(redPen, startIndicator, endIndicator);
            this._container.FillRectangle(blackBrush, lowerRectangle);
        }

        private Point calculateEndIndicator()
        {
            //conversion de debit en % du debit maximum
            float debit_scaled = 100/MAX_DEBIT * this._debit;

            //si le debit varie entre 0 et 100
            // regressions pour animer l'aiguille
            int x_debit = (int)(debit_scaled * 0.28 * this.scale);
            int y_debit = (int)((debit_scaled * debit_scaled * 0.0059 - debit_scaled * 0.5942 + 17.884) * this.scale);//y = 0,0059x2 - 0,5942x + 17,884

            return new Point(this.x + 2 + x_debit, this.y + y_debit);
        }

        public object getValue()
        {
            return this._debit;
        }

        public void place(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void setValue(object val)
        {
            float temp = Math.Max(Math.Min(Convert.ToSingle(val), MAX_DEBIT), 0);
            this._debit = temp;
        }

        public void setScale(float scale)
        {
            this.scale = scale;
        }

        public override string ToString()
        {
            return this._debit.ToString() + " L/s";
        }
    }
}
