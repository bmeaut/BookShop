using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

public class CommentsController(ICommentService commentService) : BaseController
{
    [HttpGet]
    public async Task<IList<CommentData>> GetComments(int bookId, CommentType? type = null, int count = 5)
        => await commentService.GetCommentsAsync(bookId, type, count);

    [HttpPost]
    [Authorize]
    public async Task<CommentData> CreateComment(CreateCommentData data)
        => await commentService.CreateCommentAsync(data);
}
