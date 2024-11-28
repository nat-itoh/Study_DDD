using System;
using UnityEngine;
using BmiApp.Domain.BmiCalculater.Repository;
using BmiApp.Domain.Shared;
using System.Linq;
using System.Collections.Generic;

namespace BmiApp.Infrastructure {

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BmiDTO : IBmiDTO {

        [SerializeField] string _name ;
        [SerializeField] float _height;
        [SerializeField] float _weight;
        [SerializeField] int _age;
        [SerializeField] string _gender;
        [SerializeField] string _createdAt;

        private const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";


        public string Name { 
            get => _name; 
            set => _name = value; 
        }

        public float Height { 
            get => _height; 
            set => _height = value; 
        }
        
        public float Weight { 
            get => _weight; 
            set => _weight = value; 
        }
        
        public int Age { 
            get => _age; 
            set => _age = value; 
        }
        
        public Gender Gender { 
            get => (Gender)Enum.Parse(typeof(Gender), _gender); 
            set => _gender = value.ToString(); 
        }
        
        public DateTime CreatedAt { set { _createdAt = value.ToString(dateTimeFormat); } get => DateTime.Parse(_createdAt); }


        public BmiDTO() {
            _name = string.Empty;
            _height = 0.0F;
            _weight = 0.0F;
            _age = 0;
            _gender = Gender.None.ToString();
            _createdAt = DateTime.MinValue.ToString(dateTimeFormat);
        }
    }


    [Serializable]
    public class BmiDTOArray {

        [SerializeField] BmiDTO[] items;

        public IReadOnlyList<BmiDTO> Items => items;

        
        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public BmiDTOArray(BmiDTO[] items) { 
            this.items = items; 
        }
        
        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public BmiDTOArray(IBmiDTO[] items) {
            this.items = items.Select(x =>
                new BmiDTO {
                    Name = x.Name,
                    Height = x.Height,
                    Weight = x.Weight,
                    Age = x.Age,
                    Gender = x.Gender,
                    CreatedAt = x.CreatedAt
                }
            ).ToArray();
        }
    }
}
