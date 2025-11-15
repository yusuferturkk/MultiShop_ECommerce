using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AddressId);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                UserId = value.UserId,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Email = value.Email,
                PhoneNumber = value.PhoneNumber,
                Country = value.Country,
                City = value.City,
                District = value.District,
                ZipCode = value.ZipCode,
                AddressLine1 = value.AddressLine1,
                AddressLine2 = value.AddressLine2,
            };
        }
    }
}
