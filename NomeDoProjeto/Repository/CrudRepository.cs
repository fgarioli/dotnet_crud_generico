using Microsoft.EntityFrameworkCore;
using NomeDoProjeto.Dto;
using NomeDoProjeto.UnitOfWork;

namespace NomeDoProjeto.Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; }
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public CrudRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _dbContext = unitOfWork.Context;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Merge(T entity, T requestEntity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(requestEntity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task<Page<T>> FindAsync(IPageQuery<T> pageQuery)
        {
            IQueryable<T> query = this._dbSet;

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
            result.PageItems = await query.Skip(skip).Take(pageQuery.PageSize).ToListAsync();

            return result;
        }
    }
}