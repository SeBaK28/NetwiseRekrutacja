using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface IFileStorageService
    {
        Task SaveToFileAsync(CatFact fact);
    }
}