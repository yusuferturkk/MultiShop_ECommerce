﻿namespace MultiShop.Discount.Dtos.CouponDtos
{
    public class CreateCouponDto
    {
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool CouponIsActive { get; set; }
        public DateTime CouponValidDate { get; set; }
    }
}
