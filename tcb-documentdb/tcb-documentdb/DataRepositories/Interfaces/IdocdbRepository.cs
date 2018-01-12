using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcb_documentdb
{
    public interface IDocdbRepository<T> where T:class
    {
        Task<T> GetAsync(string id);
        Task<Document> CreateAsync(T value);
        Task<Document> UpdateAsync(string id, T value);
        Task DeleteAsync(string id);
        void Initialize();
    }
}
