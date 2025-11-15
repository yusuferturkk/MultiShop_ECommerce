using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class OrderProductSummaryViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public OrderProductSummaryViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
