﻿using Newtonsoft.Json.Linq;
using System.Data;

namespace VedAstro.Library
{

    /// <summary>
    /// Data package for holding Panchanga Table as data
    /// </summary>
    public class PanchangaTable : IToJson
    {
        public string Ayanamsa { get; set; }
        public LunarDay Tithi { get; set; }
        public LunarMonth LunarMonth { get; set; }
        public DayOfWeek Vara { get; set; }
        public Constellation Nakshatra { get; set; }
        public NithyaYoga Yoga { get; set; }
        public Karana Karana { get; set; }
        public PlanetName HoraLord { get; set; }
        public string DishaShool { get; set; }
        public Time Sunrise { get; set; }
        public Time Sunset { get; set; }
        public Angle IshtaKaala { get; set; }


        public PanchangaTable(string ayanamsa, LunarDay tithi, LunarMonth lunarMonth, DayOfWeek vara, Constellation nakshatra, NithyaYoga yoga, Karana karana, PlanetName horaLord, string dishaShool, Time sunrise, Time sunset, Angle ishtaKaala)
        {
            Ayanamsa = ayanamsa;
            Tithi = tithi;
            LunarMonth = lunarMonth;
            Vara = vara;
            Nakshatra = nakshatra;
            Yoga = yoga;
            Karana = karana;
            HoraLord = horaLord;
            DishaShool = dishaShool;
            Sunrise = sunrise;
            Sunset = sunset;
            IshtaKaala = ishtaKaala;
        }

        public JObject ToJson()
        {
            var returnVal = new JObject();

            foreach (var prop in GetType().GetProperties())
            {
                //convert to JSON is possible else just ToString it
                returnVal[prop.Name] = prop.GetValue(this) is IToJson ijsonAble
                                 ? ijsonAble.ToJson()
                                    : prop.GetValue(this)?.ToString();
            }

            return returnVal;
        }
    }
}