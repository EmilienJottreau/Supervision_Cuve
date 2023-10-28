using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Emilien_Jottreau
{
    static class AlarmMessage
    {
        public static string getSUP(AlarmeType type)
        {
            if (type == AlarmeType.NIVEAU) return "Niveau trop haut (>3.9m)";
            else return "Température trop haute (>18.5°C)";
        }

        public static string getINF(AlarmeType type)
        {
            if (type == AlarmeType.NIVEAU) return "Niveau trop faible (<2m)";
            else return "Température trop faible (<15.5°C)";
        }

    }

    public enum AlarmeType
    {
        NIVEAU,
        TEMP,
    }

    class Alarme
    {

        public readonly DateTime time;
        public readonly string message;
        public readonly AlarmeType type;

        public bool state { get; private set; } //0 : inactive  1 : active

        public bool logged { get; set; }

        public Alarme(AlarmeType type, string message, DateTime time) 
        {
            this.message = message;
            this.time = time;
            this.type = type;
            this.logged = false;

            this.state = true;
        }

        public void resolve()
        {
            this.state = false;
        }

        public string getTime()
        {
            return this.time.ToString("dd/MM/yy HH:mm:ss");
        }

        public override string ToString()
        {
            return '{' + getTime() + "} " + this.message;
        }
    }

    class AlarmeController : IEnumerable<Alarme>
    {
        public List<Alarme> list;

        public AlarmeController() 
        {
            list = new List<Alarme>();
        }

        public void add(AlarmeType type, string alarmMessage)
        {
            list.Add(new Alarme(type, alarmMessage, DateTime.Now));
        }

        public Alarme getLastAlarmeByType(AlarmeType type)
        {
            if(list.Count == 0) return null;
            for (int i = list.Count-1; i >= 0; i--)
            {
                if (list[i].type == type)
                {
                    return list[i];
                }
            }
            return null;
        }

        // pour foreach sur AlarmeControler
        public IEnumerator<Alarme> GetEnumerator()
        {
            for (int i = 0; i < list.Count; ++i)
                yield return list[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<Alarme> getUnLogged()
        {
            List<Alarme> unlogged = new List<Alarme>();
            if (list.Count == 0) return unlogged;
            for (int i = list.Count -1; i >= 0; i--)
            {
                if (list[i].logged == false)
                {
                    unlogged.Add(list[i]);
                }
                else
                {
                    return unlogged;
                }
            }
            return unlogged;

        }

        public bool evaluateValue(AlarmeType type, float value)
        {
            // Retourne faux si aucun changement n'a été engendré

            Alarme lastAlarme = getLastAlarmeByType(type);

            float borneSUP = 0f;
            float borneINF = 0f;

            if(type == AlarmeType.NIVEAU)
            {
                borneINF = 2.0f;
                borneSUP = 3.9f;
            } 
            else if(type == AlarmeType.TEMP)
            {
                borneINF = 15.5f;
                borneSUP = 18.5f;
            }

            if (lastAlarme != null)
            {
                // Une alarme existe deja, on verifie si elle est active
                if (lastAlarme.state) //0 : inactive,  1 : active
                {
                    if (value < borneSUP && value > borneINF)
                    {
                        //valeur normale
                        lastAlarme.resolve();
                        return true;
                    }
                    //alarme toujours en cours
                    return false;
                }

            }

            // aucune alarme de ce type n'existe ou si l'alarme existante est inactive
            if (value > borneSUP)
            {
                add(type, AlarmMessage.getSUP(type));
                return true;
            }
            if (value < borneINF)
            {
                add(type, AlarmMessage.getINF(type));
                return true;
            }

            return false;
        }

    }
}
