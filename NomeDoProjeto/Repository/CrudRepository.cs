using Microsoft.EntityFrameworkCore;
using NomeDoProjeto.Context;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Models;

namespace NomeDoProjeto.Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class, IAutoMap
    {
        protected readonly ApplicationDbContext _dbContext;
        public DbSet<T> DbSet;

        public CrudRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            DbSet = dbContext.Set<T>();
        }

        public void Create(T obj)
        {
            this.DbSet.Add(obj);
        }

        public void Update(T obj)
        {
            DbSet.Attach(obj);
            this._dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T? entityToDelete = DbSet.Find(id);
            if (entityToDelete == null)
                throw new Exception("Entity not found");
            Delete(entityToDelete);
        }

        public T? Read(int id)
        {
            return this.DbSet.Find(id);
        }

        public Page<T> Read(IPageQuery<T> pageQuery)
        {
            IQueryable<T> query = this.DbSet;

            if (pageQuery.Filter != null)
            {
                query = query.Where(pageQuery.Filter);
            }

            foreach (var includeProperty in pageQuery.IncludeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var result = new Page<T>
            {
                CurrentPage = pageQuery.Page,
                PageSize = pageQuery.PageSize,
                RowCount = query.Count(),
            };

            var pageCount = (double)result.RowCount / pageQuery.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (pageQuery.Page - 1) * pageQuery.PageSize;
            result.PageItems = query.Skip(skip).Take(pageQuery.PageSize).ToList();

            return result;
        }
    }
}