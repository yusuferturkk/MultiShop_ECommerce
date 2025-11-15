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
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AddressId);
            value.UserId = request.UserId;
            value.FirstName = request.FirstName;
            value.LastName = request.LastName;
            value.Email = request.Email;
            value.PhoneNumber = request.PhoneNumber;
            value.Country = request.Country;
            value.City = request.City;
            value.District = request.District;
            value.ZipCode = request.ZipCode;
            value.AddressLine1 = request.AddressLine1;
            value.AddressLine2 = request.AddressLine2;
            await _repository.UpdateAsync(value);
        }
    }
}
