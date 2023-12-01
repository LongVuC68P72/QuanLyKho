using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class Object
    {
        public Object()
        {
            InputInfos = new HashSet<InputInfo>();
            OutputInfos = new HashSet<OutputInfo>();
        }

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public int IdUnit { get; set; }
        public int IdSuplier { get; set; }
        public string QRCode { get; set; }
        public string BarCode { get; set; }

        public virtual Suplier IdSuplierNavigation { get; set; }
        public virtual Unit IdUnitNavigation { get; set; }
        public virtual ICollection<InputInfo> InputInfos { get; set; }
        public virtual ICollection<OutputInfo> OutputInfos { get; set; }
    }
}
