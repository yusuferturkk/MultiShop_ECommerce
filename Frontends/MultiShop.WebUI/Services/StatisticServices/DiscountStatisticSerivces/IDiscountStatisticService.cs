namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticSerivces
{
    public interface IDiscountStatisticService
    {
        Task<int> GetDiscountCouponCount();
    }
}
