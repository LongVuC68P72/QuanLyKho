using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class InputInfo
    {
        public string Id { get; set; }
        public string IdObject { get; set; }
        public string IdInput { get; set; }
        public int? Count { get; set; }
        public double? InputPirce { get; set; }
        public double? OutputPrice { get; set; }

        public virtual Input IdInputNavigation { get; set; }
        public virtual Object IdObjectNavigation { get; set; }
    }
}
