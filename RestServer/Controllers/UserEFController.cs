using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Avanza.DataAccess;
using Prepaid.Core.BLL;
using Avanza.Util;
using NLog;

namespace RestServer.Controllers
{
    public class UserEFController : ApiController, IVisionLogger
    {
        private VisionDBModel db = new VisionDBModel();

        public LogEventInfo GetLogEvent(LogLevel level, string loggerName, string message,
                string Entity,
                string Action,
                string PrimaryKeyVals,
                string ChangedColVals,
                string CreatedBy,
                DateTime CreatedOn,
                string UpdateBy,
                DateTime UpdatedOn,
                string MachineName,
                string LogTypeID,
                int Result,
                string EventOrigin,
                string Description)
        {
            var logEvent = new LogEventInfo(level, loggerName, message);

            logEvent.Properties["ENTITY"] = Entity;
            logEvent.Properties["ACTION"] = Action;
            logEvent.Properties["PRIMARY_KEY_VALS"] = PrimaryKeyVals;
            logEvent.Properties["CHANGED_COLS_VAL"] = ChangedColVals;
            logEvent.Properties["CREATED_ON"] = CreatedOn;
            logEvent.Properties["CREATED_BY"] = CreatedBy;
            logEvent.Properties["UPDATED_ON"] = UpdatedOn;
            logEvent.Properties["UPDATED_BY"] = UpdateBy;
            logEvent.Properties["WINDOWS_CREATED_BY"] = "";
            logEvent.Properties["WINDOWS_UPDATED_BY"] = "";
            logEvent.Properties["MACHINE_NAME"] = MachineName;
            logEvent.Properties["LOG_TYPE_ID"] = LogTypeID;
            logEvent.Properties["RESULT"] = Result;
            logEvent.Properties["EVENT_ORIGIN"] = EventOrigin;
            logEvent.Properties["DESCRIPTION"] = Description;

            return logEvent;
        }

        // GET api/UserEF
        public IQueryable<SEC_USER> GetSEC_USER()
        {
            //SEC_USER obj = db.SEC_USER.First();
            //if(obj != null)
            //    obj.logMessage(NLog.LogLevel.Info, this.GetType().ToString(), "hello people", obj.LOGIN_ID, "action_undefined", "primary", "ChangedColVals", Environment.UserName, DateTime.Now, Environment.UserName, DateTime.Now, Environment.MachineName, "logtype_undefined", 1, this.GetType().ToString(), obj.LOGIN_ID + " accessed in " + this.GetType().ToString());
            //foreach(SEC_USER obj in db.SEC_USER)
            //{
            //    obj.logMessage(NLog.LogLevel.Info, this.GetType().ToString(), "hello people", obj.LOGIN_ID, "action_undefined","primary", "ChangedColVals", Environment.UserName, DateTime.Now, Environment.UserName, DateTime.Now, Environment.MachineName, "logtype_undefined", 1, this.GetType().ToString(), obj.LOGIN_ID + " accessed in " + this.GetType().ToString());
            //}

            this.logMessage(LogLevel.Info, this.GetType().ToString(),
                "GetSEC_USER called", this.GetType().Name, "action_undefined", "no prim keys", "no cols",
                Environment.UserName, DateTime.Now, Environment.UserName, DateTime.Now, Environment.MachineName,
                "logtype_undefined", 1, this.GetType().ToString(), this.GetType().ToString());

            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = true;
            return db.SEC_USER;
        }

        // GET api/UserEF/5
        [ResponseType(typeof(SEC_USER))]
        public IHttpActionResult GetSEC_USER(string id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = true;
            SEC_USER sec_user = db.SEC_USER.Find(id);
            if (sec_user == null)
            {
                return NotFound();
            }

            return Ok(sec_user);
        }

        // PUT api/UserEF/5
        public IHttpActionResult PutSEC_USER(string id, SEC_USER sec_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sec_user.LOGIN_ID)
            {
                return BadRequest();
            }

            db.Entry(sec_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SEC_USERExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/UserEF
        [ResponseType(typeof(SEC_USER))]
        public IHttpActionResult PostSEC_USER(SEC_USER sec_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SEC_USER.Add(sec_user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SEC_USERExists(sec_user.LOGIN_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sec_user.LOGIN_ID }, sec_user);
        }

        // DELETE api/UserEF/5
        [ResponseType(typeof(SEC_USER))]
        public IHttpActionResult DeleteSEC_USER(string id)
        {
            SEC_USER sec_user = db.SEC_USER.Find(id);
            if (sec_user == null)
            {
                return NotFound();
            }

            db.SEC_USER.Remove(sec_user);
            db.SaveChanges();

            return Ok(sec_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SEC_USERExists(string id)
        {
            return db.SEC_USER.Count(e => e.LOGIN_ID == id) > 0;
        }
    }
}