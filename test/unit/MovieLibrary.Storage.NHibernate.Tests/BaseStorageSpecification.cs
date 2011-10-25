using System.Collections.Generic;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MavenThought.Commons.Testing;
using MovieLibrary.Core;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MovieLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Storage specification
    /// </summary>
    /// <typeparam name="T">
    /// Type of element to store
    /// </typeparam>
    public abstract class BaseStorageSpecification<T>
        : AutoMockSpecificationWithNoContract<ISessionFactory> where T : new()
    {
        /// <summary>
        /// Name of the file to use
        /// </summary>
        private readonly string DbFile;

        /// <summary>
        /// Creates a new instance of StorageSpecification initializing the DbFile to a temporary path
        /// </summary>
        protected BaseStorageSpecification()
        {
            DbFile = Path.GetTempFileName();
        }

        /// <summary>
        /// Elements to populate the storage
        /// </summary>
        protected IEnumerable<T> Elements { get; set; }

        /// <summary>
        /// Create the TSUT
        /// </summary>
        /// <returns>
        /// An instance of TSUT
        /// </returns>
        protected override ISessionFactory CreateSut()
        {
            var configurer = SQLiteConfiguration.Standard.UsingFile(this.DbFile);

            configurer.ShowSql();

            return Fluently
                .Configure()
                .ExposeConfiguration(BuildSchema)
                .Database(configurer)
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<IMovie>()))
                .BuildSessionFactory(); 
        }

        /// <summary>
        /// Deletes the database if exists and creates the schema
        /// </summary>
        /// <param name="config">
        /// Configuration to use
        /// </param>
        private void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }

            // export schema
            new SchemaExport(config).Create(true, true);
        }
    }
}