using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace CakeShop.Net.Model.DM
{
    [Table("ShoppingCartItem")]
    public  class ShoppingCartItem
    {    
        [Key]
        public Guid Id { get; set; }
        public Guid ShoppingCartItem_PieId { get; set; }
        public int ShoppingCartItemAmount { get; set; }
        public Guid ShoppingCartItem_ShoppingCartId { get; set; }
        public System.DateTime ShoppingCartItemModifiedDate { get; set; }
        public System.DateTime ShoppingCartItemCreatedDate { get; set; }
        public bool ShoppingCartItemStatus { get; set; }
        public int ShoppingCartItemCreatedBy_UserId { get; set; }
        public int ShoppingCartItemModifiedBy_UserId { get; set; }
    }
}
