using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Net.Model.DM
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string OrderFirstName { get; set; }
        public string OrderLastName { get; set; }
        public string OrderAddressLine1 { get; set; }
        public string OrderAddressLine2 { get; set; }
        public string OrderZipCode { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderCountry { get; set; }
        public string OrderPhoneNumber { get; set; }
        public string OrderEmail { get; set; }
        public decimal OrderTotal { get; set; }
        public System.DateTime OrderModifiedDate { get; set; }
        public System.DateTime OrderCreatedDate { get; set; }
        public bool OrderStatus { get; set; }
        public int OrderCreatedBy_UserId { get; set; }
        public int OrderModifiedBy_UserId { get; set; }
    }
}
