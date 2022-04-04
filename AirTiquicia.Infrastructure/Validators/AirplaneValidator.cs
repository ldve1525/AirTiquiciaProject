using AirTiquicia.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Infrastructure.Validators
{
    public class AirplaneValidator : AbstractValidator<AirplaneDTO>
    {
        public AirplaneValidator()
        {
            RuleFor(airplane => airplane.IdAirplane).NotEmpty();
            RuleFor(airplane => airplane.Description).NotEmpty();
        }
    }
}
