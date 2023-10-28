using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Classe contenant les clients handles
    /// </summary>
    public static class ItemClientHandle
    {
        // elle pourait etre refaite
        public const int v_ALIMENTATION = 0;
        public const int v_SOUTIRAGE = 1;
        public const int v_TROPPLEIN = 2;
        public const int fm_ALIMENTATION = 3;
        public const int fm_SOUTIRAGE = 4;
        public const int NIVEAU = 5;
        public const int TEMPERATURE = 6;
        public const int AGITATEUR = 7;
    }
    /// <summary>
    /// Classe qui indique l'indice les tableaux vannes[] et flowmeters[]
    /// </summary>
    public static class ValveType
    {
        public const int ALIMENTATION = 0;
        public const int SOUTIRAGE = 1;
        public const int TROP_PLEIN = 2;
    }

    /// <summary>
    /// Classe representant la cuve physique ainsi que ses composants
    /// </summary>
    internal class Cuve : IDrawable
    {
        private Graphics _container;
        private int x;
        private int y;

        private float scale;

        private float niveau;

        private const int NIVEAU_MAX = 4;
        private List<TemperatureData> _temperatures;

        public Vanne[] vannes;
        public FlowMeter[] flowmeters;
        public Agitateur agitateur;

        public Cuve(Graphics graphic) 
        {
            this._container = graphic;
            this.niveau = -1;

            vannes = new Vanne[3];

            vannes[ValveType.ALIMENTATION] = new Vanne(graphic);
            vannes[ValveType.SOUTIRAGE] = new Vanne(graphic);
            vannes[ValveType.TROP_PLEIN] = new Vanne(graphic);

            flowmeters = new FlowMeter[2];

            flowmeters[ValveType.ALIMENTATION] = new FlowMeter(graphic);
            flowmeters[ValveType.SOUTIRAGE] = new FlowMeter(graphic);

            agitateur = new Agitateur(graphic);

            scale = 1.0f;

            _temperatures = new List<TemperatureData>();

        }
        public void drawGraphic()
        {
            // C : coté
            // W : width
            // L : length
            // R : ratio
            // D : diameter

            this._container.Clear(Color.Transparent);


            int C_CORE = (int)(200 * this.scale);

            float R_INSIDE = 0.84f;

            int W_PIPE = (int)(16 * this.scale);
            int W_WATER = (int)(6 * this.scale);
            int W_BORDER = (int)(C_CORE * (1 - R_INSIDE) / 2);
            int W_BORDER_PIPE_WATER = (W_PIPE - W_WATER) / 2;
            int W_COMPONENT = (int)(32 * this.scale);

            int L_PIPE = (int)(50 * this.scale);

            int Y_PIPE_RIGHT = (int)(C_CORE * 0.15f);
            int Y_PIPE_LEFT = (int)(C_CORE * 0.10f);

            float side_rect_inside = (C_CORE * R_INSIDE);



            //float calcul = (C_CORE * R_INSIDE); //168
            //int casted = (int)calcul; //168
            //int direct = (int)(C_CORE * R_INSIDE); //167 ???????? pourquoi ???


            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // structure
            Rectangle rect_outside = new Rectangle(this.x, this.y, C_CORE, C_CORE);
            Rectangle rect_inside = new Rectangle(this.x + W_BORDER, this.y, (int)side_rect_inside, (int)side_rect_inside+ W_BORDER);
            Rectangle pipeRight = new Rectangle(this.x + C_CORE, this.y + Y_PIPE_RIGHT, L_PIPE, W_PIPE);
            Rectangle pipeRightEnd = new Rectangle(pipeRight.X + L_PIPE + W_COMPONENT, pipeRight.Y, L_PIPE, W_PIPE);
            Rectangle pipeLeft = new Rectangle(this.x - L_PIPE/2, this.y + Y_PIPE_LEFT, L_PIPE/2, W_PIPE);
            Rectangle pipeLeftStart = new Rectangle(pipeLeft.X - L_PIPE *3 - W_COMPONENT, pipeLeft.Y, L_PIPE *3, W_PIPE);
            Rectangle pipeBottom = new Rectangle(this.x + C_CORE/2 - W_PIPE/2, this.y + C_CORE, W_PIPE, (int)(L_PIPE * 0.6f));
            Rectangle pipeBottomRight = new Rectangle(pipeBottom.X, pipeBottom.Y + pipeBottom.Height, L_PIPE*3, W_PIPE);
            Rectangle pipeEnd = new Rectangle(pipeBottomRight.X + pipeBottomRight.Width + W_COMPONENT, pipeBottomRight.Y, L_PIPE, W_PIPE);
            
            // eau
            int niv_pix = convertNiveauToPixel(C_CORE);
            Rectangle rect_niveau = new Rectangle(rect_inside.X, C_CORE-W_BORDER - niv_pix + this.y, (int)side_rect_inside, niv_pix);

            Rectangle waterStart = new Rectangle(pipeLeftStart.X, pipeLeftStart.Y + W_BORDER_PIPE_WATER, pipeLeftStart.Width, W_WATER);
            Rectangle waterEnd = new Rectangle(pipeEnd.X, pipeEnd.Y + W_BORDER_PIPE_WATER, L_PIPE, W_WATER);
            Rectangle waterRight = new Rectangle(rect_inside.X + rect_inside.Width, pipeRight.Y + W_BORDER_PIPE_WATER, L_PIPE + W_BORDER, W_WATER);
            Rectangle waterRightEnd = new Rectangle(pipeRightEnd.X, pipeRightEnd.Y + W_BORDER_PIPE_WATER, L_PIPE, W_WATER);
            Rectangle waterLeft = new Rectangle(pipeLeft.X, pipeLeft.Y + W_BORDER_PIPE_WATER, pipeLeft.Width + W_BORDER, W_WATER);
            Rectangle waterBottom = new Rectangle(pipeBottom.X + W_BORDER_PIPE_WATER, rect_inside.Y + rect_inside.Height, W_WATER, pipeBottom.Height + W_BORDER + 2* W_BORDER_PIPE_WATER);
            Rectangle waterBottomRight = new Rectangle(pipeBottomRight.X + W_BORDER_PIPE_WATER, pipeBottomRight.Y + W_BORDER_PIPE_WATER, pipeBottomRight.Width - W_BORDER_PIPE_WATER, W_WATER);
            Rectangle waterDropCuve = new Rectangle(this.x + W_BORDER, waterLeft.Y, W_WATER, C_CORE - waterLeft.Y + rect_outside.Y - W_BORDER);

            // l'ordre de dessin importe

            this._container.FillRectangle(blackBrush, rect_outside);
            this._container.FillRectangle(grayBrush, rect_inside);
            this._container.FillRectangle(blackBrush, pipeRight);
            this._container.FillRectangle(blackBrush, pipeRightEnd);
            this._container.FillRectangle(blackBrush, pipeLeft);
            this._container.FillRectangle(blackBrush, pipeBottom);
            this._container.FillRectangle(blackBrush, pipeBottomRight);
            this._container.FillRectangle(blackBrush, pipeEnd);
            this._container.FillRectangle(blackBrush, pipeLeftStart);

            //Water
            this._container.FillRectangle(blueBrush, rect_niveau);
            this._container.FillRectangle(blueBrush, waterStart);

            if ((bool)vannes[ValveType.ALIMENTATION].getValue()) this._container.FillRectangle(blueBrush, waterDropCuve);

            drawPercentageWater(calculatePercentage(50, -156.5f, W_WATER), waterRightEnd, (bool)vannes[ValveType.TROP_PLEIN].getValue());
            drawPercentageWater(calculatePercentage(50, -156.5f, W_WATER), waterRight, true);

            
            drawPercentageWater(calculatePercentage(50, -167, W_WATER), waterLeft, true);
            if((bool)vannes[ValveType.ALIMENTATION].getValue()) this._container.FillRectangle(blueBrush, waterLeft);

            drawVoidOrWater((bool)vannes[ValveType.SOUTIRAGE].getValue() && this.niveau > 0, waterEnd);
            drawVoidOrWater(this.niveau > 0, waterBottom);
            drawVoidOrWater(this.niveau > 0, waterBottomRight);

            vannes[ValveType.ALIMENTATION].place(pipeLeft.X - W_COMPONENT, pipeLeft.Y - W_PIPE/2);
            vannes[ValveType.TROP_PLEIN].place(pipeRight.X + pipeRight.Width, pipeRight.Y - W_PIPE/2);
            vannes[ValveType.SOUTIRAGE].place(pipeBottomRight.X + pipeBottomRight.Width, pipeBottomRight.Y - W_PIPE/2);

            vannes[ValveType.ALIMENTATION].drawGraphic();
            vannes[ValveType.SOUTIRAGE].drawGraphic();
            vannes[ValveType.TROP_PLEIN].drawGraphic();

            flowmeters[ValveType.ALIMENTATION].place(pipeLeftStart.X + 10 * L_PIPE / 8, pipeLeftStart.Y - W_PIPE/2);
            flowmeters[ValveType.SOUTIRAGE].place(pipeBottomRight.X + 10* L_PIPE/8, pipeBottomRight.Y - W_PIPE/2);

            flowmeters[ValveType.ALIMENTATION].drawGraphic();
            flowmeters[ValveType.SOUTIRAGE].drawGraphic();

            agitateur.place(x + C_CORE/2 - W_PIPE/2, y);
            agitateur.drawGraphic();
        }

        private int calculatePercentage(int a,  float b, int max)
        {
            return Math.Max(Math.Min((int)(this.scale * 100f * (this.niveau * a + b) / max ) , 100), 0); // calcul linéaire d'un pourcentage de replissage d'un tuyau le pourcentage e [0 , 100]
        }

        private void drawPercentageWater(int percent, Rectangle rect, bool is_open)
        {
            //Console.WriteLine("percent : {0}, recovered value : {1}", percent, Math.Ceiling((double) percent / 100f *6));
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            Rectangle water = new Rectangle(rect.Location, rect.Size);

            water.Height = (int) Math.Ceiling((double)(percent / 100f * water.Height));
            water.Y += rect.Height - water.Height;

            this._container.FillRectangle(grayBrush, rect);
            if(is_open) this._container.FillRectangle(blueBrush, water);
        }

        private void drawVoidOrWater(bool condition, Rectangle rect)
        {
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush b;
            if (condition) b = blueBrush;
            else b = grayBrush;

            this._container.FillRectangle(b, rect);
        }

        public object getValue()
        {
            return this.niveau;
        }

        public void place(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool setValue(object val)
        {
            // retourne vrai si la valeur a été prise en compte
            float temp = Convert.ToSingle(val);
            if (Math.Abs(temp - this.niveau) > 0.1)
            {
                this.niveau = temp;
                return true;
            }
            return false;
        }

        private int convertNiveauToPixel(int height_cuve)
        {
            if(this.niveau < 0) return 0;

            int W_BORDER = (int)(height_cuve * (1 - 0.84f) / 2);

            return Math.Min((int)(this.niveau * (height_cuve - W_BORDER) / NIVEAU_MAX), (int)(height_cuve - W_BORDER));
        }

        public void setScale(float scale)
        {
            this.scale = scale;

            vannes[ValveType.ALIMENTATION].setScale(scale);
            vannes[ValveType.SOUTIRAGE].setScale(scale);
            vannes[ValveType.TROP_PLEIN].setScale(scale);

            flowmeters[ValveType.ALIMENTATION].setScale(scale);
            flowmeters[ValveType.SOUTIRAGE].setScale(scale);

            agitateur.setScale(scale);
        }

        public void move(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.niveau.GetHashCode() + this.scale.GetHashCode() + this.x.GetHashCode() + this.y.GetHashCode() + this.getLastTemperature().GetHashCode();
        }

        public void changeScale(int v)
        {
            float scale =  this.scale + v/10f;
            if (scale >0) setScale(scale);
        }

        public bool addTemperature(float temperature) 
        {
            // retourne vrai si la valeur a été prise en compte
            if (Math.Abs(temperature - getLastTemperature()) > 0.3f)
            {
                _temperatures.Add(new TemperatureData(temperature, DateTime.Now));
                if (_temperatures.Count > 30) _temperatures.RemoveAt(0);
                return true;
            }
            return false;
        }
        
        public float getLastTemperature()
        {
            if(_temperatures.Count==0) return -290f;

            return _temperatures.Last().temperature;
        }

        public void getTemperatures(out List<TemperatureData> temperatures)
        {
            temperatures = this._temperatures;
        }

        public int checkIfOnVanne(int x, int y)
        {
            // retourne l'index de la vanne concernée

            // verification si les coordonées du click se trouvent sur la zone de dessin d'une des vannes
            int index = 0;
            foreach (Vanne v in vannes)
            {
                Rectangle r = v.getArea();
                if (x > r.X && x < r.X + r.Width && y > r.Y && y < r.Y + r.Height) return index;
                index++;
            }

            return -1;
        }
    }
}

