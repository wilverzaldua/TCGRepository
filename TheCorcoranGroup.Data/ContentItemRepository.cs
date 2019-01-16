using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCorcoranGroup.Model;

namespace TheCorcoranGroup.Data
{
    public class ContentItemRepository : IContentItemRepository
    {
        private readonly string _connectionString;

        public ContentItemRepository()
        {
            _connectionString = ConfigurationManager.AppSettings["ConsumerApi.ConnectionString"];
        }

        public IEnumerable<President> GetAllPresidents()
        {
            using (TheCorcoranGroup_dbEntities db = new TheCorcoranGroup_dbEntities())
            {
                var presidentDb = db.Presidents.ToList();
                return presidentDb;
            }
        }
    }
}
