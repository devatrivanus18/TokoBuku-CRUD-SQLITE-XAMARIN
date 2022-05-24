using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TokoBuku.Model;

namespace TokoBuku.Service
{
    public interface ILoginService
    {
        void Login(User user);
        
    }
}
