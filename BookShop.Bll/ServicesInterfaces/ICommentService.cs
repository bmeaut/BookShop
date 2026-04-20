using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;

namespace BookShop.Bll.ServicesInterfaces;

public interface ICommentService
{
    Task<IList<CommentData>> GetCommentsAsync(int bookId, CommentType? type = null, int count = 5);

    Task<CommentData> CreateCommentAsync(CreateCommentData data);
}
