using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class Output
    {
        public Output()
        {
            OutputInfos = new HashSet<OutputInfo>();
        }

        public string Id { get; set; }
        public DateTime? DateOutput { get; set; }

        public virtual ICollection<OutputInfo> OutputInfos { get; set; }
    }
}
