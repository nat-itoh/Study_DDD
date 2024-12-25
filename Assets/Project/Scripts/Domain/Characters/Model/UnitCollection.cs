using System.Collections.Generic;
using UnityEngine;

namespace Project.Domain.Characters.Model {

    /// <summary>
    /// 
    /// </summary>
    public sealed class UnitCollection {

        private readonly List<Unit> _units;
        private int _activeUnitIndex;

        public IReadOnlyList<Unit> Units => _units;
        public Unit ActiveUnit => _units[_activeUnitIndex];

        /// <summary>
        /// 
        /// </summary>
        public UnitCollection(IEnumerable<Unit> units) {
            _units = new List<Unit>(units);
            _activeUnitIndex = 0;
        }

        public void SetActiveUnit(int index) {
            if (index < 0 || index >= _units.Count) {
                throw new System.ArgumentOutOfRangeException(nameof(index), "アクティブなユニットのインデックスが範囲外です。");
            }
            _activeUnitIndex = index;
        }
    }
}
