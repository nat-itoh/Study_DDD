using System;
using System.Collections.Generic;
using App.Domain.Authentification.ValueObjects;

namespace App.Domain.Authentification.Entites {

    public sealed class User {

        public Guid UserId { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsLocked { get; private set; }
        public List<string> Roles { get; private set; }


        public User(Email email, string passwordHash, bool isActive = true) {
            UserId = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            IsActive = isActive;
            IsLocked = false;
            Roles = new List<string>();
        }

        public void LockAccount() {
            IsLocked = true;
        }

        public void UnlockAccount() {
            IsLocked = false;
        }

        public void AddRole(string role) {
            if (!Roles.Contains(role))
                Roles.Add(role);
        }
    }
}
