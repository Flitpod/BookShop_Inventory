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
    public class BookController : ControllerBase
    {
        // members
        IBookLogic bookLogic;

        // ctor
        public BookController(IBookLogic bookLogic)
        {
            this.bookLogic = bookLogic;
        }


        // CRUD api methods
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return this.bookLogic.ReadAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.bookLogic.Read(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.bookLogic.Create(value);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public void Update([FromBody] Book value)
        {
            this.bookLogic.Update(value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.bookLogic.Delete(id);
        }


        // NON-CRUD API methods
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> BooksFromYear(int year)
        {
            return this.bookLogic.BooksFromYear(year);
        }

        // GET: api/<BookController>/5
        [HttpGet]
        public IEnumerable<BookYearStatistics> GetStatisticsByYears()
        {
            return this.bookLogic.GetStatisticsByYears();
        }
    }
}
