using ProjectOs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectOs.Domain.Interface
{
    public interface IOrderOfServiceRepository
    {
        Task<long> CountAsync();

        Task<IEnumerable<OrderOfService>> GetAllOrderOfServiceAsync(DateTime dataOpeningOSInicial, DateTime dataOpeningOSFinal, int? page);

        Task<OrderOfService> GetOneOrderOfServiceAsync(Guid id);

        Task CreateOrderOfServiceAsync(OrderOfService orderOfService);

        Task UpdateOrderOfServiceAsync(OrderOfService orderOfService);

        Task DeleteOrderOfServiceAsync(Guid id);
    }
}
