using BookShop.Transfer.Enums;
using FluentValidation;

namespace BookShop.Transfer.Dtos;

internal class LogirRequestDataValidator : AbstractValidator<CreateCommentData>
{
    public LogirRequestDataValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0);

        //When(x => x.Type == CommentType.Comment, () =>
        //{
        //    RuleFor(x => x.Text).NotEmpty().MaximumLength(500);
        //});

        //When(x => x.Type == CommentType.Review, () =>
        //{
        //    RuleFor(x => x.Text).NotEmpty().MaximumLength(2000);
        //});

        RuleFor(x => x.Text).NotEmpty()
            .MaximumLength(500).When(x => x.Type == CommentType.Comment, ApplyConditionTo.CurrentValidator)
            .MaximumLength(2000).When(x => x.Type == CommentType.Review, ApplyConditionTo.CurrentValidator);

    }
}
