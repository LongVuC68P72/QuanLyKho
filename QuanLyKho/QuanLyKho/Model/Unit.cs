using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class Unit
    {
        public Unit()
        {
            Objects = new HashSet<Object>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
