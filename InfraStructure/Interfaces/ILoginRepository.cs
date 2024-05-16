using InfraStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface ILoginRepository
    {
        string GenerateOTP();
        bool SendOTP(string email, string otp);
        OwnerVm Login(LoginVm model);
    }
}
