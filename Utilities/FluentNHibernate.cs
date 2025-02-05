using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

public class SomeDbEntity
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
}

public class DbEntityMap : ClassMap<SomeDbEntity>
{
    public DbEntityMap()
    {
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Description);
        Table("Product");
    }
}

internal class TEST_IT
{
    static void Main(string[] args)
    {
        using (var session = FluentNHibernateHelper.OpenSession())
        {
            var product = new SomeDbEntity { Name = "Lenovo Laptop", Description = "Sample product" };
            session.SaveOrUpdate(product);
        }
    }
}

public static class FluentNHibernateHelper
{
    public static ISession OpenSession()
    {
        string connectionString = "Write your database connection string here";

        ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(connectionString).ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SomeDbEntity>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();

        return sessionFactory.OpenSession();
    }
}
