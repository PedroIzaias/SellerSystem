using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellerSystem.Models;
using Microsoft.EntityFrameworkCore;
using SellerSystem.Services.Exceptions;

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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try{
                _context.Update(obj);
                _context.SaveChanges();
            } 
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}