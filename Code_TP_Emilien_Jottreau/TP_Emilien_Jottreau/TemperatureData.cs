using System;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Classe representant une température a un instant T
    /// </summary>
    internal class TemperatureData
    {
        public float temperature { get; set; }
        public DateTime date { get; set; }
        public TemperatureData(float temp, DateTime date) 
        {
            this.temperature = temp;
            this.date = date;
        }
    }
}
