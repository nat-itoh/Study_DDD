using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BmiApp.Domain.BmiCalculater.Repository {

    public interface IBmiHistoryRepository {

        Task SaveAsync();
        Task<IEnumerable<IBmiDTO>> LoadAllAsync();
        Task DeleteAsync();
    }
}
