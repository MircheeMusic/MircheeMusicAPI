using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MircheeMusicAPI.Repository;
using MircheeMusicAPI.Contracts;
using System.Web.Mvc.Ajax;
using MircheeMusicAPI.Filters;

namespace MircheeMusicAPI.Controllers
{
    //[MircheeMusicAuthorize]
    public class AlbumsController : ApiController
    {
        // GET api/<controller>
        public List<Album> Get()
        
        {            
            var AlbumRepo = new AlbumRepository();
            List<Album> Albums = AlbumRepo.FindAll();

            if (Albums == null)
            {
                var ErrMessage = string.Format("There is issue with accessing resources");
                var ErrResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, ErrMessage);
                throw new HttpResponseException(ErrResponse);
            }
            else
            {
                return Albums;
            }
        }

        //Get album info by ID
        public Album Get(int ID)
        {
            var albumRepository = new AlbumRepository();
            Album album = albumRepository.Find(ID);

            if (album == null)
            {
                var ErrMessage = string.Format("There is issue with accessing resources");
                var ErrResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, ErrMessage);
                throw new HttpResponseException(ErrResponse);
            }
            else
            {
                return album;
            }
        }

        // POST api/<controller>
        public void Post([FromBody]Album album)
        {
            var AlbumRepo = new AlbumRepository();
            if (album == null) // write more elaborated validation later or can create special validation procedure and call that 
            {
                var err = string.Format("No valid input avaialable to Insert");
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
                throw new HttpResponseException(errResponse);               
            }
            else
            {
                AlbumRepo.Save(album);
            }
            
        }

        // PUT api/<controller>/5
        public void Put( [FromBody]Album album)
        {
            var AlbumRepo = new AlbumRepository();
            AlbumRepo.Save(album);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var AlbumRepo = new AlbumRepository();
            AlbumRepo.Delete(id);
        }
    }
}