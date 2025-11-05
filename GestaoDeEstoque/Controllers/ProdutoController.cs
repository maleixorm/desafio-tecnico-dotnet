using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeEstoque.Context;
using GestaoDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestaoDeEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public ProdutoController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            if (produto.Nome == null) return BadRequest(new { Erro = "O nome do produto não pode estar vazio!" });
            _context.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(id);
            if (produtoBanco == null) return NotFound();
            if (produto.Nome == null) return BadRequest(new { Erro = "O nome do produto não pode estar vazio!" });

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Descricao = produto.Descricao;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Quantidade = produto.Quantidade;

            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var produtoBanco = _context.Produtos.Find(id);
            if (produtoBanco == null) return NotFound();
            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}