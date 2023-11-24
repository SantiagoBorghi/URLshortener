using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using URLshortener.Data;
using URLshortener.Entities;
using URLshortener.Helpers;
using URLshortener.Models;

namespace UrlShorterer.Controllers
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

        [HttpGet("Get")]

        public IActionResult GetUrl(string ClientUrl)
        {
            var urlEntity = _UrlContext.Urls.FirstOrDefault(x => x.ShortUrls == ClientUrl);

            if (urlEntity == null)
            {
                return NotFound("La URL no existe");
            }
            urlEntity.UsageCount += 1;
            _UrlContext.SaveChanges();
            return Ok(urlEntity.LongUrls);
        }

        [HttpGet("GetByCategorias")]

        public IActionResult GetUrlsByCategory(Categories Category)
        {
            var urlsFounded = _UrlContext.Urls.Where(x => x.Category == Category).ToList();

            var urlList = urlsFounded.Select(url => url.LongUrls).ToList();
            return Ok(urlList);
        }


        [HttpPost("Post")]
        public IActionResult CreateNewURL(string newurl, Categories category)
        {
            var urlHelper = new UrlHelper();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var urlEntity = new Url()
            {
                LongUrls = newurl,
                ShortUrls = urlHelper.ShortenURL(),
                Category = category,
                UserId = userId
            };

            _UrlContext.Urls.Add(urlEntity);
            _UrlContext.SaveChanges();
            return Ok(urlEntity.ShortUrls);
        }
    }
}
