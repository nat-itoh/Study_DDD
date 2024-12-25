using System;
using NUnit.Framework;
using Project.Domain.Characters.Model;

namespace Tests.Editor {

    public sealed class Character_Tests {

        [Test]
        public void �L�����N�^�[ID�������l�œ����Ɣ��肳��邱��() {
            // Arrange: �L�����N�^�[ID��p��
            var id1 = new CharacterId(1);
            var id2 = new CharacterId(1);

            // Act: �������̊m�F
            var areEqual = id1 == id2;

            // Assert: 
            Assert.That(areEqual, Is.True, "�����l�̃L�����N�^�[ID�������Ɣ��肳��܂���ł����B");
        }

        [Test]
        public void ���A���e�B�������l�œ����Ɣ��肳��邱��() {
            // Arrange: ���A���e�B��p��
            var rarity1 = Rarity.Common;
            var rarity2 = Rarity.Common;

            // Act: �������̊m�F
            var areEqual = rarity1 == rarity2;

            // Assert: 
            Assert.That(areEqual, Is.True, "�����l�̃��A���e�B�������Ɣ��肳��܂���ł����B");
        }
    }
}
