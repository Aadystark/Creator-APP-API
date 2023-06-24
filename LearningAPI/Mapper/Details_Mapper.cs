using AutoMapper;

namespace LearningAPI.Mapper
{
    public class Details_Mapper: Profile
    {
        public Details_Mapper()
        {
            CreateMap<Datum, DTO.Datum>().ReverseMap();
            CreateMap<Datum, DTO.AddDatum>().ReverseMap();
            CreateMap<TableData, DTO.TableDataDTO>().ReverseMap();
            CreateMap<SPData, DTO.SPDataDTO>().ReverseMap();

        }
    }
}
