using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<GenericResponse<T>> ToDataSourceResultAsync<T>(this IQueryable<T> query, DataSourceRequest request)
        {
            var count = await query
                .CountAsync();
            
            var result = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            
            return GenericResponse<T>.Succeeded(result, count);
        }
    }
}