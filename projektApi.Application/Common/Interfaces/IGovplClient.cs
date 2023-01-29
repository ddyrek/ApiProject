using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Common.Interfaces
{
    public interface IGovplClient
    {
        //tą metodę zminiamy w zalezności od potrzeb wykonania naszego ExternalAPI
        Task<string> GetMovie(string searchFilter, CancellationToken cancellationToken);
    }
}
