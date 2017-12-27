using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.ViewModels
{
    public class CreateCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}