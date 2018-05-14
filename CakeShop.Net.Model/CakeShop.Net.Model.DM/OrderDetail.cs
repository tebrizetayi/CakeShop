using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Net.Model.DM
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderDetail_OrderId { get; set; }
        public Guid OrderDetail_PieId { get; set; }
        public int OrderDetailAmount { get; set; }
        public decimal OrderDetailPrice { get; set; }
        public System.DateTime OrderDetailModifiedDate { get; set; }
        public System.DateTime OrderDetailCreatedDate { get; set; }
        public bool OrderDetailStatus { get; set; }
        public int OrderDetailCreatedBy_UserId { get; set; }
        public int OrderDetailModifiedBy_UserId { get; set; }
    }
}
