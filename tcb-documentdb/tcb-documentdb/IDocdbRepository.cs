using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcb_documentdb
{
    interface IDocdbRepository<T> where T:class
    {
        Task<T> GetAsync(string id);
        Task<Document> CreateAsync(T value);
        Task<T> UpdateAsync(string id, T value);
        Task<T> DeleteAsync(string id);
        void Initialize();
    }
}
