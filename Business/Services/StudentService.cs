using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class StudentService : IStudent
    {
        private StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public static int Count { get; set; }
        public Student Create(Student Student)
        {
            Count++;
            Student.Id = Count;

            _studentRepository.Create(Student);

            return Student;
        }

        public Student Delete(int Id)
        {
            Student isExist = _studentRepository.GetOne(g => g.Id == Id);
            if (isExist == null)
            {
                return null;
            }
            _studentRepository.Delete(isExist);
            return isExist;
        }

        public List<Student> GetAll(string name = null)
        {
            return _studentRepository.GetAll(g => g.GroupNo == name);
        }

        public Student GetStudent(string name)
        {
            return _studentRepository.GetOne(g => g.Name == name);
        }
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public Student GetStudent(int id)
        {
            return _studentRepository.GetOne(g => g.Id == id);
        }

        public Student Update(int Id, Student Student)
        {
            throw new NotImplementedException();
        }
    }
}
