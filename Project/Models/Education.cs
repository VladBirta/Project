using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Education
    {
        public Guid ID { get; set; }

        public string EducationTitle { get; set; }

        public string EducationContent { get; set; }

        public DateTime PublicationDate { get; set; }

       
    }
}
