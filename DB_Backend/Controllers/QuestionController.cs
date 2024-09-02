using DB_Backend.DB_BackendBLL;
using DB_Backend.DB_BackendModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DB_Backend.Controllers
{
    public class QuestionRequest
    {
        public string QuestionSearch { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        [HttpGet]
        public IActionResult GetQuestion()
        {
            List<QuestionModel> model = QuestionManager.ReturnList();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult PostQuestion([FromBody] QuestionRequest request)
        {
            if (!string.IsNullOrEmpty(request.QuestionSearch))
            {
                var result = QuestionManager.SearchRelatedQuestions(request.QuestionSearch);
                var response = new
                {
                    Questions = result.Item1,
                    Answers = result.Item2
                };
                return Ok(response);
            }

            return BadRequest("QuestionSearch parameter is missing or empty");
        }
    }
}
