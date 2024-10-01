using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using dnd.Models;

namespace dnd.Dtos
{
    public class CharacterDto
    {
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



        [Display(Name = "Class")]
        public byte PlayerClassId { get; set; }
        public PlayerClassDto PlayerClass { get; set; }



        [Display(Name = "Race")]
        public byte PlayerRaceId { get; set; }
        public PlayerRaceDto PlayerRace { get; set; }


        [Display(Name = "Alignment")]
        public byte AlignmentId { get; set; }
        public Alignment Alignment { get; set; }


        [Display(Name = "Armor")]
        public byte ArmorId { get; set; }

        public bool Shield { get; set; }

        public int Copper { get; set; }
        public int Silver { get; set; }
        public int Gold { get; set; }

        public string Notes { get; set; }
    }
}