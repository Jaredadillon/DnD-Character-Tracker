using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dnd.Models
{
    public class Armor
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int AC { get; set; }
        public int? Strength { get; set; }
        public bool DisStealth { get; set; }
        [Required]
        public int Weight { get; set; }


        //Function to get AC
        public int GetAC(int ac, int armType, int dexMod, bool shield)
        {
            if (shield) { ac += 2; }

            if (armType == 0)
            {
                return ac + dexMod;
            }
            else if (armType == 1)
            {
                if(dexMod > 2) { dexMod = 2; }

                return ac + dexMod;
            }
            else
            {
                return ac;
            }
        }

        //Function to get armor type
        public string GetArmorType(int type)
        {
            if(type == 0)
            {
                return "Light";
            }
            else if(type == 1)
            {
                return "Medium";
            }
            else
            {
                return "Heavy";
            }
        }
    }
}