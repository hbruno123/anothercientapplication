using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Response;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositorios;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService,
                              IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts =  _postService.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);
            var response = new ApiResponse<IEnumerable<PostDTO>>(postsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            var postDto = _mapper.Map<PostDTO>(post);
            var response = new ApiResponse<PostDTO>(postDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDTO postDto)
        {

         
            var post = _mapper.Map<Post>(postDto);

            await _postService.InsertPost(post);
            var response = new ApiResponse<PostDTO>(postDto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,PostDTO postDto)
        {

          
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            await _postService.UpdatePost(post);
            var response = new ApiResponse<PostDTO>(postDto);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }

    }
}
