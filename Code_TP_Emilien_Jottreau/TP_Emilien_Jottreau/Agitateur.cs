using System;
using System.Diagnostics;
using System.Drawing;
using System.Timers;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Classe representant un Agitateur physique
    /// </summary>
    internal class Agitateur : IDrawable
    {

        private Graphics _container;
        private int x;
        private int y;

        private float scale;

        private bool etat; //0 : éteint, //1 allumé

        public int step; // [0-3]

        //pour le faire tourner
        private Timer timer;

        //pour chronometrer le temps d'activation
        private Stopwatch chrono;

        private TimeSpan totalTimeElapsed;

        public Agitateur(Graphics graphic)
        {
            this._container = graphic;

            this.scale = 1.0f;
            this.etat = false;
            this.step = 0;

            timer = new Timer(250);
            timer.Elapsed += rotate;

            chrono = new Stopwatch();
        }

        private void rotate(object sender, ElapsedEventArgs e)
        {
            this.step = (this.step + 1) % 4;
        }

        public void drawGraphic()
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            int H_TIGE = (int)(140 * this.scale);
            int W_TIGE = (int)(16 * this.scale);
            int W_PALE = (int)(10 * this.scale);
            int L_PALE = (int)(40 * this.scale);
            int OFFSET_PALE = (int)(5 * this.scale);


            Rectangle tige = new Rectangle(x, y, W_TIGE, H_TIGE);
            Rectangle bottom = new Rectangle(x - L_PALE / 2 + W_TIGE/2, y + tige.Height, L_PALE, W_PALE);
            Rectangle pale_gauche = new Rectangle(x - L_PALE, y + tige.Height, L_PALE, W_PALE);
            Rectangle pale_droite = new Rectangle(x + tige.Width, y + tige.Height, L_PALE, W_PALE);

            this._container.FillRectangle(blackBrush, tige);
            this._container.FillRectangle(blackBrush, bottom);

            if (this.step % 2 == 0) return;
            
            if (this.step == 1)
            {
                pale_gauche.Y -= OFFSET_PALE;
                pale_droite.Y += OFFSET_PALE;
            } 
            else
            {
                pale_gauche.Y += OFFSET_PALE;
                pale_droite.Y -= OFFSET_PALE;
            }

            this._container.FillRectangle(blackBrush, pale_gauche);
            this._container.FillRectangle(blackBrush, pale_droite);
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

            // permet de faire tourner le moteur
            if (this.etat)
            {
                timer.Start();
                chrono.Reset();
                chrono.Start();
            }
            else
            {
                timer.Stop();
                chrono.Stop();
                totalTimeElapsed += chrono.Elapsed;
            }
        }

        public void resetTotalTime()
        {
            totalTimeElapsed = TimeSpan.Zero;
            if(etat) chrono.Restart();
            else chrono.Reset();
        }

        public void setScale(float scale)
        {
            this.scale = scale;
        }

        public override int GetHashCode()
        {
            return this.etat.GetHashCode() + this.step.GetHashCode() + base.GetHashCode();
        }

        public override string ToString()
        {
            if (this.etat) return "allumé";
            else return "éteint";
        }

        public string getSessionTime()
        {
            return chrono.Elapsed.ToString();
        }
        public string getTotalTime()
        {
            if (this.etat) return (totalTimeElapsed + chrono.Elapsed).ToString();
            else return totalTimeElapsed.ToString();
        }
    }
}
