using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [REF]
//  qiita: Unity Excel Importer������Ă݂� https://qiita.com/mikito/items/2ad911f69180c15102a1

namespace Project.Infrastructure.Characters {

    /// <summary>
    /// "Excel Importer"��p����Excel���玩���Ńf�[�^��ǂݍ��ނ���ScriptableObject�D
    /// �N���X����Excel�t�@�C�����C�t�B�[���h����Excel�V�[�g���ɂ��ꂼ��Ή�������D
    /// </summary>
    [ExcelAsset(LogOnImport = true)]
    internal sealed class MasterTablesAsset : ScriptableObject {

        // Excel�̊e�V�[�g�ɑΉ�
        public List<CharacterData> CharacterData; 

    }

}