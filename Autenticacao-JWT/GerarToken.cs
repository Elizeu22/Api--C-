using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;


namespace Corretora.Autenticacao_JWT
{
    public class GerarToken
    {
        private readonly IConfiguration _configuracao;
        public GerarToken(IConfiguration configuration)
        {
            _configuracao = configuration;
        }


        public string TokenAutenticacao()
        {
            var issuer = _configuracao["Jwt:Issuer"];
            var audience = _configuracao["Jwt:Issuer"];
            var expiracaotoken = DateTime.Now.AddDays(1);


            var chaveKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracao["Jwt:Key"]));


            var credenciais = new SigningCredentials(chaveKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credenciais);



            var handler = new JwtSecurityTokenHandler();
            var tokenGerado = handler.WriteToken(token);


            return tokenGerado;



        }

    }
}
