using PositionMgmt.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Infrastructure.Repository
{
    public class BaseRepository
    {
        public PositionMgmtDBContext _context { get; set; }

        public BaseRepository(PositionMgmtDBContext context)
        {
            _context = context;
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
