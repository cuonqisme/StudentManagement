using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class Person
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Person()
        {
            Id = _nextId++;
        }

        public Person(string name, DateTime dateOfBirth, string address, double height, double weight)
        {
            Id = _nextId++;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Height = height;
            Weight = weight;
        }

        //handle ID auto increment
        public static void SetNextId(int id)
        {
            _nextId = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, DoB: {DateOfBirth:dd/MM/yyyy}, Address: {Address}, Height: {Height}cm, Weight: {Weight}kg";
        }
    }
}
