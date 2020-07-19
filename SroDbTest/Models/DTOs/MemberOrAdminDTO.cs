using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Models.DTOs
{
    public class MemberOrAdminDTO
    {
        public string StrUserID { get; set; }
        public byte sec_primary { get; set; }
        public byte sec_content { get; set; }
    }
}
