using System;
using System.Collections.Generic;
using System.IO;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Classe responsable de l'ecriture des logs
    /// </summary>
    internal class Logger
    {

        public string filePathAlarme { get; private set; }
        public string filePathTemperature { get; private set; }
        public string filePathNiveau { get; private set; }
        public string folderPath { get; private set; }

        public Logger(string rootFolder) 
        {
            //default path
            setPath(Path.Combine(rootFolder, "log"));

        }

        public void setPath(string path) 
        {
            folderPath = path;
            filePathAlarme = Path.Combine(folderPath, "alarme.txt");
            filePathNiveau = Path.Combine(folderPath, "niveau.txt");
            filePathTemperature = Path.Combine(folderPath, "temperature.txt");
        }

        public bool logAlarme(List<Alarme> unlogged) 
        {
            foreach (var alarme in unlogged)
            {
                File.AppendAllText(filePathAlarme, alarme.ToString() + Environment.NewLine);
                alarme.logged = true;
            }


            return true;
        }

        public void logValues(float niveau, float temperature)
        {
            File.AppendAllText(filePathNiveau, "[" + DateTime.Now.ToString() + "]  " + niveau.ToString() + Environment.NewLine);

            File.AppendAllText(filePathTemperature, "[" + DateTime.Now.ToString() + "]  " + temperature.ToString() + Environment.NewLine);
        }
        
    }
}
