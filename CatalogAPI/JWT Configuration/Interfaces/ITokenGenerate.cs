using CatalogAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.JWT_Configuration.Interfaces
{
    public interface ITokenGenerate
    {
        UserToken UserTokenGenerate(UserLoginDTO user);
    }
}
