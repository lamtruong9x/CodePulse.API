using AutoMapper;
using Azure.Core;
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
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;

        public BlogPostsController(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
        }

        // GET: /api/categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await blogPostRepository.GetAllAsync();
            
            var blogPostDtos = mapper.Map<List<BlogPostDto>>(categories);

            return Ok(blogPostDtos);
        }

        // POST: /api/categories
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogPostRequestDto request)
        {
            // Map dto to domain
            BlogPost blogPost = mapper.Map<BlogPost>(request);

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            var blogPostDto = mapper.Map<BlogPostDto>(blogPost);

            return Ok(blogPostDto);
        }
        // GET: /api/categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var blogPost = await blogPostRepository.GetAsync(id);
            if (blogPost is null)
            {
                return NotFound();
            }
            var blogPostDto = mapper.Map<BlogPostDto>(blogPost);

            return Ok(blogPostDto);
        }

        // PUT: /api/categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBlogPost([FromRoute] Guid id, [FromBody] UpdateBlogPostRequestDto request)
        {
            var blogPost = mapper.Map<BlogPost>(request);

            blogPost = await blogPostRepository.UpdateAsync(blogPost);
            if (blogPost is null)
            {
                return NotFound();
            }


            var blogPostDto = mapper.Map<BlogPostDto>(blogPost);

            return Ok(blogPostDto);
        }

        // DEL: /api/categories/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            var blogPost = await blogPostRepository.DeleteAsync(id);
            if (blogPost is null)
            {
                return NotFound();
            }

            var blogPostDto = mapper.Map<BlogPostDto>(blogPost);

            return Ok(blogPostDto);
        }
    }
}
