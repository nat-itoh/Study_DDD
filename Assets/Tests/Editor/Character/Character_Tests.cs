using System;
using NUnit.Framework;
using Project.Domain.Characters.Model;

namespace Tests.Editor {

    public sealed class Character_Tests {

        [Test]
        public void キャラクターIDが同じ値で等価と判定されること() {
            // Arrange: キャラクターIDを用意
            var id1 = new CharacterId(1);
            var id2 = new CharacterId(1);

            // Act: 等価性の確認
            var areEqual = id1 == id2;

            // Assert: 
            Assert.That(areEqual, Is.True, "同じ値のキャラクターIDが等価と判定されませんでした。");
        }

        [Test]
        public void レアリティが同じ値で等価と判定されること() {
            // Arrange: レアリティを用意
            var rarity1 = Rarity.Common;
            var rarity2 = Rarity.Common;

            // Act: 等価性の確認
            var areEqual = rarity1 == rarity2;

            // Assert: 
            Assert.That(areEqual, Is.True, "同じ値のレアリティが等価と判定されませんでした。");
        }
    }
}
