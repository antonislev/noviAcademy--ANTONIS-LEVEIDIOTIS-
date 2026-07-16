using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Wallets
{
    public class GetWalletByIdQueryHandler : IRequestHandler<GetWalletByIdQuery, Wallet?>
    {
        private readonly IWalletRepository _wallets;

        public GetWalletByIdQueryHandler(IWalletRepository wallets) => _wallets = wallets;

        public Task<Wallet?> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken) =>
            _wallets.GetByIdAsync(request.Id, cancellationToken);
    }
}
