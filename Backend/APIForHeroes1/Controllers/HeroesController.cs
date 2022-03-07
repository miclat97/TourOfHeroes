using APIForHeroes1.Data;
using APIForHeroes1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIForHeroes1.Controllers
{
    [Route("api/Heroes")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        [HttpGet("getAll")]
        public ActionResult<List<Hero>> GetAll()
        {
            if (MainListOfHeroes.Heroes.Any())
            {
                return Ok(MainListOfHeroes.Heroes);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("getById/{id}")]
        public ActionResult<Hero?> GetById(int id)
        {
            return MainListOfHeroes.Heroes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPut("update/{id}/{name}/{power}")]
        public ActionResult Update(int id, string name, int? power)
        {
            Hero? heroToUpdate = MainListOfHeroes.Heroes.SingleOrDefault(x => x.Id == id);

            if (heroToUpdate == null)
            {
                return NotFound();
            }

            heroToUpdate.Name = name;
            heroToUpdate.Power = power;

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Hero? heroToDelete = MainListOfHeroes.Heroes.SingleOrDefault(x => x.Id == id);

            MainListOfHeroes.Heroes.Remove(heroToDelete);

            return Ok();
        }

        [HttpPost("create")]
        public ActionResult Create(Hero hero)
        {
            MainListOfHeroes.Heroes.Add(hero);
            return Ok();
        }
    }
}
