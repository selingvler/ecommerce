﻿using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Controller;
[ApiController]
[Route("UserProducts")]
public class UserProductController
{
    private readonly IUserProductBusiness _business;

    public UserProductController(IUserProductBusiness business)
    {
        _business = business;
    }
    [HttpPost]
    public async Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model)
    {
        model?.InitializeUserId(model.UserId);
        model?.InitializeProductId(model.ProductId);
        return await _business.RegisterUserProduct(model);
    }

    [HttpGet]
    public IEnumerable<UserProductResponseModel> ViewUserProducts()
    {
        return _business.ViewUserProducts();
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteUserProduct([FromRoute] Guid id)
    {
        await _business.DeleteUserProduct(id);
    }

    [HttpPut]
    public async Task UpdateUserProduct(UpdateUserProductRequestModel model)
    {
        model?.Initialize(model.Id);
        await _business.UpdateUserProduct(model);
    }

    [HttpGet("CheapestProduct/{id:guid}")]
    public UserProductResponseModel GetCheapestUserProduct([FromRoute] Guid id)
    {
        return _business.GetCheapestUserProduct(id);
    }
}