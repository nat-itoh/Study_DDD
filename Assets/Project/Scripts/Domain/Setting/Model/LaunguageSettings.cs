using System;
using UniRx;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// 言語設定．言語や地域に関連する設定を管理する．
    /// </summary>
    public sealed class LaunguageSettings : ValueObject<LaunguageSettings> {

        /// <summary>
        /// 言語コード．
        /// （e.g., "en-US", "ja-JP"）
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// 地域コード．
        /// （e.g., "US", "JP"）
        /// </summary>
        public string RegionCode { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public LaunguageSettings() {

        }

        /// <summary>
        /// ハッシュ値の取得．
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(LanguageCode, RegionCode);
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 値の比較ロジック．
        /// </summary>
        protected override bool EqualsCore(LaunguageSettings other) {
            return this.LanguageCode == other.LanguageCode
                && this.RegionCode == other.RegionCode;
        }
    }
}
