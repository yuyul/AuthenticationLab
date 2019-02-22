using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationLab.Models;

namespace AuthorizationLab.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        static List<Document> _documents = new List<Document>
        {
            new Document { Id = 1, Author = "barry"},
            new Document { Id = 2, Author = "someoneelse"}
        };

        public IEnumerable<Document> Get()
        {
            return _documents;
        }

        public Document Get(int id)
        {
            return (_documents.FirstOrDefault(d => d.Id == id));
        }
    }
}
