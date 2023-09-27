﻿using System.Collections;
using web_ecommerce.RequestResponseModels.OrderInstances;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class OrderInstanceBusiness : IOrderInstanceBusiness
{
    private readonly IOrderInstanceService _service;
    private readonly IUserService _userService;

    public OrderInstanceBusiness(IOrderInstanceService service, IUserService userService)
    {
        _service = service;
        _userService = userService;
    }

    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        CreateOrderInstanceValidation(model);
        return await _service.CreateOrderInstance(model);
    }

    public async Task CreateOrderInstanceUpdated(CreateOrderInstanceRequestModel model)
    {
        await _service.CreateOrderInstanceUpdated(model);
    }

    public Task<IEnumerable> ViewOrderDetails(Guid orderId)
    {
        return _service.ViewOrderDetails(orderId);
    }

    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _service.View();
    }

    public async Task DeleteOrderInstance(Guid id)
    {
        await _service.DeleteOrderInstance(id);
    }

    public async Task<IEnumerable> WaitingForApproval(Guid userId)
    {
        await WaitingForApprovalValidation(userId);
        return _service.WaitingForApproval(userId);
    }

    public async Task OrderInstanceSellerResponse(OrderInstanceInProcessModel model)
    {
        await _service.OrderInstanceSellerResponse(model);
    }

    public async Task ReturnOrderInstance(ReturnOrderInstanceModel model)
    {
        await _service.ReturnOrderInstance(model);
    }
}