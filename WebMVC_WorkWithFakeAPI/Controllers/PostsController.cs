using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC_WorkWithFakeAPI.Models;
using WebMVC_WorkWithFakeAPI.Models.ViewModels;
using WebMVC_WorkWithFakeAPI.Repository.IRepository;

namespace WebMVC_WorkWithFakeAPI.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly ICommentRepository _commentRepo;

        public PostsController(IPostRepository postRepo, ICommentRepository commentRepo)
        {
            _postRepo = postRepo;
            _commentRepo = commentRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllPost()
        {
            return Json(new { data = await _postRepo.GetAllAsync() });
        }


        public async Task<IActionResult> Detail(int id)
        {
            var post = await _postRepo.GetAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            PostVM viewModel = new PostVM();
            viewModel.Post = post;
            viewModel.Comments = await _commentRepo.GetListByPostId(id);

            return View(viewModel);
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                return View(new Post());
            }

            var post = await _postRepo.GetAsync((int)id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Post model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == 0)
            {
                await _postRepo.CreateAsync(model);
            }
            else
            {
                await _postRepo.UpdateAsync(model.Id, model);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isSucceed = await _postRepo.DeleteAsync(id);

            if (isSucceed)
            {
                return Json(new { success = true, message = "Delete successful" });
            }
            else
            {
                return Json(new { success = false, message = "Delete not successful" });
            }
        }
    }
}
