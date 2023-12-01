using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class OutputInfo
    {
        public string Id { get; set; }
        public string IdObject { get; set; }
        public string IdOutInfo { get; set; }
        public int IdCustomer { get; set; }
        public int? Count { get; set; }
        public string Status { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Object IdObjectNavigation { get; set; }
        public virtual Output IdOutInfoNavigation { get; set; }
    }
}
