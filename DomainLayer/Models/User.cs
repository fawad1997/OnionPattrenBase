using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class User
    {
        [Key]
        public long userId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmailId { get; set; }
        public string userAddress { get; set; }
        public DateTime userCreationTime { get; set; }
        public DateTime userUpdationTime { get; set; }
    }
}
