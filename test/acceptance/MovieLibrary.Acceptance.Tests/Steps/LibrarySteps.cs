using System;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;
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
        public static IEnumerable<string> Titles
        {
            get { return new[] { "Blazing Saddles", "Young Frankenstein", "Spaceballs" }; }  
        } 

        [Given(@"I have contents in the library")]
        public void AddSomeMovies()
        {
            Titles.ForEach(AddMovieToStorage);
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
