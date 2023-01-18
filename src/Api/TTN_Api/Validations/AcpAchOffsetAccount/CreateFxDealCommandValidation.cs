using FluentValidation;

namespace ACH.Domain.Validations
{
    // public class CreateFxDealCommandValidation : AbstractValidator<CreateFxDealCommand>
    // {
    //     public CreateFxDealCommandValidation()
    //     {
    //         RuleFor(c => c.DealType).NotEmpty().MaximumLength(20);
    //         RuleFor(c => c.DealDate).NotEmpty();
    //         RuleFor(c => c.BaseCcy).NotEmpty().Length(3);
    //         RuleFor(c => c.QuoteCcy).NotEmpty().Length(3);
    //         RuleFor(c => c.BaseCcyAmt).NotEmpty();
    //         RuleFor(c => c.QuoteCcyAmt).NotEmpty();
    //         // RuleFor(c => c.CbBuyRate).NotEmpty().When(m => m.NcbBuyRate == null);
    //         // RuleFor(c => c.NcbBuyRate).NotEmpty().When(m => m.CbBuyRate == null);
    //         RuleFor(c => c.DrAcctNo).NotEmpty().MaximumLength(60);
    //         RuleFor(c => c.DrAcctType).NotEmpty().MaximumLength(6);
    //         RuleFor(c => c.CrAcctNo).NotEmpty().MaximumLength(60);
    //         RuleFor(c => c.CrAcctType).NotEmpty().MaximumLength(6);
    //         RuleFor(c => c.BaseCcyMidRate).NotEmpty();
    //         RuleFor(c => c.QuoteCcyMidRate).NotEmpty();
    //         RuleFor(c => c.BaseCcy).NotEmpty().Length(3);
    //     }
    // }
}