using AuthorizationLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationLab.Repositories
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> Get();
        Document Get(int id);
    }
}
