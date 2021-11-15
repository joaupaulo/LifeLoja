using System;
using System.Threading.Tasks;
using LifeLoja.Services;
using Xunit;
using NSubstitute;
using LifeLoja.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using LifeLoja.Entidades;
using System.Collections.Generic;

namespace LojaLife.Tests
{
    public class LifeTestes
    {
        private readonly ProdutosService _produtosservice;
        private readonly ProdutosAPI _produtosAPI;

        public LifeTestes()
        {
            _produtosservice = Substitute.For<ProdutosService>();
            _produtosAPI = new ProdutosAPI(_produtosservice);
        }

        List<Produtos> joao = null;

        [Fact]
        public async Task Get_Ok()
        {
              var resultado =  await _produtosAPI.GetProducts();


            List<Produtos> result = null;

          

            resultado.Should().Be(result);


         }
    }
}
