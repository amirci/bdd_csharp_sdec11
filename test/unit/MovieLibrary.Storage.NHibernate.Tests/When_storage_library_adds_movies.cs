using MavenThought.Commons.Testing;
using MovieLibrary.Core;
using NHibernate;
using Rhino.Mocks;

namespace MovieLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when adding movies to the library
    /// </summary>
    [Specification]
    public class When_storage_library_adds_movies : SimpleMediaLibrarySpecification
    {
        /// <summary>
        /// Movie to add
        /// </summary>
        private IMovie _movie;

        /// <summary>
        /// Checks the movie is added to the session
        /// </summary>
        [It]
        public void Should_add_the_movie_to_the_session()
        {
            Dep<ISession>().AssertWasCalled(s => s.SaveOrUpdate(this._movie));
        }

        /// <summary>
        /// Setup the movie to be added and the session
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._movie = MockIt(this._movie);

            Stub<ISessionFactory, ISession>(factory => factory.OpenSession());

            Stub<ISession, ITransaction>(s => s.BeginTransaction());
        }

        /// <summary>
        /// Adds a movie to the library
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Add(this._movie);
        }
    }
}