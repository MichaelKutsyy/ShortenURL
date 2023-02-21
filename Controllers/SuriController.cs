using Microsoft.AspNetCore.Mvc;
using proUrl.Ds;

namespace proUrl.Controllers
{
    [Route("/short")]
    public class SuriController : Controller
    {
       
        private readonly DbData _dataContext;
        private readonly ILogger<SuriController> _logger;

        public SuriController(ILogger<SuriController> logger, DbData dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        [HttpGet]
        [Route("/short/{shortUri}")]
        public ActionResult Index(string shortUri)
        {
            //string key = $"{Request.Scheme}://{Request.Host}/{shortUri}";
            var url = _dataContext.UrlFromtheDataBase(shortUri);
            if (!string.IsNullOrEmpty(url))
                return RedirectPermanent(url);
            return NotFound();
        }
    }
}
