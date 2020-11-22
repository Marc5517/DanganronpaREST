using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DanganronpaREST.Model
{
    public class Character
    {
        private int _studentId;
        private string _firstName;
        private string _lastName;
        private string _talent;
        private int _classNo;

        public Character()
        {

        }

        public Character(int studentId, string firstName, string lastName, string talent, int classNo)
        {
            _studentId = studentId;
            _firstName = firstName;
            _lastName = lastName;
            _talent = talent;
            _classNo = classNo;
        }

        public int StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
            }
        }

        public string Talent
        {
            get => _talent;
            set
            {
                _talent = value;
            }
        }

        public int ClassNo
        {
            get => _classNo;
            set
            {
                _classNo = value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(StudentId)}: {_studentId}, {nameof(FirstName)}: {_firstName}, {nameof(LastName)}: {_lastName}, {nameof(Talent)}: {_talent}, {nameof(ClassNo)}: {_classNo}";
        }
    }
}
