using NUnit.Framework;
using Project.Domain.Characters.Model;
using Project.UseCase.Characters;

namespace Tests.Editor {

    public sealed class CharacterInventoryUseCase_Tests {

        private CharacterInventoryUseCase _useCase;

        [SetUp]
        public void �Z�b�g�A�b�v() {
            // Arrange: �C���x���g����p��
            var inventory = new CharacterInventory();
            _useCase = new CharacterInventoryUseCase(inventory);
        }

        [Test]
        public void �L�����N�^�[��ǉ��ł��邱��() {
            // Arrange: �L�����N�^�[��p��
            var character = new Character(new CharacterId(1), "Hero", Rarity.Common);

            // Act: �L�����N�^�[��ǉ�
            _useCase.AddCharacter(character);

            // Assert: �L�����N�^�[���C���x���g���ɒǉ�����Ă��邱�Ƃ��m�F
            Assert.That(_useCase.GetCharacters().Count, Is.EqualTo(1), "�L�����N�^�[���C���x���g���ɒǉ�����Ă��܂���B");
            Assert.That(_useCase.GetCharacters()[0], Is.EqualTo(character), "�ǉ����ꂽ�L�����N�^�[����v���܂���B");
        }

        [Test]
        public void �L�����N�^�[���폜�ł��邱��() {
            // Arrange: �L�����N�^�[��ǉ�
            var character = new Character(new CharacterId(1), "Hero", Rarity.Common);
            _useCase.AddCharacter(character);

            // Act: �L�����N�^�[���폜
            _useCase.RemoveCharacter(character.Id);

            // Assert: �L�����N�^�[���C���x���g������폜����Ă��邱�Ƃ��m�F
            Assert.That(_useCase.GetCharacters().Count, Is.EqualTo(0), "�L�����N�^�[���C���x���g������폜����Ă��܂���B");
        }
    }
}
