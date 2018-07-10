using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Infra.Cross.AspNetMvc.Attributes;
using PGLaw.Presentation.Web.Controllers.Base;
using System;
using System.Linq;

namespace Web.Controllers
{
    [Authorize(Policy = "AcessoUrl")]
    [Route("processos")]
    public class ProcessosController : BaseController
    {
        private readonly IProcessosAppServices processosAppServices;
        private readonly IPessoasAppServices pessoasAppServices;

        public ProcessosController(IProcessosAppServices processosAppServices, IPessoasAppServices pessoasAppServices)
        {
            this.processosAppServices = processosAppServices;
            this.pessoasAppServices = pessoasAppServices;
        }

        [HttpGet("")]
        public ActionResult Pesquisar()
        {
            return View();
        }

        // GET: Processos
        [AjaxOnly]
        [HttpGet("buscar")]
        public ActionResult BuscarProcessos(string pesquisa)
        {
            var listaProcessos = processosAppServices.BuscarProcessos(UsuarioId, pesquisa);
            return PartialView("_ListaProcessos", listaProcessos);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("cadastro")]
        public ActionResult Create()
        {
            return RedirectToAction("PreCreate");
        }

        [HttpGet("cadastro/pre")]
        public ActionResult PreCreate()
        {
            MontarViewBagsPreCreste();
            return View();
        }

        [HttpPost("cadastro/pos")]
        public ActionResult PosCreate([FromForm]PreCadastroProcessoVM preCadastro)
        {
            if (!ModelState.IsValid)
            {
                MontarViewBagsPreCreste();   
                return View("PreCreate", preCadastro);
            }

            var processoModel = new PosCadastroProcessoVM(preCadastro);

            MontarViewBagsPosCreate(processoModel.ClienteId);

            return View(processoModel);
        }

        [HttpPost("cadastro")]
        public ActionResult Create(PosCadastroProcessoVM model)
        {
            if (!ModelState.IsValid)
            {
                MontarViewBagsPosCreate(model.ClienteId);
                return View("PosCreate", model);
            }

            processosAppServices.CadastrarProcesso(model);

            return RedirectToAction("Index");
        }

        [HttpGet("{id:guid}")]
        public ActionResult Details(Guid id)
        {
            var model = processosAppServices.ObterProcesso(UsuarioId, id);
            return View(model);
        }

        #region metodos ajax

        //[HttpGet("processos/obter-orgaos/{id:int}")]
        [AjaxOnly]
        [HttpGet("obter-orgaos")]
        public IActionResult PreencherOrgao(int id)
        {
            return Ok(new SelectList(processosAppServices.ObterNaturezas(id), "Id", "Descricao"));
        }

        [AjaxOnly]
        [HttpGet("obter-tipos-acao")]
        public IActionResult PreencherTipoAcao(int id)
        {
            return Ok(new SelectList(processosAppServices.ObterTiposAcoes(id), "Id", "Descricao"));
        }

        [AjaxOnly]
        [HttpGet("obter-cidades")]
        public IActionResult PreencherCidade(int id)
        {
            return Ok(new SelectList(processosAppServices.ObterCidades(id), "Id", "Nome"));
        }


        [AjaxOnly]
        [HttpGet("obter-foruns")]
        public IActionResult PreencherForum(int id)
        {
            return Ok(new SelectList(processosAppServices.ObterForuns(id), "Id", "Nome"));
        }

        [AjaxOnly]
        [HttpGet("obter-areas-ofensoras")]
        public IActionResult PreencherAreaOfensora(Guid id, Guid ClienteId)
        {
            return Ok(new SelectList(processosAppServices.ObterAreasOfensorasAtivas(ClienteId, id), "Id", "Descricao"));
        }

        [AjaxOnly]
        [HttpGet("obter-tipos-pedidos")]
        public IActionResult PreencherTipoPedido(int id)
        {
            return Ok(new SelectList(processosAppServices.ObterTiposPedidosAtivos(id), "Id", "Descricao"));
        }

        [HttpPost]
        [AjaxOnly]
        public string ValidaCNJ(string NumeroProcesso)
        {

            /*
                Função numeroCNJ, para validar Numeração Única de Processos estabelecida na Res. 65 do Conselho Nacional de Justiça, 
                que determina a adoção do seguinte formato para números de processos:            
                NNNNNNN-DD.AAAA.JTR.OOOO, onde
                NNNNNNN => Corresponde ao número sequencial do processo no ano do ajuizamento
                DD => Corresponde aos dígitos de verificação
                AAAA => Corresponde ao ano de ajuizamento da ação/processo
                JTR => Corresponde aos números que identificam o Ramo e a Região da Justiça
                OOOO => Corresponde ao número que identifica o juízo a que distribuída a ação
                O cálculo utiliza o algoritmo do Módulo 97 Base 10, conforme especificação da Norma ISO 7064:2003
                @param sNumProcesso é uma string com o número a ser validado

                Função retorna verdadeiro em caso de sucesso e falso quando o teste falha
            */


                //Remove, se houver, os caracteres não numéricos
                // da entrada do número do processo
                string num = numeroLimpo(NumeroProcesso, 20);

                //extrai o dígito verificador do número limpo
                string numerosemdigito = num.Substring(0, 7) + num.Substring(9);             //$numerosemdigito=substr_replace($num,'',7,2);

                //Prepara o número para o cálculo do dígito,
                //colocando zeros no fim do número sem o dígito
                string numparacalculo = numerosemdigito + "00";

                //Prepara o número para conferência do dígito
                //Pega dígito original
                string digitooriginal = num.Substring(7, 2);
                //colocando o dígito informado no fim do número s/ dígito
                string numparaconferir = numerosemdigito + digitooriginal;

                //divide o $numeroparacalculo para reduzir complexidade do cálculo
                string nnnnnnn = numparacalculo.Substring(0, 7);
                string ajtr = numparacalculo.Substring(7, 7);
                string oooo00 = numparacalculo.Substring(14, 6);

                /*Fórmula CNJ primeira etapa
                * R1=(NNNNNNN mod 97)
                */
                string r1;
                if (Math.Round(System.Convert.ToDecimal(nnnnnnn) % 97, 2) >= 50)
                    r1 = Math.Round(System.Convert.ToDecimal(nnnnnnn) % 97, 2).ToString();
                else
                    r1 = Math.Round(System.Convert.ToDecimal(nnnnnnn) % 97, 2, MidpointRounding.ToEven).ToString();

                //garante que $r1 tenha dois dígitos, preenchendo com zero à esquerda, se necessário
                if (r1.Length > 1)
                    r1 = numeroLimpo(r1.Substring(0, 2), 2);
                else
                    r1 = numeroLimpo(r1, 2);

                /*Fórmula CNJ segunda etapa
                * R2=((R1 concatenado com AAAAJTR) mod 97)
                */
                //concatena $r1 com AAAAJTR
                string r2 = r1 + ajtr;
                if (Math.Round(System.Convert.ToDecimal(r2) % 97, 2) >= 50)
                    r2 = Math.Round(System.Convert.ToDecimal(r2) % 97, 2).ToString();
                else
                    r2 = Math.Round(System.Convert.ToDecimal(r2) % 97, 2, MidpointRounding.ToEven).ToString();
                //garante que $r2 tenha dois dígitos, preenchendo com zero à esquerda, se necessário
                if (r2.Length > 1)
                    r2 = numeroLimpo(r2.Substring(0, 2), 2);
                else
                    r2 = numeroLimpo(r2, 2);

                /*Fórmula CNJ terceira etapa
                * R3=((R2 concatenado com OOOO00) mod 97)
                */
                //concatena $r2 com OOOO00
                string r3 = r2 + oooo00;
                if (Math.Round(System.Convert.ToDecimal(r3) % 97, 2) >= 50)
                    r3 = Math.Round(System.Convert.ToDecimal(r3) % 97, 2).ToString();
                else
                    r3 = Math.Round(System.Convert.ToDecimal(r3) % 97, 2, MidpointRounding.ToEven).ToString();
                //garante que $r3 tenha dois dígitos, preenchendo com zero à esquerda, se necessário
                if (r3.Length > 1)
                    r3 = numeroLimpo(r3.Substring(0, 2), 2);
                else
                    r3 = numeroLimpo(r3, 2);

                /*Fórmula CNJ quarta etapa
                * DD = 98 - (R3 mod 97)
                */
                string d1d0 = (98 - (System.Convert.ToDecimal(r3) % 97)).ToString();
                if (d1d0.Length >= 2)
                    d1d0 = numeroLimpo(d1d0.Substring(0, 2), 2);
                else
                    d1d0 = numeroLimpo(d1d0.Substring(0, d1d0.Length), 2);

                //Compara dígito calculado com informado
                string resultado = digitooriginal == d1d0 ? "true" : "false";
                return resultado;

        }

        private string numeroLimpo(string snumero, int comprimento)
        {
            /*  Função numeroLimpo, para remover caracteres não numéricos de uma string que deva ser tratada como um número
                preenchendo com zeros à esquerda o número resultante se o seu comprimento é menor do que o parâmetro $comprimento

                @param $snumero => A string que deve ser limpa
                @param $comprimento => O tamanho desejado para a string
                @Author Maurício Schmidt Bastos
            */

            //Remove, se houver, os caracteres não numéricos de $snumero
            string numerolimpo = snumero.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("*", "").Replace("+", "").Replace("_", "");   //string numerolimpo = snumero.Replace("/\D+/","");


            //Testta o tamanho e preenche com zeros à esquerda, se necessário

            //para que o número tenha o comprimento desejado

            if (numerolimpo.Length < comprimento)
            {
                //se o número tiver comprimento menor, preenche com zeros à esquerda
                numerolimpo = numerolimpo.PadLeft(comprimento, '0');
            }
            return numerolimpo;

        }

        #endregion

        #region metodos privados

        public void MontarViewBagsPosCreate(Guid clienteId)
        {
            ViewBag.TipoRelacao = new SelectList(processosAppServices.ObterTiposRelacoes(), "Id", "Descricao");
            ViewBag.Cliente = new SelectList(pessoasAppServices.ObterTodosClientes(), "Id", "Nome");
            ViewBag.Justica = new SelectList(processosAppServices.ObterJusticas(), "Id", "Descricao");
            ViewBag.Estado = new SelectList(processosAppServices.ObterEstados(), "Id", "Nome");
            ViewBag.FamiliaOfensora = new SelectList(processosAppServices.ObterFamiliasOfensorasAtivas(clienteId), "Id", "Descricao");
            ViewBag.MotivoAcionamento = new SelectList(processosAppServices.ObterMotivosAcionamentosAtivos(clienteId), "Id", "Descricao");
            ViewBag.CausaReal = new SelectList(processosAppServices.ObterCausasReaisAtivas(clienteId), "Id", "Descricao");
            ViewBag.Risco = new SelectList(processosAppServices.ObterRiscos(), "Id", "Descricao");
        }

        public void MontarViewBagsPreCreste()
        {
            ViewBag.Cliente = new SelectList(pessoasAppServices.ObterTodosClientes()?.Select(x => x.Pessoa), "Id", "Nome");
        }

        #endregion
    }
}