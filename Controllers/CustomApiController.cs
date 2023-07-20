using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EngineerTestApiApps.Models;
namespace EngineerTestApiApps.Controllers
{
    public class CustomApiController : ApiController
    {
        db_a9c4b3_regdataEntities db = new db_a9c4b3_regdataEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetApi()
        {
            List<User> users = db.Users.ToList();
            return Ok(users);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetApi(int ID)
        {
            var users = db.Users.Where(x => x.id == ID).FirstOrDefault();
            return Ok(users);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertData(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateData(User u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
            //var user = db.Users.Where(x => x.id == u.id).FirstOrDefault();
            //if(user!=null)
            //{
            //    user.id = u.id;
            //    user.Name = u.Name;
            //    user.FatherName= u.FatherName;
            //    user.Mobile = u.Mobile;
            //    user.Email = u.Email;
            //    user.ImageFileName = u.ImageFileName;
            //    db.SaveChanges();
            //    return Ok();

            //}
            //else
            //{
            //    return NotFound();
            //}
        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteData(int ID)
        {
            var user = db.Users.Where(x => x.id == ID).FirstOrDefault();
            db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
