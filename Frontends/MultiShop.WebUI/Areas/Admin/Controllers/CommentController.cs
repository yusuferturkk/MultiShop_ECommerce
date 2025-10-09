using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CommentViewbagList();
            var values = await _commentService.GetAllCommentAsync();
            return View(values);
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {
            CommentViewbagList();
            var value = await _commentService.GetByIdCommentAsync(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        void CommentViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";
        }
    }
}
