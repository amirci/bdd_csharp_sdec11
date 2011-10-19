using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using MovieLibrary.Core;
using TechTalk.SpecFlow;

namespace MovieLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps that involve accessing the library
    /// </summary>
    [Binding]
    public class LibrarySteps : BaseSteps
    {
        /// <summary>
        /// Setup no movies exist
        /// </summary>
        [Given(@"I have no movies")]
        public void ClearMovies()
        {
            this.Library.Clear();
        }

        /// <summary>
        /// Setup the movies in the library
        /// </summary>
        [Given(@"I have the following movies:")]
        public void SetupMovies(Table movies)
        {
            movies.Rows.ForEach(row => AddMovieToStorage(row["title"]));
        }

        /// <summary>
        /// Adds a movie to the media library
        /// </summary>
        /// <param name="title">Title of the movie to add</param>
        private void AddMovieToStorage(string title)
        {
            var movie = new Movie
                            {
                                Title = title,
                                ReleaseDate = DateTime.Now
                            };

            this.Library.Add(movie);
        }
    }
}
