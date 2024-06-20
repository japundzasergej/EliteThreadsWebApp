﻿using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Queries
{
    public class GetActiveDiscountsQuery : IRequest<IEnumerable<DiscountDTO>> { }
}
