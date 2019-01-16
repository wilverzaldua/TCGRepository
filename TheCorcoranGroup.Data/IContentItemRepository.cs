using System.Collections.Generic;
using TheCorcoranGroup.Model;

namespace TheCorcoranGroup.Data
{
    public interface IContentItemRepository
    {
        IEnumerable<President> GetAllPresidents();
    }
}