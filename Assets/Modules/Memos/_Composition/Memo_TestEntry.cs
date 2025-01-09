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

            // SQLite�f�[�^�x�[�X�ɐڑ�
            _connection = new SQLiteConnection(dbPath);

            // �e�[�u���쐬
            _connection.CreateTable<User>();

            // �f�[�^��}��
            _connection.Insert(new User { Name = "John Doe", Age = 30 });

            // �f�[�^���擾
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
