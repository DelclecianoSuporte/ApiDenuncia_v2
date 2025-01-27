using ApiDenuncia.Interfaces;
using ApiDenuncia.Models;
using ApiDenuncia.ViewModel;
using AutoMapper;
using Camada.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Humanizer.In;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace ApiDenuncia.Controllers
{
    [Route("api/denuncias")]
    public class DenunciaController : MainController
    {
        private readonly IDenunciaService _denunciaSevice;
        private readonly IDenunciaRepository _denunciaRepository;
        private readonly IMapper _mapper;
        private readonly Contexto _contexto;

        public DenunciaController(IDenunciaService denunciaService, IDenunciaRepository denunciaRepository, IMapper mapper, Contexto contexto, INotificador notificador) : base(notificador)
        {
            _denunciaSevice = denunciaService;
            _denunciaRepository = denunciaRepository;
            _mapper = mapper;
            _contexto = contexto;
        }

        [HttpPost]
        public async Task<ActionResult<DenunciaViewModel>> CadastrarDenuncia(DenunciaViewModel denunciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            long numeroProtocolo = GeraProtocolo();
            
            DateTime dataAtual = DateTime.Now;

            denunciaViewModel.Numero_Protocolo = numeroProtocolo;
            denunciaViewModel.Data_Protocolo = dataAtual;

            var denuncia = _mapper.Map<Denuncia>(denunciaViewModel);
            await _denunciaSevice.Adicionar(denuncia);

            denunciaViewModel.Status = "Aberto";
            denunciaViewModel.Resposta = "";

            var responseViewModel = new DenunciaViewModel
            {
                Id = denuncia.Id,
                Mensagem = denunciaViewModel.Mensagem
            };

            return CustomResponse(new { Id = denunciaViewModel.Id, Numero_Protocolo = numeroProtocolo, Data_Protocolo = dataAtual, Mensagem = denunciaViewModel.Mensagem });
        }

        private long GeraProtocolo()
        {
            DateTime dataAtual = DateTime.Now;

            string dia = dataAtual.Day.ToString().PadLeft(2, '0');
            string mes = dataAtual.Month.ToString().PadLeft(2, '0');
            string hora = dataAtual.Hour.ToString().PadLeft(2, '0');
            string minutos = dataAtual.Minute.ToString().PadLeft(2, '0');
            string segundos = dataAtual.Second.ToString().PadLeft(2, '0');

            Random random = new Random();
            long numeroAleatorio = random.Next(10000);
            long numeroConvertido = (numeroAleatorio * 10000000000) + (Convert.ToInt64(dia + mes + hora + minutos + segundos));

            return numeroConvertido;
        }


        [HttpGet("{numeroProtocolo:long}")]
        public async Task<ActionResult<List<DenunciaViewModel>>> ObterMensagensPorProtocolo(long numeroProtocolo)
        {
            var mensagens_denuncia = await _denunciaRepository.ObterMensagensPorProtocolo(numeroProtocolo);

            if (mensagens_denuncia == null || mensagens_denuncia.Count == 0)
            {
                return NotFound("Numero de Protocolo não foi encontrado");
            }

            return CustomResponse(mensagens_denuncia);
        }

        [HttpGet("protocolos")]
        public async Task<ActionResult<IEnumerable<DenunciaViewModel>>> MostrarTodosProtocolos()
        {
            var protocolos = (_mapper.Map<IEnumerable<DenunciaViewModel>>(await _denunciaSevice.ObterTodosProtocolos()));
            return CustomResponse(protocolos);
        }

        [HttpGet("protocolos/abertos")]
        public async Task<ActionResult<IEnumerable<DenunciaViewModel>>> MostrarProtocolosAbertos()
        {
            var protocolosAbertos = await _denunciaRepository.ObterProtocolosAbertos();

            if (protocolosAbertos == null || !protocolosAbertos.Any())
            {
                return NotFound("Nenhum protocolo aberto encontrado.");
            }

            return CustomResponse(protocolosAbertos);
        }

        [HttpPost("{numeroProtocolo:long}")]
        public async Task<IActionResult> AdicionarRespostaComite(long numeroProtocolo, [FromBody] RespostaViewModel respostaViewModel)
        {
            var denunciaExistente = await _contexto.Denuncias.SingleOrDefaultAsync(d => d.Numero_Protocolo == numeroProtocolo);

            if (denunciaExistente == null)
            {
                return NotFound("Número de protocolo não encontrado.");
            }

            if (!string.IsNullOrEmpty(denunciaExistente.Resposta))
            {
                return BadRequest("Já existe uma resposta para este número de protocolo.");
            }

            denunciaExistente.Resposta = respostaViewModel.Resposta;

            if (denunciaExistente.Status == "Aberto")
            {
                denunciaExistente.Status = "Finalizado";
            }

            denunciaExistente.DataHora_Resposta = DateTime.Now;

            _contexto.SaveChanges();

            return CustomResponse("Resposta adicionada no banco com sucesso");
        }

        public class RespostaViewModel
        {
            public string Resposta { get; set; }
        }


    }
}


