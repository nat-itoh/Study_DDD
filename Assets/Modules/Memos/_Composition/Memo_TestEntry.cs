using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using SQLite;
using System.IO;

namespace Project.Composition {

    public class Memo_TestEntry : MonoBehaviour {

        private void Start() {
            var context = new DbContext();
        }

    }


    public class DbContext : IDisposable {

        private readonly SQLiteConnection _connection;

        public DbContext() {
            var dbPath = Path.Combine(UnityEngine.Application.persistentDataPath, "memory.db");
            Debug.Log(dbPath);

            // SQLiteデータベースに接続
            _connection = new SQLiteConnection(dbPath);

            // テーブル作成
            _connection.CreateTable<User>();

            // データを挿入
            _connection.Insert(new User { Name = "John Doe", Age = 30 });

            // データを取得
            var users = _connection.Table<User>();
            foreach (var user in users) {
                Debug.Log($"User: {user.Name}, Age: {user.Age}");
            }
        }
        
        
        public void Dispose() {
        }
    }

    public class User {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
