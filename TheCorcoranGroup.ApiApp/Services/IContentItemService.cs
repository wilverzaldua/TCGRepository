using System.Collections.Generic;
using TheCorcoranGroup.Model;

namespace TheCorcoranGroup.ApiApp.Services
{
    public interface IContentItemService
    {
        IEnumerable<PresidentModel> GetAllPresidents();
    }
}