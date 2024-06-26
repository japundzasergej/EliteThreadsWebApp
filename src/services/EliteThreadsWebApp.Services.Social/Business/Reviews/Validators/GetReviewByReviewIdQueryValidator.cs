﻿using EliteThreadsWebApp.Services.Social.Business.Reviews.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Validators
{
    public class GetReviewByReviewIdQueryValidator : AbstractValidator<GetReviewByReviewIdQuery>
    {
        public GetReviewByReviewIdQueryValidator()
        {
            RuleFor(query => query.ReviewId).NotEmpty();
        }
    }
}
