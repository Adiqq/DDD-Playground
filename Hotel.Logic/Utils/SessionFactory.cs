using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ForeignKey = FluentNHibernate.Conventions.Helpers.ForeignKey;

namespace Hotel.Logic.Utils
{
    public static class SessionFactory
    {
        private static ISessionFactory _factory;
        public const string NextHiValueColumnName = "NextHigh";
        public const string NHibernateHiLoIdentityTableName = "Ids";
        public const string TableColumnName = "EntityName";


        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        public static void Init(string connectionString)
        {
            _factory = BuildSessionFactory(connectionString);
        }

        public static void CreateHighLowScript(NHibernate.Cfg.Configuration config)
        {

            var script = new StringBuilder();
            script.AppendFormat("DELETE FROM {0};", NHibernateHiLoIdentityTableName);
            script.AppendLine();
            script.AppendFormat("ALTER TABLE {0} ADD {1} VARCHAR(128) NOT NULL;", NHibernateHiLoIdentityTableName, TableColumnName);
            script.AppendLine();
            script.AppendFormat("CREATE NONCLUSTERED INDEX IX_{0}_{1} ON {0} ({1} ASC);", NHibernateHiLoIdentityTableName, TableColumnName);
            script.AppendLine();
            script.AppendLine("GO");
            script.AppendLine();
            foreach (var tableName in config.ClassMappings.Select(m => m.Table.Name).Distinct())
            {
                //strip [dbo].[TableName] to TableName
                var match = Regex.Match(tableName, @"[^[\]]+(?=])", RegexOptions.RightToLeft);

                script.AppendFormat(string.Format("INSERT INTO [{0}] ({1}, {2}) VALUES ('{3}',1);", NHibernateHiLoIdentityTableName, TableColumnName, NextHiValueColumnName, match.Value));
                script.AppendLine();
            }

            config.AddAuxiliaryDatabaseObject(new SimpleAuxiliaryDatabaseObject(script.ToString(), null, new HashSet<string> { typeof(MsSql2000Dialect).FullName, typeof(MsSql2005Dialect).FullName, typeof(MsSql2008Dialect).FullName, typeof(MsSql2012Dialect).FullName }));
        }

        private static ISessionFactory BuildSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(
                        ForeignKey.EndsWith("ID"),
                        ConventionBuilder.Property
                            .When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                    .Conventions.Add<TableNameConvention>()
                    .Conventions.Add<HiLoConvention>()
                )
                .ExposeConfiguration(cfg =>
                {
                    CreateHighLowScript(cfg);
                    new SchemaExport(cfg)
                      .Create(false, true);
                });
            return configuration.BuildSessionFactory();

        }

        public class TableNameConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table($"[dbo].[{instance.EntityType.Name}]");
            }
        }

        public class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column($"{instance.EntityType.Name}ID");
                instance.GeneratedBy.HiLo("[dbo].[Ids]", "NextHigh", "9", $"EntityName = '{instance.EntityType.Name}'");
            }
        }
    }
}
