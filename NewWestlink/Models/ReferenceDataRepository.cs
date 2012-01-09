using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NewWestlink.Models
{ 
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        NewWestlinkContext context = new NewWestlinkContext();

        public IQueryable<ReferenceData> All
        {
            get { return context.ReferenceDatas; }
        }

        public IQueryable<ReferenceData> AllIncluding(params Expression<Func<ReferenceData, object>>[] includeProperties)
        {
            IQueryable<ReferenceData> query = context.ReferenceDatas;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ReferenceData Find(string id)
        {
            return context.ReferenceDatas.Find(id);
        }

        public void InsertOrUpdate(ReferenceData referencedata)
        {
            if (referencedata.Id == default(string)) {
                // New entity
                context.ReferenceDatas.Add(referencedata);
            } else {
                // Existing entity
                context.Entry(referencedata).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var referencedata = context.ReferenceDatas.Find(id);
            context.ReferenceDatas.Remove(referencedata);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IReferenceDataRepository
    {
        IQueryable<ReferenceData> All { get; }
        IQueryable<ReferenceData> AllIncluding(params Expression<Func<ReferenceData, object>>[] includeProperties);
        ReferenceData Find(string id);
        void InsertOrUpdate(ReferenceData referencedata);
        void Delete(string id);
        void Save();
    }
}