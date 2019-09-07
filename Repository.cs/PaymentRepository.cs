using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DomainCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Payment> GetPayment(long id) => await _unitOfWork.Context.Payments.FindAsync(id);

        public async Task<IEnumerable<Payment>> GetUserPayments(long userId)
            => await _unitOfWork.Context.Payments.Where(a => a.UserId == userId).ToListAsync();

        public async Task<Payment> Create(Payment payment)
        {
            _unitOfWork.Context.Payments.Add(payment);
            await _unitOfWork.Commit();
            return payment;
        }

        public async Task<Payment> Update(Payment payment)
        {
            _unitOfWork.Context.Entry(payment).State = EntityState.Modified;
            await _unitOfWork.Commit();
            return payment;
        }

        public async Task<int> Delete(long id)
        {
            var payment = await GetPayment(id);
            return payment == null ? 0 : await DeletePayment(payment);
        }

        private async Task<int> DeletePayment(Payment payment)
        {
            if (_unitOfWork.Context.Entry(payment).State == EntityState.Detached)
                _unitOfWork.Context.Payments.Attach(payment);
            _unitOfWork.Context.Payments.Remove(payment);
            return await _unitOfWork.Commit();
        }
    }
}
