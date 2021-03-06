using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC_WorkWithFakeAPI.Models;

namespace WebMVC_WorkWithFakeAPI.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetListByPostId(int postId);
    }
}
