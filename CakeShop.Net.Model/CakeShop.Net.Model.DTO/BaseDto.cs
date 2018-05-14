using System;

namespace CakeShop.Net.Model.DTO
{
    /// <summary>
    /// Base class for every Data Transfer object.
    /// </summary>
    public class BaseDto
    {
        public Guid Id
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
    }
}
