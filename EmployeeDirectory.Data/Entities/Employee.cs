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
    public partial class Employee
    {
        public Employee()
        {
            ExtraInfo = new List<EmployeeExtra>();
        }

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
        [DisplayName("Office")]
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

        public virtual ICollection<EmployeeExtra> ExtraInfo { get; set; }
    }

    [DataContract]
    public class EmployeeExtra
    {
        [DataMember]
        [Required]
        [Key, Column(Order = 1)]
        [DisplayName("Employee Number")]
        public int EmployeeNo { get; set; }

        [DataMember]
        [Required]
        [Key, Column(Order = 2)]
        [DisplayName("Extra Detail Type")]
        public string ExtraDetailType { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Detail")]
        [MaxLength(50)]
        public string ExtraDetailInfo { get; set; }

        public virtual Employee Employee { get; set; }
    }
}