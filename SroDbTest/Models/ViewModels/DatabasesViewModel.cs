using SroDbTest.Models.AccountDb;
using SroDbTest.Models.DTOs;
using SroDbTest.Models.PanelDb;
using SroDbTest.Models.ShardDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Models.ViesModels
{
    public class DatabasesViewModel
    {
        //buradan çekiyom senin dediğin gibi ama şöyle bir sıkıntısı var

        public TB_User tbUser { get; set; }
        public LoginDTO loginDTO { get; set; }

        public RegisterDTO registerDTO { get; set; }

        public List<TB_User> acctbUser { get; set; }
        public List<_Char> shardChar { get; set; }
        public List<_news> panelNews { get; set; }
        

    }
}
