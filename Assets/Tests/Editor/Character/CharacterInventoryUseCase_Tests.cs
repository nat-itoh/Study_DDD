using NUnit.Framework;
using Project.Domain.Characters.Model;
using Project.UseCase.Characters;

namespace Tests.Editor {

    public sealed class CharacterInventoryUseCase_Tests {

        private CharacterInventoryUseCase _useCase;

        [SetUp]
        public void セットアップ() {
            // Arrange: インベントリを用意
            var inventory = new CharacterInventory();
            _useCase = new CharacterInventoryUseCase(inventory);
        }

        [Test]
        public void キャラクターを追加できること() {
            // Arrange: キャラクターを用意
            var character = new Character(new CharacterId(1), "Hero", Rarity.Common);

            // Act: キャラクターを追加
            _useCase.AddCharacter(character);

            // Assert: キャラクターがインベントリに追加されていることを確認
            Assert.That(_useCase.GetCharacters().Count, Is.EqualTo(1), "キャラクターがインベントリに追加されていません。");
            Assert.That(_useCase.GetCharacters()[0], Is.EqualTo(character), "追加されたキャラクターが一致しません。");
        }

        [Test]
        public void キャラクターを削除できること() {
            // Arrange: キャラクターを追加
            var character = new Character(new CharacterId(1), "Hero", Rarity.Common);
            _useCase.AddCharacter(character);

            // Act: キャラクターを削除
            _useCase.RemoveCharacter(character.Id);

            // Assert: キャラクターがインベントリから削除されていることを確認
            Assert.That(_useCase.GetCharacters().Count, Is.EqualTo(0), "キャラクターがインベントリから削除されていません。");
        }
    }
}
