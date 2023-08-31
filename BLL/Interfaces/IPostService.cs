using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        IList<PostDto> GetAllPosts();

        void CreatePost(PostDto postDto);
    }
}
