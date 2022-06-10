﻿using aplicativozinho.Shared.features.cep.models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace aplicativozinho.Server.features.cep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        [HttpGet("{cep}")]
        public Endereco RetornarEndereco(string cep)
        {
            var endereco = new Endereco();

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://viacep.com.br/ws/");

                try
                {
                    var json = http.GetStringAsync($"{cep}/json");
                    endereco = JsonConvert.DeserializeObject<Endereco>(json.Result);
                }
                catch
                {
                    endereco.erro = true;
                }
            }

            return endereco;
        }
    }
}
