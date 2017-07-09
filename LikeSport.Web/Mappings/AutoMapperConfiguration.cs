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
                cfg.CreateMap<ActivityGroup, ActivityGroupViewModel>().ReverseMap();
                cfg.CreateMap<ActivityInformation, ActivityInformationViewModel>().ReverseMap();
                cfg.CreateMap<Activity, ActivityViewModel>().ReverseMap();
                cfg.CreateMap<Address, AddressViewModel>().ReverseMap();
                cfg.CreateMap<ChatInformation, ChatInformationViewModel>().ReverseMap();
                cfg.CreateMap<Device, DeviceViewModel>().ReverseMap();
                cfg.CreateMap<Feeback, FeebackViewModel>().ReverseMap();
                cfg.CreateMap<Notification, NotificationViewModel>().ReverseMap();
                cfg.CreateMap<Promotion, PromotionViewModel>().ReverseMap();
                cfg.CreateMap<Rate, RateViewModel>().ReverseMap();
                cfg.CreateMap<Review, ReviewViewModel>().ReverseMap();
                cfg.CreateMap<Model.Service, ServiceViewModel>().ReverseMap();
            });
        }
    }
}