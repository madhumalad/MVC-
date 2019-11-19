using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class CustomerRepository : IRepository<Customer,string>
    {
        static List<Customer> customerList;
        public CustomerRepository()
        {
            if (customerList == null) {
            customerList = new List<Customer>();
            AddItemsToList();
            }
        }
        private void AddItemsToList()
        {
            Customer c1 = new Customer
            {
                CustomerID = "ABCD",
                CompanyName = "Suresh&Ramesh Corportaion",
                ContactName = "Suresh Mehata",
                City = "Bengaluru",
                Country = "India"
            };
            customerList.Add(c1);
            customerList.Add(new Customer
            {
                CustomerID = "xyz",
                CompanyName = "Sneha Corportaion",
                ContactName = "Rakshitha",
                City = "Bengaluru",
                Country = "India"



            });
            customerList.Add(new Customer
            {
                CustomerID = "LMNO",
                CompanyName = "Manju&Vijaya Corportaion",
                ContactName = "Chitra",
                City = "Mysore",
                Country = "India"



            });



        }
        public IQueryable<Customer> GetAll()
        {
            var query = from item in customerList select item;
            return query.AsQueryable();
            //throw n
        }
        public Customer GetDetails(string identity)
        {
            return customerList.FirstOrDefault(c => c.CustomerID.Equals(identity));
            // throw new NotImplementedException();
        }


        public void CreateNew(Customer item)
        {
            if (item != null)
            {
                //customerList.RemoveAll(c =>c.CustomerID==item.CustomerID);
                customerList.Add(item);
            }
        }

        public void Delete(string identity)
        {
           if(!string.IsNullOrEmpty(identity))
            {
                customerList.RemoveAll(c => c.CustomerID == identity);
            }
        }

       
        public void Update(Customer item)
        {
            if (item != null)
            {
                customerList.RemoveAll(c => c.CustomerID == item.CustomerID);
                customerList.Add(item);
            }
        }
    }
}