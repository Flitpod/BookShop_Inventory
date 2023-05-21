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
    public class CategoryController : ControllerBase
    {
        // members
        ICategoryLogic categoryLogic;

        // ctor
        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }


        // CRUD API methods
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> ReadAll()
        {
            return this.categoryLogic.ReadAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Read(int id)
        {
            return this.categoryLogic.Read(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Create([FromBody] Category value)
        {
            this.categoryLogic.Create(value);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Update([FromBody] Category value)
        {
            this.categoryLogic.Update(value);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.categoryLogic.Delete(id);
        }


        // NON-CRUD API methods
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryStatistics> GetStatisticsFromStartYear(int startYear)
        {
            return this.categoryLogic.GetStatisticsFromStartYear(startYear);
        }

    }
}
