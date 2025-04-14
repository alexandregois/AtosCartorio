using System;
using System.Collections.Generic;
using System.Linq;
using AtosCartorio.Data;
using AtosCartorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AtosCartorio.Repositories
{
    public class CasamentoRepository : IRepository<CasamentoModel>
    {
        private readonly CartorioContext _context;

        public CasamentoRepository()
        {
            _context = new CartorioContext();
        }

        public List<CasamentoModel> GetAll(bool forceReload = false)
        {
            if (forceReload)
            {
                // Desabilitar o rastreamento para obter dados frescos
                return _context.Casamentos
                    .AsNoTracking()
                    .Include(c => c.Conjuge1)
                    .Include(c => c.Conjuge2)
                    .ToList();
            }
            else
            {
                // Comportamento original
                return _context.Casamentos
                    .Include(c => c.Conjuge1)
                    .Include(c => c.Conjuge2)
                    .ToList();
            }
        }

        public CasamentoModel GetById(int id)
        {
            return _context.Casamentos.Find(id);
        }

        public void Add(CasamentoModel entity)
        {
            _context.Casamentos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CasamentoModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var casamento = _context.Casamentos.Find(id);
            if (casamento != null)
            {
                _context.Casamentos.Remove(casamento);
                _context.SaveChanges();
            }
        }
    }
}
