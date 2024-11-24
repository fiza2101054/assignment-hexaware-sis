using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Service
{
    internal interface IStudentService
    {
        void UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);
        void DisplayStudentInfo();

        void MakePayment(int studentId, decimal amount, DateTime paymentDate);
        void GetPaymentHistory(int studentId);
    }
}
 