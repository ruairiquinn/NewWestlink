// Type: System.Data.Entity.DbSet`1
// Assembly: EntityFramework, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Code\NewWestlink\packages\EntityFramework.4.2.0.0\lib\net40\EntityFramework.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal.Linq;
using System.Linq;

namespace System.Data.Entity
{
    public class DbSet<TEntity> : DbQuery<TEntity>, IDbSet<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable, IInternalSetAdapter where TEntity : class
    {
        #region IDbSet<TEntity> Members

        public TEntity Find(params object[] keyValues);
        public TEntity Attach(TEntity entity);
        public TEntity Add(TEntity entity);
        public TEntity Remove(TEntity entity);
        public TEntity Create();
        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity;
        public ObservableCollection<TEntity> Local { get; }

        #endregion

        #region IInternalSetAdapter Members

        IInternalSet IInternalSetAdapter.InternalSet { get; }

        #endregion

        public static implicit operator DbSet(DbSet<TEntity> entry);
        public DbSqlQuery<TEntity> SqlQuery(string sql, params object[] parameters);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType();
    }
}
