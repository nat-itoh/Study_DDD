using NUnit.Framework;
using Project.Domain.Setting.Model;

namespace Tests.Editor {

    public sealed class SoundSettingsTests{

        [Test]
        public void �R���X�g���N�^�ŉ��ʂƃ~���[�g��Ԃ�����������������邱��() {
            // Arrange
            float volume = 0.8f;
            bool isMuted = true;

            // Act
            var soundSettings = new SoundSettings(volume, isMuted);

            // Assert
            Assert.That(soundSettings.Volume, Is.EqualTo(volume), "Volume is not initialized correctly.");
            Assert.That(soundSettings.Muted, Is.EqualTo(isMuted), "Muted state is not initialized correctly.");
        }

        [Test]
        public void �������̔�r�������l�Ő��������삷�邱��() {
            // Arrange
            var soundSettings1 = new SoundSettings(0.5f, false);
            var soundSettings2 = new SoundSettings(0.5f, false);

            // Act & Assert
            Assert.That(soundSettings1, Is.EqualTo(soundSettings2), "Equality comparison failed for same values.");
        }

        [Test]
        public void �������̔�r���قȂ�l�Ő��������삷�邱��() {
            // Arrange
            var soundSettings1 = new SoundSettings(0.5f, false);
            var soundSettings2 = new SoundSettings(0.8f, false);

            // Act & Assert
            Assert.That(soundSettings1, Is.Not.EqualTo(soundSettings2), "Equality comparison failed for different values.");
        }

        [Test]
        public void WithVolume�ŉ��ʂ��ύX���ꂽ�V�����C���X�^���X���Ԃ���邱��() {
            // Arrange
            var original = new SoundSettings(0.5f, false);
            float newVolume = 0.8f;

            // Act
            var updated = original.WithVolume(newVolume);

            // Assert
            Assert.That(updated, Is.Not.SameAs(original), "WithVolume should create a new instance.");
            Assert.That(updated.Volume, Is.EqualTo(newVolume), "Updated instance does not have the correct volume.");
            Assert.That(updated.Muted, Is.EqualTo(original.Muted), "Muted property should remain unchanged.");
        }

        [Test]
        public void WithMuted�Ń~���[�g��Ԃ��ύX���ꂽ�V�����C���X�^���X���Ԃ���邱��() {
            // Arrange
            var original = new SoundSettings(0.5f, false);
            bool newMuted = true;

            // Act
            var updated = original.WithMuted(newMuted);

            // Assert
            Assert.That(updated, Is.Not.SameAs(original), "WithMuted should create a new instance.");
            Assert.That(updated.Muted, Is.EqualTo(newMuted), "Updated instance does not have the correct muted state.");
            Assert.That(updated.Volume, Is.EqualTo(original.Volume), "Volume property should remain unchanged.");
        }
    }


    public sealed class SoundSettingsSetTests {

        [Test]
        public void �R���X�g���N�^�Ŋe�v���p�e�B������������������邱��() {
            // Arrange
            var voice = new SoundSettings(0.5f, false);
            var bgm = new SoundSettings(0.8f, true);
            var se = new SoundSettings(0.3f, false);

            // Act
            var soundSettingsSet = new SoundSettingsSet(voice, bgm, se);

            // Assert
            Assert.That(soundSettingsSet.Voice, Is.SameAs(voice), "Voice is not initialized correctly.");
            Assert.That(soundSettingsSet.Bgm, Is.SameAs(bgm), "BGM is not initialized correctly.");
            Assert.That(soundSettingsSet.Se, Is.SameAs(se), "SE is not initialized correctly.");
        }

        [Test]
        public void WithVoice�Ń{�C�X�ݒ肪�ύX���ꂽ�V�����C���X�^���X���Ԃ���邱��() {
            // Arrange
            var originalVoice = new SoundSettings(0.5f, false);
            var originalBgm = new SoundSettings(0.8f, true);
            var originalSe = new SoundSettings(0.3f, false);

            var newVoice = new SoundSettings(0.6f, true);
            var originalSet = new SoundSettingsSet(originalVoice, originalBgm, originalSe);

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
            var voice = new SoundSettings(0.5f, false);
            var bgm = new SoundSettings(0.8f, true);
            var se = new SoundSettings(0.3f, false);

            var set1 = new SoundSettingsSet(voice, bgm, se);
            var set2 = new SoundSettingsSet(voice, bgm, se);

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

            var set1 = new SoundSettingsSet(voice1, bgm, se);
            var set2 = new SoundSettingsSet(voice2, bgm, se);

            // Act & Assert
            Assert.That(set1, Is.Not.EqualTo(set2), "Equality comparison failed for different values.");
        }
    }
}
