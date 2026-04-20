using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Bll.ServicesInterfaces;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Server.Abstraction.Context;
using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Bll.Services;

public class CommentService(BookShopDbContext dbContext, IMapper mapper, IRequestContext requestContext) 
    : ICommentService
{
    private readonly BookShopDbContext dbContext = dbContext;

    public async Task<IList<CommentData>> GetCommentsAsync(int bookId, CommentType? type = null, int count = 5)
    {
        var bookComments = dbContext.Comments
            .Where(x => x.BookId == bookId);

        if( type is not null)
            bookComments = bookComments.Where(x => x.Type == type);

        var comments = await bookComments
            .OrderByDescending(x => x.CreatedDate)
            .ProjectTo<CommentData>(mapper.ConfigurationProvider)
            .Take(count)
            .ToListAsync();

        return comments;
    }

    public async Task<CommentData> CreateCommentAsync(CreateCommentData data)
    {
        var comment = new Comment
        {
            BookId = data.BookId,
            UserId = requestContext.UserId!.Value,
            Type = data.Type,
            Text = data.Text,
            CreatedDate = DateTimeOffset.Now
        };

        dbContext.Comments.Add(comment);

        await dbContext.SaveChangesAsync();

        return await ReloadFromDb(comment.Id);
    }

    private async Task<CommentData> ReloadFromDb(int id)
        => await dbContext.Comments.ProjectTo<CommentData>(mapper.ConfigurationProvider).SingleAsync(x => x.Id == id);

}