using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryRepository.GetAllAsync();
            var categoryDtos = new List<CategoryDto>();
            foreach(var category in categories)
            {
                var categoryDto = new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle,
                };

                categoryDtos.Add(categoryDto);
            }

            return Ok(categoryDtos);
        }

       [HttpPost]
       public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto request)
       {
       // Map dto to domain
            var category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
           

            category = await categoryRepository.CreateAsync(category);

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(categoryDto);
       } 
      
    }
}
