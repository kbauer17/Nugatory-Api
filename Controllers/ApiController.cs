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

        // http get specific member of collection
        [HttpGet("{id}")]
        public WordColor Get(int id)
        {
            return _dataContext.WordColors.Find(id);
        }

                // http post member to collection
        [HttpPost]
        public async Task<ActionResult<WordColor>> Post([FromBody] WordColor wordColor) {
            _dataContext.Add(wordColor);
            await _dataContext.SaveChangesAsync();
            return wordColor;
        }

                // http delete member from collection
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            WordColor wordColor = await _dataContext.WordColors.FindAsync(id);
            if (wordColor == null){
                return NotFound();
            }
            _dataContext.Remove(wordColor);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}