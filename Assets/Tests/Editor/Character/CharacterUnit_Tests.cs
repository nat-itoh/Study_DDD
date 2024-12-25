using System;
using System.Collections.Generic;
using NUnit.Framework;
using Project.Domain.Characters.Model;

namespace Tests.Editor {

    public sealed class CharacterUnit_Tests{

        [Test]
        public void ���j�b�g�ɃL�����N�^�[��ǉ��ł��邱��() {
            // Arrange
            var unit = new Unit(new List<Character>());
            var character = new Character(new CharacterId(1), "Hero", Rarity.Common);

            // Act
            unit.AddMember(character);

            // Assert
            Assert.That(unit.Members.Count, Is.EqualTo(1));
            Assert.That(unit.Members[0], Is.EqualTo(character));
        }

        [Test]
        public void ���j�b�g����L�����N�^�[���폜�ł��邱��() {
            // Arrange
            var character = new Character(new CharacterId(1), "Hero", Rarity.Common);
            var unit = new Unit(new List<Character> { character });

            // Act
            unit.RemoveMember(character.Id);

            // Assert
            Assert.That(unit.Members.Count, Is.EqualTo(0));
        }
    }
}
