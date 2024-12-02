using UnityEngine;
using App.Domain.Shared;

// [REF]
//  qiita: DDD�����p�^�[���̋敪�I�u�W�F�N�g��C#�Ŏ������� https://qiita.com/haguta/items/ceca207c313eef332cb1

namespace App.Domain
{
    public sealed class AppScene : ValueObject<AppScene> {

        // 
        public static AppScene Home => new AppScene(nameof(AppScene.Home));
        public static AppScene Stage => new AppScene(nameof(AppScene.Stage));


        private readonly int _hash;
        private readonly string _name;

        /// <summary>
        /// �R���X�g���N�^�D(����J)
        /// </summary>
        private AppScene(string sceneName) {
            if (string.IsNullOrEmpty(sceneName))
                throw new System.InvalidOperationException();

            _name = sceneName;
            _hash = sceneName.GetHashCode();
        }

        /// <summary>
        /// ������r�D
        /// </summary>
        protected override bool EqualsCore(AppScene other) {
            return this._hash == other._hash;
        }
    }
}
