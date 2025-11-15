using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                City = request.City,
                District = request.District,
                ZipCode = request.ZipCode,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
            });
        }
    }
}
