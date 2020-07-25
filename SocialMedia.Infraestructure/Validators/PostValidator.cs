﻿using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                  .NotNull()
                  .Length(10, 500);

            RuleFor(post => post.Date)
                  .NotNull()
                  .LessThan(DateTime.Now);
        }
    }
}