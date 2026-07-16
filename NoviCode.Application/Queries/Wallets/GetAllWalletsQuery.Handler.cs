using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Wallets
{
    public class GetAllWalletsQueryHandler : IRequestHandler<GetAllWalletsQuery, IReadOnlyList<Wallet>>
    {
        private readonly IWalletRepository _wallets;

        public GetAllWalletsQueryHandler(IWalletRepository wallets) => _wallets = wallets;

        public Task<IReadOnlyList<Wallet>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken) =>
            _wallets.GetAllAsync(cancellationToken);
    }
}
