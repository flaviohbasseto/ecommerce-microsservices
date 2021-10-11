using AutoMapper;
using BasketAPI.Entities;
using EventBusRabbitMQ.Events;

namespace BasketAPI.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
