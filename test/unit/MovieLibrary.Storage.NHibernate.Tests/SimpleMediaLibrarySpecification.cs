using MavenThought.Commons.Testing;
using MovieLibrary.Core;
using NHibernate;

namespace MovieLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// StorageMediaLibrary specification
    /// </summary>
    public abstract class SimpleMediaLibrarySpecification
        : AutoMockSpecification<SimpleMovieLibrary, IMovieLibrary>
    {
        /// <summary>
        /// Creates the media library using the session factory dependency
        /// </summary>
        /// <returns>An instance to storage media library</returns>
        protected override IMovieLibrary CreateSut()
        {
            return new SimpleMovieLibrary(Dep<ISessionFactory>());
        }
    }
}