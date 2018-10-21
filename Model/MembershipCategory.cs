using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MembershipCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AllowedDuration { get; set; }
        public string AllowedQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal penalty { get; set; }
        [ForeignKey("Members")]
        public int MemberId { get; set; }
        public virtual Member Members { get; set; }
    }
}
