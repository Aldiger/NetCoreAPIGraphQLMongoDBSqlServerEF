using System;
using System.Collections.Generic;
using System.Text;

namespace NortB.Data.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
