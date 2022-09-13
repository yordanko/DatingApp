using System;
using System.Collections.Generic;
using System.Text;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }

        // public int GetAge()
        // {
        //     return DateOfBirth.CalculateAge();
        // }

    }
    public class Testing : IEquatable<Testing>
    {
        private readonly string _myString;
        private readonly int _initValue;

        public int GetInitValue() => _initValue;

        public override bool Equals(object obj)
        {
            return Equals(obj as Testing);
        }

        public bool Equals(Testing other)
        {
            return other != null &&
                   _myString == other._myString &&
                   _initValue == other._initValue &&
                   MyProperty == other.MyProperty;
        }

        public int MyProperty { get; set; }

        public Testing(int initValue, string myString)
        {
            _initValue = initValue;
            _myString = myString;
        }

        public override int GetHashCode()
        {
            return _initValue + _myString.GetHashCode();
        }

        public string ThisIsMyMethod()
        {
            return "abc" + _myString;
        }
    }
}