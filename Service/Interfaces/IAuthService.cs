using System;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Guid id, IList<string> roles);
    }
}