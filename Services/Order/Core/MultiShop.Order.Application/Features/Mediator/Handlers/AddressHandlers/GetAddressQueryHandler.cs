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
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Country = x.Country,
                City = x.City,
                District = x.District,
                ZipCode = x.ZipCode,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
            }).ToList();
        }
    }
}
