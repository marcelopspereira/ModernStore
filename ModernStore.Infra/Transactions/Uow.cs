using ModernStore.Infra.Contexts;
using System;

namespace ModernStore.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly ModernStoreDataContext _context;
        public Uow(ModernStoreDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            //throw new NotImplementedException();
        }
    }
}
