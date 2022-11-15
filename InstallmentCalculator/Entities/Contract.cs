using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentCalculator.Entities {
    internal class Contract {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public List<Installment> installments = new List<Installment>();

        public Contract(int number, DateTime date, double value) {
            Number = number;
            Date = date;
            Value = value;
        }

        public void AddInstallment(Installment installment) {
            installments.Add(installment);
        }
    }
}
