﻿using TellDontAskKata.Main.Repository;
using TellDontAskKata.Main.Requests;
using TellDontAskKata.Main.Service;

namespace TellDontAskKata.Main.UseCase
{
    public class OrderShipmentUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShipmentService _shipmentService;

        public OrderShipmentUseCase(
            IOrderRepository orderRepository,
            IShipmentService shipmentService)
        {
            _orderRepository = orderRepository;
            _shipmentService = shipmentService;
        }

        public void Run(OrderShipmentRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);

            order.Ship();

            _shipmentService.Ship(order);
            _orderRepository.Save(order);
        }
    }
}
