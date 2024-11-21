using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Model
{
    internal class Payment
    {
        public int PaymentId { get; set;}
        public int StudentId{get; set;} // Reference to a Student
        public double Amount{get; set;}
        public DateTime PaymentDate{get; set;}
 
        public Payment(int paymentId, int studentId, double amount, DateTime paymentDate)
        {
            PaymentId = paymentId;
            StudentId = studentId;
            Amount = amount;
            PaymentDate = paymentDate;
        }
    }
}
