namespace TP_Emilien_Jottreau
{
    internal interface IDrawable
    {
        void drawGraphic();

        object getValue();

        void place(int x, int y);

        void setScale(float scale);
    }
}
