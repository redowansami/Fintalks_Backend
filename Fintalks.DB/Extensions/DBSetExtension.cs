using Fintalks.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.DB.Extensions
{
    public static class DBSetExtension
    {
        public static void SoftDelete<T>(this DbSet<T> dbSet, T entity)
            where T : class, ISoftDeletable
        {
            entity.DeletedAt = DateTime.UtcNow;
            var entry = dbSet.Entry(entity);
            entry.Property(e => e.DeletedAt).IsModified = true;
        }
    }
}
