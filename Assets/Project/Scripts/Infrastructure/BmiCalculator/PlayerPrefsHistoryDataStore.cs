using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using App.Domain.BmiCalculater.Repository;

namespace App.Infrastructure.BmiCalculator {

    /// <summary>
    /// <see cref="PlayerPrefs"/>�𗘗p�����i���I�ȃf�[�^�ۑ��p�N���X�D
    /// </summary>
    public class PlayerPrefsHistoryDataStore : IHistoryDataStore{

        private readonly string _key;

        /// <summary>
        /// �f�[�^���X�g�D
        /// </summary>
        public IList<IBmiDTO> Datas { get; private set; }


        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public PlayerPrefsHistoryDataStore(string accountId) {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentException("account id is invalied text.");

            _key = accountId;
        }

        Task IHistoryDataStore.LoadAsync() {
            // Read data
            var json = PlayerPrefs.GetString(_key);
            if (string.IsNullOrEmpty(json)) {
                Datas = new List<IBmiDTO>();
                return Task.CompletedTask;
            }

            // Convert from json
            var array = JsonUtility.FromJson<BmiDTOArray>(json);
            if(array?.Items is null || array.Items.Count == 0) {
                Datas = new List<IBmiDTO>();
                return Task.CompletedTask;
            }

            Datas = array.Items.Cast<IBmiDTO>().ToArray();
            return Task.CompletedTask;
        }

        Task IHistoryDataStore.SaveAsync() {            
            // Convert to json
            var datas = new BmiDTOArray(Datas.ToArray());
            var json = JsonUtility.ToJson(datas) ?? "{}";
            
            // Write data
            PlayerPrefs.SetString(_key, json);
            return Task.CompletedTask;
        }

        Task IHistoryDataStore.DeleteAsync() {
            PlayerPrefs.DeleteKey(_key);
            return Task.CompletedTask;
        }
    }
}
