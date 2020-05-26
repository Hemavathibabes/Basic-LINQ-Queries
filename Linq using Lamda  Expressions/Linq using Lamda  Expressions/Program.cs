using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_using_Lamda__Expressions
{
    class Student
    {
        public int s_id { get; set; }

        public String name { get; set; }
        public String s_city { get; set; }
        public List<int> mark { get; set; }



    }
    class Teacher
    {
        public int t_id { get; set; }
        public String t_name { get; set; }
        public String t_city { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> sd = new List<Student>()
            {
                new Student
                {
                      s_id=101,
                      name = "hema",
                      s_city = "chennai",
                      mark = new List<int> { 12, 13, 14, 15 }
                      },
                new Student
            {
                     s_id=102,
                      name = "baby",
                      s_city = "kanchipuram",
                      mark = new List<int> { 12, 11, 19, 15 }


                },
                new Student
            {
                     s_id=103,
                      name = "pavithra",
                      s_city = "chennai",
                      mark = new List<int> { 12, 12, 10, 15 }


                },
                new Student
            {
                     s_id=104,
                      name = "karthiga",
                      s_city = "kanchipuram",
                      mark = new List<int> { 10, 12, 19, 15 }


                },
                 new Student
            {
                     s_id=105,
                      name = "Karthik",
                      s_city = "kanchipuram",
                      mark = new List<int> { 10, 12, 10, 15 }


                },
                  new Student
            {
                     s_id=105,
                      name = "jessi",
                      s_city = "chennai",
                      mark = new List<int> { 80, 67, 12, 15 }


                },
                   new Student
            {
                     s_id=106,
                      name = "Ram",
                      s_city = "chennai",
                      mark = new List<int> { 20, 12, 13, 15 }


                }
            };

            List<Teacher> td = new List<Teacher>()
            {
                new Teacher
                {
                    t_id=201,
                    t_name="anandan",
                    t_city="chennai"

                },
                new Teacher
                {
                    t_id=202,
                    t_name="banu",
                    t_city="kanchipuram"

                },
                new Teacher
                {
                    t_id=203,
                    t_name="Lingu",
                    t_city="chennai"

                },
                new Teacher
                {
                    t_id=204,
                    t_name="latha",
                    t_city="chengalpatu"

                },
                new Teacher
                {
                    t_id=205,
                    t_name="mano",
                    t_city="mumbai"

                },
                new Teacher
                {
                    t_id=206,
                    t_name="Lakshmi",
                    t_city="kanchipuram"

                }

            };

            //using a lamda expressions

            //display a variables
            var peopleinchennai = sd.Where(s => s.s_city == "chennai");

            foreach(var pc in peopleinchennai)
            {
                Console.WriteLine(pc.s_id + " " + pc.name + " " + pc.s_city + " "  );
            }

            //select a particular variable

            var names = sd.Select(s => s.name);
            foreach (var pc in names)
            {
                Console.WriteLine( pc + " " );
            }

            //ordering the elements

            IEnumerable<Student> orderanames = sd.Where(s=>s.s_city=="chennai").OrderBy(s => s.name);

            foreach (var on in orderanames)
            {
                Console.WriteLine(on.s_id + " " + on.name + " " + on.s_city + " ");
            }

            //ordering the elements in descending order

            IEnumerable<Student> orderaname = sd.Where(s => s.s_city == "chennai").OrderByDescending(s => s.name).Take(1);

            foreach (var on in orderaname)
            {
                Console.WriteLine(on.s_id + " " + on.name + " " + on.s_city + " ");
            }

            //Take() function

            IEnumerable<Student> take = sd.Where(s => s.s_city == "chennai").OrderByDescending(s => s.name).Take(1);

            foreach (var on in take)
            {
                Console.WriteLine(on.s_id + " " + on.name + " " + on.s_city + " ");
            }

            //join operation
            var joinquery = sd.Join(td, s => s.s_city, t => t.t_city, (s, t) => new
            {
                s.s_id, s.name, t.t_id, t.t_name
            });

            foreach (var jq in joinquery)
            {
                Console.WriteLine(jq + " ");
            }

        }
    }
}
