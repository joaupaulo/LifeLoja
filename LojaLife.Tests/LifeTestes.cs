using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LifeLoja.Controllers;
using LifeLoja.Entidades;
using LifeLoja.GcpServices;
using LifeLoja.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ProdutoFakeData.ProdutosViewFake.ProdutosData;
using ProdutosFakeData.ProdutosViewFake;
using Xunit;

namespace LojaLife.Tests
{
    public class LifeTestes
    {
        private readonly IProdutosService _produtosservice;
        private readonly ProdutosAPI _produtosAPI;
        private readonly ProdutosDataFake _produtosDataFake;
        private readonly IPubSubRepositorio _pubSubRepositorio;
        private readonly List<ProdutosDataFake> _ListProdutosDataFake;
        private readonly List<Produtos> prod;

        public LifeTestes()
        {
            _produtosservice = Substitute.For<IProdutosService>();
            _pubSubRepositorio = Substitute.For<IPubSubRepositorio>();
            //_produtosAPI = new ProdutosAPI(_produtosservice, _pubSubRepositorio);
            _produtosDataFake = new ProdutosViewFaker().Generate();
            _ListProdutosDataFake = new ProdutosViewFaker().Generate(50);

           

            prod.Add(new Produtos("6192fcf6172b8d4f097c101a", "Camisa Oakley", "Camisas", "Verde Azul", 29, 30));
            prod.Add(new Produtos("61930077d3f63948cf05ad75", "Camisa Hurley", "Camisas", "Preto e Branco", 70, 30));
            prod.Add(new Produtos("61930099cf9694b84786b192", "Regata Nike", "Regatas", "Vermelho Listrada", 100, 20));
            prod.Add(new Produtos("619300c1a22a2a591c21bcb7", "Blusăo Champgion", "Blusăo", "Preto", 200, 20));


        }



     


    }
}
