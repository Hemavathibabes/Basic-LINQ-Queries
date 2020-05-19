using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Listexample
{
    //specify a data source
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

            };
            //query expressions
            //select only one element 
           var peopleinchennai = (from stu in sd
                                       where stu.s_city == "chennai"
                                       select stu.name);


            //using OR ,AND operators
             var peopleinchennai = (from stu in sd
                                    where stu.s_city == "chennai" && stu.s_city=="kanchipuram" || stu.s_city=="Madurai"
                                    select stu.name);


             //seclect more than one elements
             var peopleinchennai = ( from stu in sd
                                      where stu.s_city=="chennai"
                  select new { Name = stu.name, Id = stu.s_id });


              //concadination
             var peopleinchennai = (from stu in sd
                                     where stu.s_city == "chennai"
                                     select stu.name)
                                      .Concat(from tea in td
                                              where tea.t_city == "chennai"
                                              select tea.t_name);



            //show the results
            Console.WriteLine("Basic operations");
            foreach (var pc in peopleinchennai)
            {
                
                Console.WriteLine(pc + " ");
            }


            //ordering in a ascending by a student name
            var orderbyname = (from stu in sd
                               where stu.s_city == "chennai"
                               orderby stu.name ascending
                               select stu.name);


            Console.WriteLine("Ordering");
            foreach (var oc in orderbyname)
            {
                
                Console.WriteLine(oc + " ");
            }

            //Grouping by a city name
            var groupbycity = from stu in sd
                              group stu by stu.s_city;

            Console.WriteLine("grouping");
            foreach (var gc in groupbycity)
            {
                Console.WriteLine(gc.Key);
               
                foreach (Student   city in gc)
                {
                   
                    Console.WriteLine("  *"+ city.name);
                }
            }

            //Joining the two classes
            var innerjoin =from stu in sd 
                           join tea in td
                           on stu.s_city equals tea.t_city
                           select  new
                           {
                               Studentname = stu.name,
                               Teachername = tea.t_name
                           };


            Console.WriteLine("Inner join");
            foreach (var ij in innerjoin)
            {
              
                Console.WriteLine(ij + " ");
            }

        }
    }
}
