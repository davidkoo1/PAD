using BLL.Interfaces;
using DAL.Interfaces;
using DataContext;
using Domain;

namespace BLL.Repository
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public void CreatePost(PostDto postDto)
        {
            Post post = new Post()
            {
                Id = postDto.Id,
                Author = postDto.Author,
                Content = postDto.Content.Replace("\n", "<br />"),
                Date = postDto.Date
            };
            _postRepository.CreatePost(post);
        }

        public IList<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAllPosts();

            var dtos = posts.Select(post => new PostDto()
            {
                Id = post.Id,
                Author = post.Author,
                Content = post.Content,
                Date = post.Date
            }).ToList();

            return dtos;
        }
    }
}
