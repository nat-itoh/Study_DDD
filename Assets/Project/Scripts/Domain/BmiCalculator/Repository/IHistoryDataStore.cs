using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Shared;

namespace App.Domain.BmiCalculater.Repository{

    public interface IHistoryDataStore {
    
        IList<IBmiDTO> Datas { get; }
        Task LoadAsync();
        Task SaveAsync();
        Task DeleteAsync();
    }
}
