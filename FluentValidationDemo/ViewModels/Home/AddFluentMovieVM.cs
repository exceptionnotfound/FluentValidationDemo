using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;

namespace FluentValidationDemo.ViewModels.Home
{
[Validator(typeof(AddFluentMovieVMValidator))]
public class AddFluentMovieVM
{
    [Display(Name = "Title:")]
    public string Title { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Release Date:")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Running Time:")]
    public int RunningTimeMinutes { get; set; }

    [Display(Name = "Leading Actor:")]
    public string LeadingActor { get; set; }

    [Display(Name = "Supporting Actor:")]
    public string SupportingActor { get; set; }
}

public class AddFluentMovieVMValidator : AbstractValidator<AddFluentMovieVM>
{
    public AddFluentMovieVMValidator()
    {
        RuleFor(x => x.Title).NotNull().WithMessage("Please enter a title");
        RuleFor(x => x.ReleaseDate).NotNull().WithMessage("Please enter a release date");
        RuleFor(x => x.RunningTimeMinutes).NotNull().WithMessage("Please enter the running time")
                                        .GreaterThan(0).WithMessage("The Running Time cannot be negative");
        RuleFor(x => x.LeadingActor).NotNull().WithMessage("Please enter the leading actor")
                                    .NotEqual(x => x.SupportingActor).WithMessage("The leading and supporting actors cannot be the same person");
    }
}
}