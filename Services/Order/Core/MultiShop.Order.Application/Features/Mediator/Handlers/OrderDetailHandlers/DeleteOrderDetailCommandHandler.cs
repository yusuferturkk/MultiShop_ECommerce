using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderDetailId);
            await _repository.DeleteAsync(value);
        }
    }
}
