using System;
using Catnap.Database;
using Catnap.Mapping;
using Catnap.Mapping.Impl;

namespace Catnap.Configuration.Impl
{
    public class Configurator : IConfigurator
    {
        private string connString;
        private IDbAdapter dbAdapter;
        private Action<IDomainMappable> domainConfig;
        private Func<ISessionCache> sessionCacheProvider;

        public IConfigurator Domain(Action<IDomainMappable> config)
        {
            domainConfig = config;
            return this;
        }

        public IConfigurator ConnectionString(string connectionString)
        {
            connString = connectionString;
            return this;
        }

        public IConfigurator DatabaseAdapter(IDbAdapter adapter)
        {
            dbAdapter = adapter;
            return this;
        }

        public IConfigurator SessionCache(Func<ISessionCache> cacheProvider)
        {
            sessionCacheProvider = cacheProvider;
            return this;
        }

        public ISessionFactory Build()
        {
            if (dbAdapter == null)
            {
                dbAdapter = new NullDbAdapter();
            }
            var domainMap = new DomainMap(dbAdapter);
            if (domainConfig != null)
            {
                domainConfig(domainMap);
            }
            domainMap.Done();
            if (sessionCacheProvider == null)
            {
                sessionCacheProvider = () => new SessionCache();
            }
            return new SessionFactory(connString, dbAdapter, domainMap, sessionCacheProvider);
        }
    }
}