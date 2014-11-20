using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeDirectory.Data.Entities
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Employee Number")]
        public int EmployeeNo { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [DataMember]
        [MaxLength(100)]
        [DisplayName("Title")]
        public String Title { get; set; }

        [DataMember]
        public string OfficeId { get; set; }

        public virtual Office Office { get; set; }

        [DataMember]
        [DisplayName("Vacation Hours")]
        public int VacationHours { get; set; }

        [DisplayName("Name")]
        public string Name
        {
            get { return FirstName + " " + LastName; }
            private set { value = FirstName + " " + LastName; }
        }
    }
}