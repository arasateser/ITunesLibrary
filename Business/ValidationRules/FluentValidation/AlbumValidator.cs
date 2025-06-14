﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AlbumValidator : AbstractValidator<Album>
    {
        public AlbumValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
        }
    }
}
