using System;
using System.Collections.Generic;
using NUnit.Framework;
using Project.Domain.Characters.Model;

namespace Tests.Editor {

    public sealed class CharacterUnit_Tests{

        [Test]
        public void ユニットにキャラクターを追加できること() {
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
        public void ユニットからキャラクターを削除できること() {
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
