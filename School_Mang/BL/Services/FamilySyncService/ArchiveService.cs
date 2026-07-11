using School_Mang.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class ArchiveService
    {
        private readonly FamilyDataGenerator _userNameGenerator;
        private readonly SiteUserProvider _siteUserService;
            
        public ArchiveService()
        {
            _userNameGenerator = new FamilyDataGenerator();
            _siteUserService = new SiteUserProvider();
        }
        
    }
}
