using System;
using System.Collections.Generic;
using System.Linq;
using AtosCartorio.Data;
using AtosCartorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AtosCartorio.Repositories
{
    public class ObitoRepository : IRepository<ObitoModel>
    {
        private readonly CartorioContext _context;

        public ObitoRepository()
        {
            _context = new CartorioContext();
        }

        public List<ObitoModel> GetAll(bool forceReload = false)
        {
            if (forceReload)
            {
                // Desabilitar o rastreamento para obter dados frescos
                return _context.Obitos
                    .AsNoTracking()                    
                    .ToList();
            }
            else
            {
                // Comportamento original
                return _context.Obitos                    
                    .ToList();
            }
        }

        public ObitoModel GetById(int id)
        {
            return _context.Obitos.Find(id);
        }

        public void Add(ObitoModel entity)
        {
            _context.Obitos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ObitoModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obito = _context.Obitos.Find(id);
            if (obito != null)
            {
                _context.Obitos.Remove(obito);
                _context.SaveChanges();
            }
        }
    }
}
