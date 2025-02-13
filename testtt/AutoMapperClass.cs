using AutoMapper;
using Models;
using DTO;


namespace testtt
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<Customer,CustomerDTO >().ReverseMap();

            CreateMap<Product,ProductDTO>().ReverseMap();

            CreateMap<Order ,OrderDTO>().ReverseMap();


        }

    }
}
