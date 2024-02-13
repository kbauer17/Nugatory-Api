using Microsoft.AspNetCore.Mvc;
using Nugatory.Models;

namespace WordApi.Controllers
{
    // define customer router:  will use the Controller Name/Model
    [ApiController, Route("[controller]/word")]
    public class ApiController : ControllerBase
    {
        //create an instance of the DataContext
        private DataContext _dataContext;
        public ApiController(DataContext db)
        {
            _dataContext = db;
        }
        
        // http get entire collection
        [HttpGet]
        public IEnumerable<WordColor> Get()
        {
            return _dataContext.WordColors;
        }
    }
}