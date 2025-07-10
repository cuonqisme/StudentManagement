using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class Student : Person
    {
        public string StudentId { get; set; }
        public string University { get; set; }
        public int AcademicYear { get; set; }

        private double _gpa;
        public double Gpa
        {
            get => _gpa;
            set
            {
                _gpa = value;
                Rank = CalculateRank(); //auto update rank
            }
        }

        public AcademicRank Rank { get; private set; }

        public Student() : base() { }

        public Student(string name, DateTime dateOfBirth, string address, double height, double weight,
                       string studentId, string university, int academicYear, double gpa)
            : base(name, dateOfBirth, address, height, weight)
        {
            StudentId = studentId;
            University = university;
            AcademicYear = academicYear;
            Gpa = gpa;
        }

        //set gpa with true academic rank
        private AcademicRank CalculateRank()
        {
            if (_gpa < 3.0) return AcademicRank.Poor;
            if (_gpa < 5.0) return AcademicRank.Weak;
            if (_gpa < 6.5) return AcademicRank.Average;
            if (_gpa < 7.5) return AcademicRank.Good;
            if (_gpa < 9.0) return AcademicRank.Excellent;
            return AcademicRank.Excellent;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Student ID: {StudentId}, University: {University}, Year: {AcademicYear}, GPA: {Gpa}, Rank: {Rank}";
        }
    }

    public enum AcademicRank
    {
        Poor,
        Weak,
        Average,
        Fair,
        Good,
        Excellent
    }
}
