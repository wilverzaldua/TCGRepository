using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheCorcoranGroup.Data;
using TheCorcoranGroup.Model;

namespace TheCorcoranGroup.ApiApp.Services
{
    public class ContentItemService: IContentItemService
    {
        private readonly IContentItemRepository _contentItemRepository;

        public ContentItemService(IContentItemRepository contentItemRepository)
        {
            _contentItemRepository = contentItemRepository;
        }

        public IEnumerable<PresidentModel> GetAllPresidents()
        {
            List<President> presidents = new List<President>();
            List<PresidentModel> presidentsModel = new List<PresidentModel>();
            presidents = _contentItemRepository.GetAllPresidents().ToList();

            foreach (var item in presidents)
            {
                PresidentModel president = new PresidentModel
                {
                    id = item.id,
                    Name = item .name,
                    Birthday = item.birthday,
                    Birthplace = item.birthplace,
                    Deathday = item.deathday,
                    Deathplace = item.deathplace
                };

                presidentsModel.Add(president);
            }

            return presidentsModel;
        }
    }
}