using MavenThought.Commons.Testing;

namespace MovieLibrary.Core.Tests
{
    /// <summary>
    /// Base specification for Movie
    /// </summary>
    public abstract class MovieSpecification
        : AutoMockSpecification<Movie, IMovie>
    {
    }
}