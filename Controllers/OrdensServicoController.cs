using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrdemTech.Data;
using OrdemTech.Models;

namespace OrdemTech.Controllers
{
    public class OrdensServicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdensServicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdensServico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdensServicos.Include(o => o.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdensServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServicos
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // GET: OrdensServico/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            return View();
        }

        // POST: OrdensServico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoProblema,ValorOrcamento,DataAbertura,Finalizada,ClienteId")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(ordemServico);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Ordem de Serviço criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["MensagemErro"] = "Erro ao tentar registrar a Ordem de Serviço.";
                }
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", ordemServico.ClienteId);
            return View(ordemServico);
        }

        // GET: OrdensServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServicos.FindAsync(id);
            if (ordemServico == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", ordemServico.ClienteId);
            return View(ordemServico);
        }

        // POST: OrdensServico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoProblema,ValorOrcamento,DataAbertura,Finalizada,ClienteId")] OrdemServico ordemServico)
        {
            if (id != ordemServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordemServico);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Ordem de Serviço atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemServicoExists(ordemServico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    TempData["MensagemErro"] = "Erro ao atualizar a Ordem de Serviço.";
                }
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", ordemServico.ClienteId);
            return View(ordemServico);
        }

        // GET: OrdensServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServicos
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // POST: OrdensServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var ordemServico = await _context.OrdensServicos.FindAsync(id);
                if (ordemServico != null)
                {
                    _context.OrdensServicos.Remove(ordemServico);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Ordem de Serviço removida com sucesso!";
                }
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar excluir a Ordem de Serviço.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemServicoExists(int id)
        {
            return _context.OrdensServicos.Any(e => e.Id == id);
        }
    }
}