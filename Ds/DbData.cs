using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using proUrl.Models;
using System;
using System.Linq;

namespace proUrl.Ds
{
    public class DbData: IdentityDbContext
    {
        Random _rnd;

        public DbData(DbContextOptions<DbData> options) : base(options)
        {
             _rnd = new Random();
        }
        public DbSet<UrlPair> UrlPairs { get; set; }
        

        public UrlPair Short(string fullurl,IdentityUser idUser)
        {
            var url = UrlPairs.FirstOrDefault(url => url.FullUrl == fullurl);
            if (url == null)
            {
                Guid guid = Guid.NewGuid();
                var shortStr = _rnd.Next().ToString("x");
                string shortUrl = $"https://localhost:7013/short/{shortStr}";
                //string shortUrl1 = $"window.location = http://localhost/suri/{shortStr}";

               url=new UrlPair()
                {
                    Key = shortStr,
                    FullUrl = fullurl,
                    ShortUrl = shortUrl,
                    Created = DateTime.Now,
                    ClickCount = 0,
                    Count=1,
                    UrlUser= idUser
               };
                UrlPairs.Add(url);
                SaveChanges();
                return url;
            }
            else
            {
                url.Count += 1;
                SaveChanges();
                return url;
            }
            //if ((UrlPairs.FirstOrDefault(u => u.ShortUrl == res).ShortUrl == res))
            //{
                
              
            //} ;


        }

        public int CountFromDataBase( string key)
        {
            var url = UrlPairs.SingleOrDefault(k => k.ShortUrl == key);

            return url.Count;
        }

        //public string PressLink(string key)
        //{
        //    var url = UrlPairs.SingleOrDefault(k => k.ShortUrl == key);

        //    return url.ShortUrl;
        //}

        public string UrlFromtheDataBase(string shortUrl)
        {
            var urlPair= UrlPairs.SingleOrDefault(k => k.Key == shortUrl);
            if(urlPair != null)
            {
                urlPair.ClickCount += 1;
                SaveChanges();
                return urlPair.FullUrl;
            }
            else
            {
                return "" ;
            }
        }

        public List<UrlPair> GetAll()
        {
          return UrlPairs.ToList(); 
        }

    }



}
