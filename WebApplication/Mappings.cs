using AutoMapper;
using System.Linq;

namespace WebApplication
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Product, ProductDTO>();

            CreateMap<Order, OrderDTO>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Lines.Select(l => l.Product)));
        }
    }
}
