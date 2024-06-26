﻿using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class CreateDiscountCommand : IRequest<bool>
    {
        public CreateDiscountDTO DiscountDTO { get; init; }
    }
}
