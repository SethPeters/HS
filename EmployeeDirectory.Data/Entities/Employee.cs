using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data.Entities
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeNo { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }

        [DataMember]
        [MaxLength(100)]
        public String Title { get; set; }

        [DataMember]
        public string OfficeId { get; set; }

        [DataMember]
        [ForeignKey("OfficeId")]
        public Office Office { get; set; }

        [DataMember]
        public int VacationHours { get; set; }

        [DataMember]
        [Required]
        [MaxLength(256)]
        public string ChangeUser { get; set; }

        [DataMember]
        [Required]
        public DateTime ChangeDate { get; set; }
    }
}