using System;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// �掿�ݒ�D�Q�[���̕`��i���Ɋ֘A����ݒ���Ǘ�����D
    /// </summary>
    public sealed class GraphicsSettings : ValueObject<GraphicsSettings> {

        /// <summary>
        /// �𑜓x�i���j�D
        /// </summary>
        public int ResolutionWidth { get; private set; }

        /// <summary>
        /// �𑜓x�i�����j�D
        /// </summary>
        public int ResolutionHeight { get; private set; }

        /// <summary>
        /// �t���X�N���[�����[�h�D
        /// </summary>
        public bool FullScreen { get; private set; }

        /// <summary>
        /// �O���t�B�b�N�i���D
        /// �i0: Low, 1: Medium, 2: High, etc.�j
        /// </summary>
        public int GraphicsQuality { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public GraphicsSettings(int resolutionWidth, int resolutionHeight, bool fullScreen, int graphicsQuality) {
            ResolutionWidth = resolutionWidth;
            ResolutionHeight = resolutionHeight;
            FullScreen = fullScreen;
            GraphicsQuality = graphicsQuality;
        }

        /// <summary>
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(ResolutionWidth, ResolutionHeight, FullScreen, GraphicsQuality);
        }

        /// <summary>
        /// ������ւ̕ϊ��D
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
        /// �l�̔�r���W�b�N�D
        /// </summary>
        protected override bool EqualsCore(GraphicsSettings other) {
            return ResolutionWidth == other.ResolutionWidth &&
                   ResolutionHeight == other.ResolutionHeight &&
                   FullScreen == other.FullScreen &&
                   GraphicsQuality == other.GraphicsQuality;
        }
    }
}
