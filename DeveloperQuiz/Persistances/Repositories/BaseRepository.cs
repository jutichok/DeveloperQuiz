using System;
using DeveloperQuiz.Persistances.Contexts;

namespace DeveloperQuiz.Persistances.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MemoryDBContext _context;

        public BaseRepository(MemoryDBContext context)
        {
            _context = context;
        }
    }
}
