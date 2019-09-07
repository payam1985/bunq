using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DomainCore
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPayment(long id);

        Task<IEnumerable<Payment>> GetUserPayments(long userId);

        Task<Payment> Create(Payment payment);

        Task<Payment> Update(Payment payment);

        Task<int> Delete(long id);
    }
}
