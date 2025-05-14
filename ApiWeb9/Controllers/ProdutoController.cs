using ApiWeb9.Data;
using ApiWeb9.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<ProdutosModel>> BuscarProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProdutosModel> BuscarProdutosPorId(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
            {
                return NotFound("Registro não localizado!");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutosModel> CriarProduto(ProdutosModel produtoModel)
        {
            if(produtoModel == null)
            {
                return BadRequest("Ocorreu um erro na Solicidação!");
            }

            _context.Produtos.Add(produtoModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarProdutosPorId), new { id = produtoModel.Id }, produtoModel);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ProdutosModel> EditarProduto(ProdutosModel produtoModel, int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
            {
                return NotFound("Registro não localizado!");
            }

            produto.Nome = produtoModel.Nome;
            produto.Descricao = produtoModel.Descricao;
            produto.Marca = produtoModel.Marca;
            produto.QuantidadeEstoque = produtoModel.QuantidadeEstoque;
            produto.CodigoDeBarras = produtoModel.CodigoDeBarras;

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ProdutosModel> DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Registro não localizado!");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

