using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BacboneExample.Models;

namespace BacboneExample.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UsersContext _db = new UsersContext();

        public UsersController()
        {
            if (!_db.Users.Any())
            {
                for (int i = 1; i < 3; i++)
                {
                    _db.Users.Add(new User
                    {
                        Id = i,
                        Fname = Faker.NameFaker.FirstName(),
                        LName = Faker.NameFaker.LastName(),
                        Age = i + 20
                    });
                }
                _db.SaveChanges();
            }
        }
        // GET api/Default1
        public IEnumerable<User> GetUsers()
        {
            return _db.Users.AsEnumerable();
        }

        // GET api/Default1/5
        public User GetUser(int id)
        {
            User user = _db.Users.Find(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != user.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _db.Entry(user).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
            return response;
        }

        // POST api/Default1
        public HttpResponseMessage PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteUser(int id)
        {
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _db.Users.Remove(user);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}