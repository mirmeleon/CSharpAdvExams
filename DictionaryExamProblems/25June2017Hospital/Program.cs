using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25June2017Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, Dictionary<int, string[]>>();
            var doctors = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                if (input[0] == "Output")
                {
                    break;
                }
                var departmentName = input[0];
                var doctor = input[1] + " " + input[2];
                var patient = input[3];

                if (!departments.ContainsKey(departmentName))
                {
                    departments[departmentName] = new Dictionary<int, string[]>();
                }
                var department = departments[departmentName];
                bool imported = false;
                for (int i = 1; i <= 20; i++)
                {
                    if (!department.ContainsKey(i))
                    {
                        department[i] = new string[3];
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        if (department[i][j] == null)
                        {
                            department[i][j] = patient;
                            imported = true;
                            break;
                        }
                    }
                    if (imported)
                    {
                        break;
                    }
                }
                if (imported)
                {
                    if (!doctors.ContainsKey(doctor))
                    {
                        doctors[doctor] = new List<string>();
                    }
                    doctors[doctor].Add(patient);
                }

            }
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                if (input[0] == "End")
                {
                    break;
                }
                if (input.Count == 1)
                {
                    var department = departments[input[0]];
                    foreach (var room in department.OrderBy(x => x.Key))
                    {
                        foreach (var patient in room.Value)
                        {
                            if (patient != null)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
                else
                {
                    int roomNumber;
                    var isNum = int.TryParse(input[1], out roomNumber);
                    if (isNum)
                    {
                        var department = departments[input[0]];

                        if (department.ContainsKey(roomNumber))
                        {
                            foreach (var patient in department[roomNumber].OrderBy(p => p))
                            {
                                if (patient != null)
                                {
                                    Console.WriteLine(patient);
                                }
                            }
                        }

                    }
                    else
                    {
                        var doctor = input[0] + " " + input[1];
                        if (doctors.ContainsKey(doctor))
                        {
                            foreach (var patient in doctors[doctor].OrderBy(p => p))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }
        }
    }
}
