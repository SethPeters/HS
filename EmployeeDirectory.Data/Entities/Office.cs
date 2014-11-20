using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Office ID")]
        public string OfficeId { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        [DisplayName("Office Name")]
        public string OfficeName { get; set; }

        [DataMember]
        [MaxLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [DataMember]
        [MaxLength(2)]
        [DisplayName("State")]
        public string State { get; set; }
    }
}