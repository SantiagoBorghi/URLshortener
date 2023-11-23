using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using URLshortener.Data;
using URLshortener.Entities;
using URLshortener.Models;
using UrlHelper = URLshortener.Helpers.UrlHelper;

namespace URLshortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UrlController : ControllerBase
    {
        private readonly UrlShortenerContext _UrlContext;

        public UrlController(UrlShortenerContext UrlContext)
        {
            _UrlContext = UrlContext;
        }

        [HttpGet("GetUrl")]
        public IActionResult GetUrl(string ClientUrl)
        {
            var urlFromClient = _UrlContext.Urls.FirstOrDefault(x => x.ShortUrls == ClientUrl);

            if (urlFromClient == null)
            {
                return NotFound("URL not found");
            }
            urlFromClient.UsageCount += 1;
            _UrlContext.SaveChanges();
            return Ok(urlFromClient.LongUrl);
        }

        [HttpGet("GetByCategorias")]
        public IActionResult GetUrlsByCategory(Categories Category)
        {
            var urlsFounded = _UrlContext.Urls.Where(x => x.Category == Category).ToList();

            var urlList = urlsFounded.Select(url => url.LongUrl).ToList();
            return Ok(urlList);
        }

        [HttpPost("Post")]
        public IActionResult CreateNewURL(string urlShort, Categories category)
        {
            var urlHelper = new UrlHelper();
            var urlEntity = new Url()
            {
                LongUrl = urlShort,
                ShortUrls = urlHelper.ShortenURL(),
                Category = category
            };

            _UrlContext.Urls.Add(urlEntity);
            _UrlContext.SaveChanges();
            return Ok(urlEntity.ShortUrls);
        }
    }
}
