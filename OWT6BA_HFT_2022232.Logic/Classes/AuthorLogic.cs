using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Classes
{
    public class AuthorLogic : IAuthorLogic
    {
        // members
        IRepository<Author> repository;

        // ctor - dependency injection
        public AuthorLogic(IRepository<Author> repository)
        {
            this.repository = repository;
        }


        // CRUD methods
        public void Create(Author item)
        {
            if (item.AuthorName == "") 
            {
                throw new Exception("[EXCEPTION] AuthorName can not be an empty string!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            if(this.repository.ReadAll().Where(a => a.AuthorId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Author in the database identified by given id ({id})!");
            }
            this.repository.Delete(id);
        }


        public Author Read(int id)
        {
            if (this.repository.ReadAll().Where(a => a.AuthorId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Author in the database identified by given id ({id})!");
            }
            return this.repository.Read(id);
        }

        public IEnumerable<Author> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Author item)
        {
            this.repository.Update(item);
        }


        // NON-CRUD methods
        public IEnumerable<AuthorStatistics> GetStatistics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> CategoriesOfAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
