using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstEx
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = "Bill" };
                ctx.Students.Add(stud);
                ctx.SaveChanges();
                Console.WriteLine("Stiudent Saved");

                var s = ctx.Students.First();
                
            }

            using (var ctx = new InheritanceMappingContext())
            {
                var bnkAcc = new BankAccount()
                {
                    BankName = "NSB",
                    Swift = "IDN"
                };

                ctx.BillingDetails.Add(bnkAcc);
                ctx.SaveChanges();
                Console.WriteLine("Billing Details Added");

                //Polymorphic Query
                IQueryable<BillingDetail> linqQuery = from b in ctx.BillingDetails select b;
                List<BillingDetail> billingDetails = linqQuery.ToList();
                billingDetails.ForEach(detail => Console.WriteLine(detail.BillingDetailId.ToString()));

                //Non Polymorphic Query
                IQueryable<BankAccount> query = from b in ctx.BillingDetails.OfType<BankAccount>() select b;
                List<BankAccount> bankDetails = query.ToList();
                bankDetails.ForEach(detail => Console.WriteLine(detail.BankName.ToString()));

            }
        }
    }
}
