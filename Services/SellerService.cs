using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellerSystem.Models;

namespace SellerSystem.Services
{
    public class SellerService
    {
        private readonly ApplicationDbContext _context;

        public SellerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}