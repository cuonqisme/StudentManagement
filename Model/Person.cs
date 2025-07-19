using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class Person
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Person()
        {
            Id = nextId++;
        }

        public Person(string name, DateTime dateOfBirth, string address, double height, double weight)
        {
            Id = nextId++;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Height = height;
            Weight = weight;
        }

        //id auto increment ++
        public static void SetNextId(int id)
        {
            nextId = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, DoB: {DateOfBirth:dd/MM/yyyy}, Address: {Address}, Height: {Height}cm, Weight: {Weight}kg";
        }
    }
}
