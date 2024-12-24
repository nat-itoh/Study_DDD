using System;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// 画質設定．ゲームの描画品質に関連する設定を管理する．
    /// </summary>
    public sealed class GraphicsSettings : ValueObject<GraphicsSettings> {

        /// <summary>
        /// 解像度（幅）．
        /// </summary>
        public int ResolutionWidth { get; private set; }

        /// <summary>
        /// 解像度（高さ）．
        /// </summary>
        public int ResolutionHeight { get; private set; }

        /// <summary>
        /// フルスクリーンモード．
        /// </summary>
        public bool FullScreen { get; private set; }

        /// <summary>
        /// グラフィック品質．
        /// （0: Low, 1: Medium, 2: High, etc.）
        /// </summary>
        public int GraphicsQuality { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public GraphicsSettings(int resolutionWidth, int resolutionHeight, bool fullScreen, int graphicsQuality) {
            ResolutionWidth = resolutionWidth;
            ResolutionHeight = resolutionHeight;
            FullScreen = fullScreen;
            GraphicsQuality = graphicsQuality;
        }

        /// <summary>
        /// ハッシュ値の取得．
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(ResolutionWidth, ResolutionHeight, FullScreen, GraphicsQuality);
        }

        /// <summary>
        /// 文字列への変換．
        /// </summary>
        public override string ToString() {
            return $"Resolution: {ResolutionWidth}x{ResolutionHeight}, FullScreen {FullScreen}";
        }

        public GraphicsSettings WithResolution(int width, int height) => new(width, height, FullScreen, GraphicsQuality);
        public GraphicsSettings WithFullScreen(bool fullScreen) => new(ResolutionWidth, ResolutionHeight, fullScreen, GraphicsQuality);
        public GraphicsSettings WithGraphicsQuality(int graphicsQuality) => new(ResolutionWidth, ResolutionHeight, FullScreen, graphicsQuality);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 値の比較ロジック．
        /// </summary>
        protected override bool EqualsCore(GraphicsSettings other) {
            return ResolutionWidth == other.ResolutionWidth &&
                   ResolutionHeight == other.ResolutionHeight &&
                   FullScreen == other.FullScreen &&
                   GraphicsQuality == other.GraphicsQuality;
        }
    }
}
