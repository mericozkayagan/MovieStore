using Microsoft.Extensions.Configuration;
using MovieStore.DbOperations;
using MovieStore.TokenOperationsAndModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.TokenOperations.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IContext _context;

        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı");
            }
        }
    }
}
