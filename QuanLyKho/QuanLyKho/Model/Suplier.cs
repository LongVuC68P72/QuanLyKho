﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKho.Model
{
    public partial class Suplier
    {
        public Suplier()
        {
            Objects = new HashSet<Object>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MoreInfo { get; set; }
        public DateTime? ContractDate { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
