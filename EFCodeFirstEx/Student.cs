using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstEx
{
    //db table will be Admin.StudentMaster
    [Table("StudentMaster", Schema = "Admin")]
    public class Student
    {
        [Column(Order = 0)]
        [Key] // key can be assing to multiple coumns (to create composite keys)
        public int StudentId { get; set; }

        [Column("Name", Order = 1)]
        [Required] //to creare a not null coloumn
        [MaxLength(50)] // maximum string length
        public string StudentName { get; set; }

        [Column("DoB", TypeName = "DateTime2", Order = 5)]
        public DateTime? DateOfBirth { get; set; }

        [Column(Order = 3)]
        public byte[] Photo { get; set; }

        [Column(Order = 2)]
        [ConcurrencyCheck] // column will be used in optimistic comcurrency check
        public decimal Height { get; set; }

        [Column(Order = 4)]
        public float Weight { get; set; }

        [NotMapped] // no column will create for the Age
        public int Age { get; set; }

        [Timestamp] //EF uses this column in concurency check on the update statement in the database
        public byte[] RowVersion { get; set; }

        public Grade Grade { get; set; }

        // EF also does not create a column for a property which does not have either getters or setters.

        //foreign key mapping
        [ForeignKey("StandardRefId")] // this will create column name StandardRefId
        public Standard Standard { get; set; }

        // create index on registration number column
        [Index("INDEX_REGNUM", IsClustered = true, IsUnique = true)] 
        public int RegistrationNumber { get; set; }


        public virtual StudentAddress Address { get; set; }
    }

    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }

    }

    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
}
