using AspVue.Data.Entities;

namespace AspVue.Features.Orders
{
    public class CreateOrderResponseViewModel
    {
        public int OrderId { get; set; }
        public string PaymentStatus { get; set; }
        public CreateOrderResponseViewModel(int orderId, PaymentStatus paymentStatus)
        {
            OrderId = orderId;
            PaymentStatus = paymentStatus.ToString();
        }
    }
}