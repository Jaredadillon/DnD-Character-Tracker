using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dnd.Models;

namespace dnd.ViewModels
{
    public class CharacterFormViewModel
    {
        public IEnumerable<PlayerClass> PlayerClasses { get; set; }
        public IEnumerable<PlayerRace> PlayerRaces { get; set; }
        public IEnumerable<Alignment> Alignments { get; set; }
        public IEnumerable<Armor> Armors { get; set; }
        public Character Character { get; set; }
    }
}