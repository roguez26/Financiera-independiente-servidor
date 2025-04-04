using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Independiente.Model
{
    public class PersonalData
    {

        public int PersonalDataId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public string BirthDate { get; set; }

        public string RFC { get; set; }

        public string CURP { get; set; }

        public string PhoneNumber { get; set; }

        public string AlternativePhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
