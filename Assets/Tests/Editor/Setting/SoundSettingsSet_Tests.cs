using System;
using NUnit.Framework;
using Project.Domain.Setting.Model;

namespace Tests.Editor {

    public sealed class SoundSettingsSet_Tests {

        [Test]
        public void �R���X�g���N�^�Ŋe�v���p�e�B������������������邱��() {
            // Arrange
            var bgm = new SoundSettings(0.8f, true);
            var se = new SoundSettings(0.3f, false);
            var voice = new SoundSettings(0.5f, false);

            // Act
            var soundSettingsSet = new SoundSettingsSet(bgm, se, voice);

            // Assert
            Assert.That(soundSettingsSet.Bgm, Is.SameAs(bgm), "BGM is not initialized correctly.");
            Assert.That(soundSettingsSet.Se, Is.SameAs(se), "SE is not initialized correctly.");
            Assert.That(soundSettingsSet.Voice, Is.SameAs(voice), "Voice is not initialized correctly.");
        }

        [Test]
        public void WithVoice�Ń{�C�X�ݒ肪�ύX���ꂽ�V�����C���X�^���X���Ԃ���邱��() {
            // Arrange
            var originalBgm = new SoundSettings(0.8f, true);
            var originalSe = new SoundSettings(0.3f, false);
            var originalVoice = new SoundSettings(0.5f, false);

            var newVoice = new SoundSettings(0.6f, true);
            var originalSet = new SoundSettingsSet(originalBgm, originalSe, originalVoice);

            // Act
            var updatedSet = originalSet.WithVoice(newVoice);

            // Assert
            Assert.That(updatedSet, Is.Not.SameAs(originalSet), "WithVoice should create a new instance.");
            Assert.That(updatedSet.Voice, Is.SameAs(newVoice), "Updated set does not have the correct voice settings.");
            Assert.That(updatedSet.Bgm, Is.SameAs(originalBgm), "BGM settings should remain unchanged.");
            Assert.That(updatedSet.Se, Is.SameAs(originalSe), "SE settings should remain unchanged.");
        }

        [Test]
        public void �������̔�r�������l�Ő��������삷�邱��() {
            // Arrange
            var bgm = new SoundSettings(0.8f, true);
            var se = new SoundSettings(0.3f, false);
            var voice = new SoundSettings(0.5f, false);

            var set1 = new SoundSettingsSet(bgm, se, voice);
            var set2 = new SoundSettingsSet(bgm, se, voice);

            // Act & Assert
            Assert.That(set1, Is.EqualTo(set2), "Equality comparison failed for same values.");
        }

        [Test]
        public void �������̔�r���قȂ�l�Ő��������삷�邱��() {
            // Arrange
            var voice1 = new SoundSettings(0.5f, false);
            var voice2 = new SoundSettings(0.6f, false);

            var bgm = new SoundSettings(0.8f, true);
            var se = new SoundSettings(0.3f, false);

            var set1 = new SoundSettingsSet(bgm, se, voice1);
            var set2 = new SoundSettingsSet(bgm, se, voice2);

            // Act & Assert
            Assert.That(set1, Is.Not.EqualTo(set2), "Equality comparison failed for different values.");
        }
    }
}
