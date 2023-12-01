using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class Input
    {
        public Input()
        {
            InputInfos = new HashSet<InputInfo>();
        }

        public string Id { get; set; }
        public DateTime? DateInput { get; set; }

        public virtual ICollection<InputInfo> InputInfos { get; set; }
    }
}
