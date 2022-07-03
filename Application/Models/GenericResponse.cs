using System.Collections.Generic;

namespace Application.Models
{
    public class GenericResponse<T>
    {
        public T Result { get; set; }
        public List<T> Results { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Total { get; set; }

        public static GenericResponse<T> Succeeded(T result)
        {
            return new GenericResponse<T>
            {
                Result = result,
                Success = true
            };
        }
        
        public static GenericResponse<T> Succeeded(List<T> results)
        {
            return new GenericResponse<T>
            {
                Results = results,
                Success = true
            };
        }
        
        public static GenericResponse<T> Succeeded(List<T> results, int total)
        {
            return new GenericResponse<T>
            {
                Results = results,
                Success = true,
                Total = total
            };
        }
       
        public static GenericResponse<T> Failed(string message)
        {
            return new GenericResponse<T>
            {
                Message = message,
                Success = false
            };
        }
    }
}