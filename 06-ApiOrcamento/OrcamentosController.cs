using Microsoft.AspNetCore.Mvc;

namespace OficinaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrcamentosController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarOrcamento([FromBody] OrcamentoRequest request)
        {
            if (request.ClienteId <= 0)
            {
                return BadRequest("clienteId é obrigatório.");
            }

            if (request.VeiculoId <= 0)
            {
                return BadRequest("veiculoId é obrigatório.");
            }

            if (request.Itens == null || request.Itens.Count == 0)
            {
                return BadRequest("O orçamento deve possuir pelo menos 1 item.");
            }

            foreach (var item in request.Itens)
            {
                if (string.IsNullOrWhiteSpace(item.Descricao))
                {
                    return BadRequest("A descrição do item é obrigatória.");
                }

                if (item.Quantidade <= 0)
                {
                    return BadRequest("A quantidade deve ser maior que zero.");
                }

                if (item.ValorUnitario <= 0)
                {
                    return BadRequest("O valor unitário deve ser maior que zero.");
                }
            }

            decimal valorTotal = 0;

            foreach (var item in request.Itens)
            {
                valorTotal += item.Quantidade * item.ValorUnitario;
            }

            var response = new
            {
                mensagem = "Orçamento cadastrado com sucesso.",
                clienteId = request.ClienteId,
                veiculoId = request.VeiculoId,
                valorTotal = valorTotal
            };

            return Ok(response);
        }
    }

    public class OrcamentoRequest
    {
        public int ClienteId { get; set; }

        public int VeiculoId { get; set; }

        public List<OrcamentoItemRequest> Itens { get; set; }
    }

    public class OrcamentoItemRequest
    {
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }
    }
}
