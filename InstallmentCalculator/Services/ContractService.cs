using InstallmentCalculator.Entities;
using InstallmentCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentCalculator.Services {
    internal class ContractService  {
  
        private IOnlinePaymentService _onlinePaymentService;
        public ContractService(IOnlinePaymentService paymentService) {
            _onlinePaymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double installmentValue = contract.Value / months;
            for (int i = 1; i <= months; i++) {
                DateTime installmentMonth = contract.Date.AddMonths(i);
                double updatedInstallment = installmentValue + _onlinePaymentService.Interest(installmentValue, i);
                double finalInstallment = updatedInstallment + _onlinePaymentService.PaymentFee(updatedInstallment);
                contract.AddInstallment(new Installment(installmentMonth, finalInstallment));
            }
        }
    }
}
