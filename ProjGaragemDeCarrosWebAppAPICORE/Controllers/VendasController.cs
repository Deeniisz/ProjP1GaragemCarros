using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjGaragemDeCarrosWebAppAPICORE.Data;
using ProjGaragemDeCarrosWebAppAPICORE.Models;

namespace ProjGaragemDeCarrosWebAppAPICORE.Controllers
{
    public class VendasController : Controller
    {
        private readonly ProjGaragemDeCarrosWebAppAPICOREContext _context;

        public VendasController(ProjGaragemDeCarrosWebAppAPICOREContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Venda.Include(c => c.Carro).ToListAsync());
            return View(await _context.Venda.Include(c => c.Vendedor).ToListAsync());
            return View(await _context.Venda.Include(c => c.Cliente).ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            var v = new Venda();

            var carros = _context.Carro.ToList();

            v.Carros = new List<SelectListItem>();

            foreach (var car in carros)
            {
                v.Carros.Add(new SelectListItem { Text = car.Modelo, Value = car.Id.ToString() });
            }

            var vendedores = _context.Vendedor.ToList();

            v.Vendedores = new List<SelectListItem>();

            foreach (var ven in vendedores)
            {
                v.Vendedores.Add(new SelectListItem { Text = ven.Nome, Value = ven.Id.ToString() });
            }


            var clientes = _context.Cliente.ToList();

            v.Clientes = new List<SelectListItem>();

            foreach (var cli in clientes)
            {
                v.Clientes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }




            return View(v);
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v = _context.Venda.Include(c => c.Carro).First(v => v.Id == id);

            var v1 = _context.Venda.Include(c => c.Vendedor).First(v => v.Id == id);

            var v2 = _context.Venda.Include(c => c.Cliente).First(v => v.Id == id);

            var carros = _context.Carro.ToList();

            v.Carros = new List<SelectListItem>();

            var vendedores = _context.Vendedor.ToList();

            v1.Vendedores = new List<SelectListItem>();

            var clientes = _context.Cliente.ToList();

            v2.Clientes = new List<SelectListItem>();

            foreach (var car in carros)
            {
                v.Carros.Add(new SelectListItem { Text = car.Modelo, Value = car.Id.ToString() });
            }

            

            foreach (var ven in vendedores)
            {
                v1.Vendedores.Add(new SelectListItem { Text = ven.Nome, Value = ven.Id.ToString() });
            }


           

            foreach (var cli in clientes)
            {
                v2.Clientes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }

            if (v == null)
            {
                return NotFound();
            }
            return View(v);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }
    }
}
