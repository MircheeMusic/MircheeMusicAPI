using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MircheeMusicAPI.Contracts;
using MircheeMusicAPI.Repository;
using System.Web.Mvc.Ajax;

namespace MircheeMusicAPI.Controllers
{
    [RoutePrefix("api/albums")]
    public class TracksController : ApiController
    {
        private AlbumContext db = new AlbumContext();

        // GET api/<controller>

        [Route("tracks")]
        public IList<Track> Get()
        {

            var trackRepository = new TrackRepository();
            List<Track> tracks = trackRepository.FindAll();

            if (tracks == null)
            {
                var errMessage = string.Format("There is issue with accessing resources");
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, errMessage);
                throw new HttpResponseException(errResponse);
            }
            else
            {
                return tracks;
            }
        }

        [Route("tracks/{trackId}")]
        public  Track  GetTrack(int trackID)
        {
            var trackRepository = new TrackRepository();
            Track track = trackRepository.FindByID(trackID);

            if (track == null)
            {

                var ErrMessage = string.Format("Resourse with id = {0} not found", trackID);
                var ErrResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, ErrMessage);
                throw new HttpResponseException(ErrResponse);
            }
            else
            {
                return track;
            }
        }

        [Route("{albumId}/tracks")]
        public IList<Track> GetAllTracksForAlbum(int albumID)
        {
            var trackRepository = new TrackRepository();
            List<Track> tracks = trackRepository.FindByAlbumID(albumID);

            if (tracks == null)
            {

                var ErrMessage = string.Format("Resourse with id = {0} not found", albumID);
                var ErrResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, ErrMessage);
                throw new HttpResponseException(ErrResponse);
            }
            else
            {
                return tracks;
            }
        }
        
        [Route("{albumId}/tracks")]
        //add new track to the album
        public void Post(int albumId, [FromBody]Track newTrack)
        {
            var trackRepository = new TrackRepository();
            if (newTrack == null)
            {
                var errMsg = "No valid input avaialable!";
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, errMsg);
                throw new HttpResponseException(errResponse);
            }
            newTrack.AlbumID = albumId;
            trackRepository.Save(newTrack);
        }

        [Route("{albumID}/tracks/{trackId}")]
        public void Put(int trackId, [FromBody] Track newTrack)
        {
            var TrackRepo = new TrackRepository();

            if (newTrack == null)            {
                var errMsg = "No valid input avaialable!";
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, errMsg);
                throw new HttpResponseException(errResponse);
            }
            TrackRepo.Save(newTrack);
        }
    }
}