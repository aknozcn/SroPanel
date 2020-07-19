using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Models.ShardDb
{
    public class _Char
    {
        [Key]
        public int CharID { get; set; }
        public int RefObjID { get; set; }
        public string CharName16 { get; set; }
        public string NickName16 { get; set; }
    }
}
