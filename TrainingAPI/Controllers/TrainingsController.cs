using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TrainingAPI.Models;

namespace TrainingAPI.Controllers
{
    ///<summary>
    /// This class designed for API action methods.
    /// All CRUD operations can be added through GET/POST/PUT/DELETE methods.
    /// Need to add PUT and DELETE when required
    /// </summary>
   
    public class TrainingsController : ApiController
    {
        private ITrainingAPIContext db = new TrainingData();

        public TrainingsController(){ }

        public TrainingsController(ITrainingAPIContext _training)
        {
            db=_training;
        }

        //Method to get all trainings from DB for listing
        // GET: api/Trainings
        public IQueryable<Training> GetTrainings()
        {
            return db.Trainings;
        }

       // Method for adding training record to DB
        // POST: api/Trainings
        [ResponseType(typeof(Training))]
        public IHttpActionResult PostTraining(Training training)
        {
            try
            {
                if (training == null)
                    return BadRequest();

                List<string> result;
                string dateDiff;

                db.Trainings.Add(training);
                db.SaveChanges();

                if (training.Id > 0)
                {
                    dateDiff = (training.EndDate - training.StartDate).TotalDays.ToString();
                    result = new List<string> { "result:Success", dateDiff };
                }
                else
                    return BadRequest();

                return Ok<List<string>>(result);
            }
            catch
            {
                return BadRequest();
            }
            
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}