using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.Dto
{
    public class CustomerDto
    {
        public int custID { get; set; }

        [Required(ErrorMessage = "Customer Name is a required field")]
        [StringLength(15, ErrorMessage = "Customer Name cannot exceed more than 15 characters")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public int membershipTypeId { get; set; }

        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [MinAgeforMembership]  //Custom validation Attribute
        public Nullable<System.DateTime> BirthDate { get; set; }

        public virtual MembershipTypeDto MembershipType { get; set; }
    }
}