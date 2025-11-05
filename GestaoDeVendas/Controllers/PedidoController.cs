using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeVendas.Context;
using GestaoDeVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestaoDeVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public PedidoController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Criar(Pedido pedido)
        {
            if (pedido.Itens == null) return BadRequest(new { Erro = "Os itens do pedido não pode estar vazio!" });
            _context.Add(pedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pedido pedido)
        {
            var pedidoBanco = _context.Pedidos.Find(id);
            if (pedidoBanco == null) return NotFound();
            if (pedido.Itens == null) return BadRequest(new { Erro = "Os itens do pedido não pode estar vazio!" });

            pedidoBanco.Itens = pedido.Itens;
            pedidoBanco.Quantidade = pedido.Quantidade;
            pedidoBanco.Status = pedido.Status;

            _context.Pedidos.Update(pedidoBanco);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var pedidoBanco = _context.Pedidos.Find(id);
            if (pedidoBanco == null) return NotFound();
            _context.Pedidos.Remove(pedidoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}