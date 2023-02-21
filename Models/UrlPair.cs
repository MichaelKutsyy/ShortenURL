using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace proUrl.Models
{
    public class UrlPair
    {
        [Key]
        public string Key { get; set; }
        [RegularExpression(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "ty again")]
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime Created { get; set; }
        public IdentityUser UrlUser { get; set; }
        public int ClickCount { get; set; }
        public int Count { get; set; }  

    }
}
