using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvFlixApp.Application.Contracts
{
    public interface IJwtTokenService
    {
        public string GenerateToken();
    }
}
