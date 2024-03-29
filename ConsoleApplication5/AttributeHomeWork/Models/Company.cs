﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeHomeWork.Models
{
    public class Company : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Corporation { get; set; }
        public string CEO { get; set; }
        public DateTime? CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int LastModifierId { get; set; }
        public DateTime? LastModifyTime { get; set; }

    }
}
