using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data.Entities
{
    [DataContract]
    public class Office
    {
        [DataMember]
        [Required]
        [MaxLength(5)]
        [Key]
        public string OfficeId { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public string OfficeName { get; set; }

        [DataMember]
        [MaxLength(100)]
        public string City { get; set; }

        [DataMember]
        [MaxLength(2)]
        public string State { get; set; }

        [DataMember]
        [Required]
        [MaxLength(256)]
        public string ChangeUser { get; set; }

        [DataMember]
        [Required]
        public DateTime ChangeDate { get; set; }
    }
}