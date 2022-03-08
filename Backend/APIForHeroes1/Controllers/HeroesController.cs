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
            return Ok(MainListOfHeroes.Heroes.FirstOrDefault(x => x.Id == id));
        }

        [HttpGet("search/{searchName}")]
        public ActionResult<List<Hero>> Search(string searchName)
        {
            List<Hero> resultList = MainListOfHeroes.Heroes.Where(x => x.Name.Contains(searchName)).ToList();
            if (resultList.Any())
            {
                return Ok(resultList);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("update/{id}/{name}/{power}")]
        public ActionResult Update(int id, string name, int? power)
        {
            Hero? heroToUpdate = MainListOfHeroes.Heroes.FirstOrDefault(x => x.Id == id);

            if (heroToUpdate == null)
            {
                return NotFound();
            }

            heroToUpdate.Name = name;
            heroToUpdate.Power = power;

            return Ok(heroToUpdate);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Hero? heroToDelete = MainListOfHeroes.Heroes.FirstOrDefault(x => x.Id == id);

            MainListOfHeroes.Heroes.Remove(heroToDelete);

            return Ok();
        }

        [HttpPost("create")]
        public ActionResult Create(Hero hero)
        {
            int nextId;

            if (!MainListOfHeroes.Heroes.Any())
            {
                nextId = 1;
            }
            else
            {
                nextId = MainListOfHeroes.Heroes.Last().Id + 1;
            }

            hero.Id = nextId;
            MainListOfHeroes.Heroes.Add(hero);
            return Created($"api/Heroes/getById/{hero.Id}", hero);
        }
    }
}
