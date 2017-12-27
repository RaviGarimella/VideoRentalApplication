using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalApplication.Models;
using AutoMapper;
using VideoRentalApplication.Dto;

namespace VideoRentalApplication.Controllers.Api
{
    public class MoviesController : ApiController
    {
        VideoRentalApplicationDBContext db;

        private MoviesController()
        {
            db = new VideoRentalApplicationDBContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

       // Get api/movies
        public IEnumerable<MoviesDto> getMovies()
        {
            return db.Movies.ToList().Select(Mapper.Map<Movie, MoviesDto>);
        }

        // Get api/movies/1
        public MoviesDto getMovieById(int id)
        {
            var movie = db.Movies.SingleOrDefault(x => x.movieID == id);
            if(movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            return Mapper.Map<Movie, MoviesDto>(movie);
        }

        // Post api/movies
        [HttpPost]
        public MoviesDto createMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            moviesDto.movieID = movie.movieID;

            db.Movies.Add(movie);
            db.SaveChanges();

            return moviesDto;
        }

        // Put api/movies/1
        [HttpPut]
        public void updateMovie(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = db.Movies.SingleOrDefault(x => x.movieID == id);
            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MoviesDto, Movie>(moviesDto, movieInDB);
            db.Movies.Add(movieInDB);
            db.SaveChanges();
        }

        // delete api/movies/1
        public void deleteMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(x => x.movieID == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Movies.Remove(movie);
            db.SaveChanges();
        }

    }
}
