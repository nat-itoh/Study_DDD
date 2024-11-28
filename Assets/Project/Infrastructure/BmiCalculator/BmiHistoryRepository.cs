using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BmiApp.Domain.BmiCalculater.Repository;

namespace BmiApp.Infrastructure.BmiCalculator {

    public class BmiHistoryRepository : IBmiHistoryRepository {

        Task IBmiHistoryRepository.DeleteAsync() {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IBmiDTO>> IBmiHistoryRepository.LoadAllAsync() {
            throw new NotImplementedException();
        }

        Task IBmiHistoryRepository.SaveAsync() {
            throw new NotImplementedException();
        }
    }
}
