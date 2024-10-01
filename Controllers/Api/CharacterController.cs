using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dnd.Models;
using dnd.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace dnd.Controllers.Api
{
    public class CharacterController : ApiController
    {
        private ApplicationDbContext _context;
        public CharacterController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/character
        public IHttpActionResult GetCharacters()
        {
            var characterDtos = _context.Characters
                .Include(c => c.PlayerClass)
                .Include(c => c.PlayerRace)
                .ToList().Select(Mapper.Map<Character, CharacterDto>);

            return Ok(characterDtos);
        }

        //GET api/character/1
        public CharacterDto GetCharacter(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            if (character == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Character, CharacterDto>(character);
        }

        //POST /api/character
        [HttpPost]
        public IHttpActionResult CreateCharacter(CharacterDto characterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var character = Mapper.Map<CharacterDto, Character>(characterDto);
            _context.Characters.Add(character);
            _context.SaveChanges();

            characterDto.Id = character.Id;
            return Created(new Uri(Request.RequestUri + "/" + character.Id), characterDto);
        }

        //PUT /api/character/1
        [HttpPut]
        public void UpdateCharacter(int id, CharacterDto characterDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var characterInDb = _context.Characters.SingleOrDefault(c => c.Id == id);
            if (characterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CharacterDto, Character>(characterDto, characterInDb);
            _context.SaveChanges();
        }

        //DELETE /api/character/1
        [HttpDelete]
        public void DeleteCharacter(int id)
        {
            var characterInDb = _context.Characters.SingleOrDefault(c => c.Id == id);
            if (characterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Characters.Remove(characterInDb);
            _context.SaveChanges();
        }
    }
}
