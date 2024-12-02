using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.BmiCalculater.Repository;

namespace App.Infrastructure.BmiCalculator {

    /// <summary>
    /// 一時的なデータ保存用クラス．
    /// </summary>
    public class TemporaryHistoryDataStore : IHistoryDataStore {

        /// <summary>
        /// データリスト．
        /// </summary>
        public IList<IBmiDTO> Datas { get; private set; }


        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public TemporaryHistoryDataStore() {
            Datas = new List<IBmiDTO>();
        }

        Task IHistoryDataStore.LoadAsync() {
            // Do Nothing
            return Task.CompletedTask;
        }

        Task IHistoryDataStore.SaveAsync() {
            // Do Nothing
            return Task.CompletedTask;
        }
        
        Task IHistoryDataStore.DeleteAsync() {
            Datas.Clear();
            return Task.CompletedTask;
        }
    }
}
