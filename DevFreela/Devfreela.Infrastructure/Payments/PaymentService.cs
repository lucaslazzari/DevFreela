using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devfreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            // Implementar lógica de pagamento com Gateway de Pagamento

            return Task.FromResult(true);
        }
    }
}
