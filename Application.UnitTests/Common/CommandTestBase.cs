using Moq;
using projektApi.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ProjektApiDbContext _context;
        protected readonly Mock<ProjektApiDbContext> _contextMock; //Mock - symulacja samego DbContextu
        public CommandTestBase()
        {
            _contextMock = ProjektApiDbContextFactory.Create();
            _context = _contextMock.Object;
        }
        public void Dispose()
        {
            ProjektApiDbContextFactory.Destroy(_context);
        }
    }
}
