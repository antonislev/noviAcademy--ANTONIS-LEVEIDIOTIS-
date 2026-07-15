using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Wallets
{
    public class GetWalletsByPlayerQueryHandler : IRequestHandler<GetWalletsByPlayerQuery, IReadOnlyList<Wallet>>
    {
        private readonly IWalletRepository _wallets;

        public GetWalletsByPlayerQueryHandler(IWalletRepository wallets) => _wallets = wallets;

        public Task<IReadOnlyList<Wallet>> Handle(GetWalletsByPlayerQuery request, CancellationToken cancellationToken) =>
            _wallets.GetByPlayerAsync(request.PlayerId, cancellationToken);
    }
}
