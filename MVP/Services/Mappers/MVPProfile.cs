using AutoMapper;
using Data.Models;
using Services.DataModels;

namespace Services.Mappers
{
    public class MVPProfile : Profile
    {
        public MVPProfile()
        {
            CreateMap<Invoice, HistoryResponse>();
        }
    }
}
