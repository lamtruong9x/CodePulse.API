using AutoMapper;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;

namespace CodePulse.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<BlogPost, BlogPostDto>();
            CreateMap<CreateBlogPostRequestDto, BlogPost>();
            CreateMap<UpdateBlogPostRequestDto, BlogPost>();
        }
    }
}
