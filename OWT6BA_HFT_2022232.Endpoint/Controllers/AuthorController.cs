using Microsoft.AspNetCore.Mvc;
using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OWT6BA_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // members
        IAuthorLogic authorLogic;

        // ctor
        public AuthorController(IAuthorLogic authorLogic)
        {
            this.authorLogic = authorLogic;
        }


        // CRUD api methods
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return this.authorLogic.ReadAll();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.authorLogic.Read(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Create([FromBody] Author value) // az Author value json formátumban jön, az ApiController példányosítja a HttpPost kérés törzséből
        {
            this.authorLogic.Create(value);
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        public void Update([FromBody] Author value)
        {
            this.authorLogic.Update(value);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.authorLogic.Delete(id);
        }
        


        // NON-CRUD API methods
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<AuthorStatistics> GetStatistics()
        {
            return this.authorLogic.GetStatistics();
        }

        // GET: api/<AuthorController>/5
        [HttpGet]
        public IEnumerable<string> CategoriesOfAuthor(int id)
        {
            return this.authorLogic.CategoriesOfAuthor(id);
        }
    }
}
