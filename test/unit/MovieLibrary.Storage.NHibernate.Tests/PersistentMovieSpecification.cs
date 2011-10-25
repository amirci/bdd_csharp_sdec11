using MovieLibrary.Core;

namespace MovieLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Base specification for PersistentMovie
    /// </summary>
    public abstract class PersistentMovieSpecification
        : BaseStorageSpecification<Movie>
    {
    }
}