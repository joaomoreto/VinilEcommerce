using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.CrossCutting.Exception;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;

namespace VinilEcommerce.Domain.Commands.SellDisks
{
    public sealed class SellDisksCommandHandler :
        IRequestHandler<SellDisksCommand>
    {
        private readonly IDisksDataBase _disksDataBase;

        public SellDisksCommandHandler(IDisksDataBase disksDataBase)
        {
            _disksDataBase = disksDataBase;
        }

        public async Task<Unit> Handle(SellDisksCommand request, CancellationToken cancellationToken)
        {
            var sales = new List<SalesDataBaseRequest>();

            foreach (var id in request.Ids)
            {
                var disk = _disksDataBase.GetDisksById(id);

                if (disk == null)
                    throw new DiskNotFoundException();

                var cashback = _disksDataBase.GetCashback(DateTime.Now.DayOfWeek.ToString()).FirstOrDefault(x =>
                    x.Genre.Equals(disk.Genre, StringComparison.CurrentCultureIgnoreCase));

                sales.Add(new SalesDataBaseRequest
                {
                    Name = disk.Name,
                    Id = id,
                    Genre = disk.Genre,
                    Cashback = disk.Price * (cashback?.Value/100) ?? 0,
                    Date = DateTime.Now
                });
            }

            _disksDataBase.SellDisks(sales);

            return Unit.Value;
        }
    }
}
