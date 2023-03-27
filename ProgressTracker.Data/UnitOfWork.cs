using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgressTracker.Data.Repositories;
using ProgressTracker.Domain.Interfaces;

namespace ProgressTracker.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private IItemRepository _items;
        private IMetricRepository _metrics;

        public IItemRepository Items
        {
            get
            {
                return _items ??= new ItemRepository(_context);
            }
        }

        public IMetricRepository Metrics    
        {
            get
            {
                return _metrics ??= new MetricRepository(_context);
            }
        }

        public UnitOfWork(ApplicationDbContext dbContext, IItemRepository itemRepository, IMetricRepository metricRepository)
        {
            _context = dbContext;
            _items = itemRepository;
            _metrics = metricRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
