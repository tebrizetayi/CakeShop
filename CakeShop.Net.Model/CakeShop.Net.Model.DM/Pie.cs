using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CakeShop.Net.Model.DM
{
    [Table("Pie")]
    public class Pie
    {
        [Key]
        public Guid Id { get; set; }
        public string PieName { get; set; }
        public string PieShortDescription { get; set; }
        public string PieLongDescription { get; set; }
        public string PieAllergyInformation { get; set; }
        public decimal PiePrice { get; set; }
        public string PieImageUrl { get; set; }
        public string PieImageThumbnailUrl { get; set; }
        public bool PieIsPieOfTheWeek { get; set; }
        public bool PieInStock { get; set; }
        public int Pie_CategoryId { get; set; }
        public System.DateTime PieModifiedDate { get; set; }
        public System.DateTime PieCreatedDate { get; set; }
        public bool PieStatus { get; set; }
        public int PieCreatedBy_UserId { get; set; }
        public int PieModifiedBy_UserId { get; set; }
    }
}
