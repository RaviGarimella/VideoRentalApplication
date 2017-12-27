using System;
using System.Collections.Generic;
using System.Data.Entity;  // for MembershipType
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalApplication.Dto;
using VideoRentalApplication.Models;
using AutoMapper;

namespace VideoRentalApplication.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VideoRentalApplicationDBContext db;
        private CustomersController()
        {
            db = new VideoRentalApplicationDBContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        

        //Get Customers api/customers
        public IEnumerable<CustomerDto> getCustomers()
        {
            return db.Customers
                .Include(x => x.MembershipType)  // Eager Loading
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>); 
        }

        // Get Customer by ID api/customers/1
        public CustomerDto getCustomerById(int id)
        {
            var customer = db.Customers.SingleOrDefault(x => x.custID == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        // Post customer api/customers/
        [HttpPost]
        public CustomerDto createCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();
            customerDto.custID = customer.custID;
            return customerDto;
        }

        // Put request api/customers/1
        [HttpPut]
        public void updateCustomer(int id, CustomerDto customerDto)
        {            
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = db.Customers.SingleOrDefault(x => x.custID == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDB);      
      
            /*customerInDB.Name = customer.Name;
            customerInDB.BirthDate = customer.BirthDate;
            customerInDB.MembershipType = customer.MembershipType;
            customerInDB.membershipTypeId = customer.membershipTypeId;
            customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;*/     
       
            db.SaveChanges();            
        }

        // delete customer api/customers/1
        [HttpDelete]
        public void deleteCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(x => x.custID == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customer);
            db.SaveChanges();            
        }
    }
}
