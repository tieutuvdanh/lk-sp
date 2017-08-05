using AutoMapper;
using LikeSport.Model;
using LikeSport.Web.Models;

namespace LikeSport.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ActivityGroup, ActivityGroupViewModel>().PreserveReferences();
                cfg.CreateMap<ActivityInformation, ActivityInformationViewModel>().PreserveReferences();
                cfg.CreateMap<Activity, ActivityViewModel>().PreserveReferences();
                cfg.CreateMap<Promotion, PromotionViewModel>().PreserveReferences();
                cfg.CreateMap<Model.Service, ServiceViewModel>().PreserveReferences();
                cfg.CreateMap<Address, AddressViewModel>().PreserveReferences();
                cfg.CreateMap<ChatInformation, ChatInformationViewModel>().PreserveReferences();
                cfg.CreateMap<Device, DeviceViewModel>().PreserveReferences();
                cfg.CreateMap<Feeback, FeebackViewModel>().PreserveReferences();
                cfg.CreateMap<Notification, NotificationViewModel>().PreserveReferences();

                cfg.CreateMap<Rate, RateViewModel>().PreserveReferences();
                cfg.CreateMap<Review, ReviewViewModel>().PreserveReferences();

            });
        }
    }
}