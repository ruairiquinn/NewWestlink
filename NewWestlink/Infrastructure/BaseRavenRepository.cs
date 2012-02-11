using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client;
using StructureMap;

namespace NewWestlink.Infrastructure
{
    public class BaseRavenRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDocumentStore _documentStore;

        protected BaseRavenRepository()
        {
            _documentStore = ObjectFactory.GetInstance<IDocumentStore>();     
        }

        public TEntity Create(TEntity entity)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
                return entity;
            }
        }

        public void Add(TEntity entity)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var teamToDelete = session.Load<TEntity>(id);
                session.Delete(teamToDelete);
                session.SaveChanges();
            }
        }

        public TEntity GetByKey(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Load<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Query<TEntity>().Where(expression);
            }
        }

        public IEnumerable<TEntity> All()
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Query<TEntity>();
            }
        }
    }
}