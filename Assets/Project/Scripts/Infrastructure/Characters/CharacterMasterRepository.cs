using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Project.Domain.Characters.Model;
using Project.Domain.Characters.Repository;
using Project.Foundation;

namespace Project.Infrastructure.Characters {

    public sealed class CharacterMasterRepository : ICharacterMaseterRepository {

        private ICharacterMasterTable _table;

        public void ClearCache() {
            _table = null;
        }

        /// <summary>
        /// 非同期でマスターテーブルを読み込む．
        /// </summary>
        public async UniTask<ICharacterMasterTable> FetchTableAsync() {
            if (_table != null)
                return _table;

            var request = Resources.LoadAsync<MasterTablesAsset>(ResourceKey.MasterTable.Character);
            await request.ToUniTask();
            
            // Table Asset
            var tableAsset = (MasterTablesAsset)request.asset;
            if (tableAsset == null) {
                throw new System.Exception($"Failed to load {nameof(MasterTablesAsset)} ");
            }

            // Table
            var characters = tableAsset.CharacterData
                .Select(data => new Character(
                    new CharacterId(data.id), 
                    data.name, 
                    Rarity.FromName(data.rarity))
                );
            _table = new CharacterMasterTable(characters);
            _table.Initialize();
            
            return _table;
        }
    }
}
