using System;
using NUnit.Framework;
using Project.Domain.Setting.Model;

namespace Tests.Editor {

    public sealed class SoundSettings_Tests {

        [Test]
        public void コンストラクタで音量とミュート状態が正しく初期化されること() {
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
        public void 等価性の比較が同じ値で正しく動作すること() {
            // Arrange
            var soundSettings1 = new SoundSettings(0.5f, false);
            var soundSettings2 = new SoundSettings(0.5f, false);

            // Act & Assert
            Assert.That(soundSettings1, Is.EqualTo(soundSettings2), "Equality comparison failed for same values.");
        }

        [Test]
        public void 等価性の比較が異なる値で正しく動作すること() {
            // Arrange
            var soundSettings1 = new SoundSettings(0.5f, false);
            var soundSettings2 = new SoundSettings(0.8f, false);

            // Act & Assert
            Assert.That(soundSettings1, Is.Not.EqualTo(soundSettings2), "Equality comparison failed for different values.");
        }

        [Test]
        public void WithVolumeで音量が変更された新しいインスタンスが返されること() {
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
        public void WithMutedでミュート状態が変更された新しいインスタンスが返されること() {
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
}
