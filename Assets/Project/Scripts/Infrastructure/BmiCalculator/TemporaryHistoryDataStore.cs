using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.BmiCalculater.Repository;

namespace App.Infrastructure.BmiCalculator {

    /// <summary>
    /// �ꎞ�I�ȃf�[�^�ۑ��p�N���X�D
    /// </summary>
    public class TemporaryHistoryDataStore : IHistoryDataStore {

        /// <summary>
        /// �f�[�^���X�g�D
        /// </summary>
        public IList<IBmiDTO> Datas { get; private set; }


        /// <summary>
        /// �R���X�g���N�^�D
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
