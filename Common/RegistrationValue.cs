using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RegistrationValue
    {
        public int Id { get; set; }
        public int SubItemId { get; set; }
        public SubItemEntity SubItemEntity { get; set; }
        public string Value { get; set; }
        public int RegistrationId { get; set; }
    }
}
