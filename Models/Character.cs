using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dnd.Models
{
    public class Character
    {
        //Name & stats
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for your character")]
        [StringLength(50)]
        public string CharacterName { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50)]
        public string PlayerName { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        [Required(ErrorMessage = "Please select your level")]
        public byte Level { get; set; }
        public string Background { get; set; }

        //Foreign keys for class, race, etc.
        [ForeignKey("PlayerClassId")]
        public PlayerClass PlayerClass { get; set; }
        [Display(Name = "Class")]
        public byte PlayerClassId { get; set; }


        [ForeignKey("PlayerRaceId")]
        public PlayerRace PlayerRace { get; set; }
        [Display(Name = "Race")]
        public byte PlayerRaceId { get; set; }


        [ForeignKey("AlignmentId")]
        public Alignment Alignment { get; set; }
        [Display(Name = "Alignment")]
        public byte AlignmentId { get; set; }


        [ForeignKey("ArmorId")]
        public Armor Armor { get; set; }
        [Display(Name = "Armor")]
        public byte ArmorId { get; set; }

        //Misc values
        public bool Shield { get; set; }
        public int Copper { get; set; }
        public int Silver { get; set; }
        public int Gold { get; set; }
        public string Notes { get; set; }


        //Function to get modifier value from ability score
        public int GetModifier(int score)
        {
            return Convert.ToInt32(Math.Floor((score - 10) / 2.0));
        }

        //Function to get proficiency bonus from level
        public int GetProficiency(int level)
        {
            if (1 <= level && level <= 4)
                return 2;
            else if (5 <= level && level <= 8)
                return 3;
            else if (9 <= level && level <= 12)
                return 4;
            else if (13 <= level && level <= 16)
                return 5;
            else
                return 6;
        }
    }
}