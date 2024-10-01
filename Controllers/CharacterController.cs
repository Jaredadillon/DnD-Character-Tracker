using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dnd.Models;
using dnd.ViewModels;
using System.Data.Entity;

namespace dnd.Controllers
{
    public class CharacterController : Controller
    {
        private ApplicationDbContext _context;
        public CharacterController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var characters = _context.Characters
                .Include(c => c.PlayerClass)
                .Include(c => c.PlayerRace)
                .Include(c => c.Alignment)
                .Include(c => c.Armor)
                .ToList();

            return View(characters);
        }

        public ActionResult Details(int id)
        {
            var character = _context.Characters
                .Include(c => c.PlayerClass)
                .Include(c => c.PlayerRace)
                .Include(c => c.Alignment)
                .Include(c => c.Armor)
                .SingleOrDefault(c => c.Id == id);

            if (character == null)
                return HttpNotFound();

            return View(character);
        }

        public ViewResult New()
        {
            var playerClasses = _context.PlayerClasses.ToList();
            var playerRaces = _context.PlayerRaces.ToList();
            var Alignments = _context.Alignments.ToList();
            var Armors = _context.Armors.ToList();
            var viewModel = new CharacterFormViewModel()
            {
                Character = new Character(),
                PlayerClasses = playerClasses,
                PlayerRaces = playerRaces,
                Alignments = Alignments,
                Armors = Armors
            };
            return View("CharacterForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);

            if (character == null)
                return HttpNotFound();

            var viewModel = new CharacterFormViewModel
            {
                Character = character,
                PlayerClasses = _context.PlayerClasses.ToList(),
                PlayerRaces = _context.PlayerRaces.ToList(),
                Alignments = _context.Alignments.ToList(),
                Armors = _context.Armors.ToList()
            };
            return View("CharacterForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Character character)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CharacterFormViewModel
                {
                    Character = character,
                    PlayerClasses = _context.PlayerClasses.ToList(),
                    PlayerRaces = _context.PlayerRaces.ToList(),
                    Alignments = _context.Alignments.ToList(),
                    Armors = _context.Armors.ToList()
                };
                return View("CharacterForm", viewModel);
            }


            if (character.Id == 0)
                _context.Characters.Add(character);
            else
            {
                var characterInDb = _context.Characters.Single(c => c.Id == character.Id);

                characterInDb.CharacterName = character.CharacterName;
                characterInDb.PlayerName = character.PlayerName;
                characterInDb.Strength = character.Strength;
                characterInDb.Dexterity = character.Dexterity;
                characterInDb.Constitution = character.Constitution;
                characterInDb.Intelligence = character.Intelligence;
                characterInDb.Wisdom = character.Wisdom;
                characterInDb.Charisma = character.Charisma;

                characterInDb.Level = character.Level;
                characterInDb.Background = character.Background;

                characterInDb.PlayerClassId = character.PlayerClassId;
                characterInDb.PlayerRaceId = character.PlayerRaceId;
                characterInDb.AlignmentId = character.AlignmentId;
                characterInDb.ArmorId = character.ArmorId;
                characterInDb.Shield = character.Shield;

                characterInDb.Copper = character.Copper;
                characterInDb.Silver = character.Silver;
                characterInDb.Gold = character.Gold;

                characterInDb.Notes = character.Notes;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Character");
        }
    }
}