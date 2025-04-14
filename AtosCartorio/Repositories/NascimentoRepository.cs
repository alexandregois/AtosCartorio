using System;
using System.Collections.Generic;
using System.Linq;
using AtosCartorio.Data;
using AtosCartorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AtosCartorio.Repositories
{
    public class NascimentoRepository : IRepository<NascimentoModel>
    {
        private readonly CartorioContext _context;

        public NascimentoRepository()
        {
            _context = new CartorioContext();
        }

        public List<NascimentoModel> GetAll(bool forceReload = false)
        {
            if (forceReload)
            {
                return _context.Nascimentos
                    .AsNoTracking()                    
                    .ToList();
            }
            else
            {
                return _context.Nascimentos                    
                    .ToList();
            }
        }

        public NascimentoModel GetById(int id)
        {
            return _context.Nascimentos.Find(id);
        }

        public void Add(NascimentoModel entity)
        {
            _context.Nascimentos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(NascimentoModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var nascimento = _context.Nascimentos.Find(id);
            if (nascimento != null)
            {
                _context.Nascimentos.Remove(nascimento);
                _context.SaveChanges();
            }
        }
    }
}
