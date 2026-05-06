using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public interface INavigationAware
    {
        void SetNavigation(NavigationContext context);
    }
    public interface INavigationAwareLoaded
    {
        void OnNavigatedTo();
    }
}
