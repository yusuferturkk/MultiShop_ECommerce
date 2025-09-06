﻿using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
    }
}
