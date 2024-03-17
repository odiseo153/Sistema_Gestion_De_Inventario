using Application.Alertas.Created;
using Application.Alertas.Update;
using Application.Productos.Created;
using Application.Productos.Update;
using AutoMapper;


namespace Catalog.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateProductCommand, Producto>().ReverseMap();
            CreateMap<UpdateProductoCommand, Producto>().ReverseMap();


            CreateMap<CreatedAlertaCommand, Alerta>().ReverseMap();
            CreateMap<UpdateAlertaCommand, Alerta>().ReverseMap();


        }
    }
}
