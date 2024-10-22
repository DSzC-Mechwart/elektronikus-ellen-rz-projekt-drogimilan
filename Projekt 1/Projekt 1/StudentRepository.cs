using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt_1
{
    public class StudentRepository
    {
        private const string FilePath = "students.txt";
        private List<Tanulo> students;

        public StudentRepository()
        {
            students = LoadStudents();
        }

        private List<Tanulo> LoadStudents()
        {
            if (!File.Exists(FilePath))
                return new List<Tanulo>();

            var lines = File.ReadAllLines(FilePath);
            return lines.Select(line =>
            {
                var parts = line.Split(';');
                return new Tanulo
                {
                    Name = parts[0],
                    Birthplace = parts[1],
                    BirthDate = DateTime.Parse(parts[2]),
                    MotherName = parts[3],
                    Address = parts[4],
                    EnrollmentDate = DateTime.Parse(parts[5]),
                    Major = parts[6],
                    Class = parts[7],
                    IsDormitory = bool.Parse(parts[8]),
                    Dormitory = parts[9],
                    LogNumber = int.Parse(parts[10]),
                    RegisterNumber = parts[11]
                };
            }).ToList();
        }

        public void SaveStudent(Tanulo student)
        {
            students.Add(student);
            File.AppendAllText(FilePath, student.ToString() + Environment.NewLine);
        }

        public List<Tanulo> GetAllStudents()
        {
            return students;
        }

        public void DeleteStudent(Tanulo student)
        {
            students.Remove(student);
            File.WriteAllLines(FilePath, students.Select(s => s.ToString()));
        }

        public int CountDormitoryStudents() => students.Count(s => s.IsDormitory);
        public int CountStudentsFromDebrecen() => students.Count(s => s.Birthplace.ToLower() == "debrecen");
        public int CountCommutingStudents() => students.Count(s => !s.IsDormitory);
    }
}