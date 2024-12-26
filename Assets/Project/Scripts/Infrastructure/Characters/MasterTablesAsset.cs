using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [REF]
//  qiita: Unity Excel Importerを作ってみた https://qiita.com/mikito/items/2ad911f69180c15102a1

namespace Project.Infrastructure.Characters {

    /// <summary>
    /// "Excel Importer"を用いてExcelから自動でデータを読み込むためScriptableObject．
    /// クラス名はExcelファイル名，フィールド名はExcelシート名にそれぞれ対応させる．
    /// </summary>
    [ExcelAsset(LogOnImport = true)]
    internal sealed class MasterTablesAsset : ScriptableObject {

        // Excelの各シートに対応
        public List<CharacterData> CharacterData; 

    }

}