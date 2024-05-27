using Exercise6.Models;

namespace Exercise6
{
    public static class LinqTasks
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        static LinqTasks()
        {
            #region Load depts

            List<Dept> depts =
            [
                new Dept
                {
                    Deptno = 1,
                    Dname = "Research",
                    Loc = "Warsaw"
                },
                new Dept
                {
                    Deptno = 2,
                    Dname = "Human Resources",
                    Loc = "New York"
                },
                new Dept
                {
                    Deptno = 3,
                    Dname = "IT",
                    Loc = "Los Angeles"
                }
            ];

            Depts = depts;

            #endregion

            #region Load emps

            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            List<Emp> emps =
            [
                e1, e2, e3, e4, e5, e6, e7, e8, e9, e10
            ];

            Emps = emps;

            #endregion
        }

        /// <summary>
        ///     SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public static IEnumerable<Emp> Task1()
        {
            // Method syntax
            var methodSyntax = 
                Emps
                    .Where(e => e.Job.Equals("Backend programmer"));
            
            // Query syntax
            var querySyntax =
                from e in Emps
                where e.Job.Equals("Backend programmer") 
                select e;
            
            IEnumerable<Emp> result = querySyntax;
            return result;
        }

        /// <summary>
        ///     SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public static IEnumerable<Emp> Task2()
        {
            // Method syntax
            var methodSyntax = 
                Emps
                    .Where(e => e.Job.Equals("Frontend programmer") && e.Salary > 1000)
                    .OrderByDescending(e => e.Ename);
            
            // Query syntax
            var querySyntax =
                from e in Emps
                where e.Job.Equals("Frontend programmer") && e.Salary > 1000
                orderby e.Ename descending
                select e;

            IEnumerable<Emp> result = querySyntax;
            return result;
        }


        /// <summary>
        ///     SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public static int Task3()
        {
            // Method syntax
            var methodSyntax =
                Emps
                    .Max(e => e.Salary);
            
            // Query syntax
            var querySyntax = (from e in Emps
                select e.Salary).Max();


            var result = querySyntax;
            return result;
        }

        /// <summary>
        ///     SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public static IEnumerable<Emp> Task4()
        {
            // Method syntax
            var maxSalary = Emps.Max(e => e.Salary);
            var methodSyntax = Emps.Where(e => e.Salary == maxSalary);
            
            // Query syntax
            var querySyntax =
                from e in Emps
                where e.Salary.Equals(maxSalary)
                select e;

            IEnumerable<Emp> result = querySyntax;
            return result;
        }

        /// <summary>
        ///    SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public static IEnumerable<object> Task5()
        {
            // Method syntax
            var methodSyntax = 
                Emps.Select(e => new { Nazwisko = e.Ename, Praca = e.Job });
            
            // Query syntax
            var querySyntax =
                from e in Emps
                select new { Nazwisko = e.Ename, Praca = e.Job };
            
            IEnumerable<object> result = querySyntax;
            return result;
        }

        /// <summary>
        ///     SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        ///     INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        ///     Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public static IEnumerable<object> Task6()
        {
            // Method syntax
            var methodSyntax = Emps
                .Join(Depts,
                    emp => emp.Deptno,
                    dept => dept.Deptno,
                    (emp, dept) => new { Ename = emp.Ename, Job = emp.Job, Dname = dept.Dname });

            
            // Query syntax
            var querySyntax = from emp in Emps
                join dept in Depts on emp.Deptno equals dept.Deptno
                select new { emp.Ename, emp.Job, dept.Dname };

            IEnumerable<object> result = querySyntax;
            return result;

        }

        /// <summary>
        ///     SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public static IEnumerable<object> Task7()
        {
            // method syntax
            var methodSyntax = Emps
                .GroupBy(emp => emp.Job)
                .Select(group => new { Praca = group.Key, LiczbaPracownikow = group.Count() });

            // query syntax
            var querySyntax = from emp in Emps
                group emp by emp.Job into grouped
                select new { Praca = grouped.Key, LiczbaPracownikow = grouped.Count() };

            IEnumerable<object> result = querySyntax;
            return result;

        }

        /// <summary>
        ///     Zwróć wartość "true" jeśli choć jeden
        ///     z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public static bool Task8()
        {
            
            // method syntax 
            var methodSyntax = Emps.Any(emp => emp.Job == "Backend programmer");

            // query syntax
            var querySyntax = (from emp in Emps
                where emp.Job == "Backend programmer"
                select emp).Any();
            
            
            bool result = querySyntax;
            return result;
        }

        /// <summary>
        ///     SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        ///     ORDER BY HireDate DESC;
        /// </summary>
        public static Emp Task9()
        {
            
            //method syntax
            var methodSyntax = Emps
                .Where(emp => emp.Job == "Frontend programmer")
                .OrderByDescending(emp => emp.HireDate)
                .FirstOrDefault();
            
            // query syntax

            var querySyntax = (from emp in Emps
                where emp.Job == "Frontend programmer"
                orderby emp.HireDate descending
                select emp).FirstOrDefault();
            
            Emp result = querySyntax;
            return result;
        }

        /// <summary>
        ///     SELECT Ename, Job, Hiredate FROM Emps
        ///     UNION
        ///     SELECT "Brak wartości", null, null;
        /// </summary>
        public static IEnumerable<object> Task10()
        {
            
            // method syntax
            var methodSyntax = Emps
                .Select(emp => new { emp.Ename, emp.Job, emp.HireDate })
                .Union(new[] { new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null } });

            // query syntax
            
            var querySyntax = (from emp in Emps
                    select new { emp.Ename, emp.Job, emp.HireDate })
                .Union(new[] { new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null } });

            IEnumerable<object> result = querySyntax;
            return result;
        }

        /// <summary>
        /// Wykorzystując LINQ pobierz pracowników podzielony na departamenty pamiętając, że:
        /// 1. Interesują nas tylko departamenty z liczbą pracowników powyżej 1
        /// 2. Chcemy zwrócić listę obiektów o następującej srukturze:
        ///    [
        ///      {name: "RESEARCH", numOfEmployees: 3},
        ///      {name: "SALES", numOfEmployees: 5},
        ///      ...
        ///    ]
        /// 3. Wykorzystaj typy anonimowe
        /// </summary>
        public static IEnumerable<object> Task11()
        {
            
            //method syntax
            var methodSyntax = Emps.GroupBy(emp => emp.Deptno)
                .Where(group => group.Count() > 1)
                .Select(group => new
                {
                    name = Depts.First(dept => dept.Deptno == group.Key)?.Dname,
                    numOfEmployees = group.Count()
                });
            

            IEnumerable<object> result = methodSyntax;
            return result;
        }

        /// <summary>
        /// Napisz własną metodę rozszerzeń, która pozwoli skompilować się poniższemu fragmentowi kodu.
        /// Metodę dodaj do klasy CustomExtensionMethods, która zdefiniowana jest poniżej.
        /// 
        /// Metoda powinna zwrócić tylko tych pracowników, którzy mają min. 1 bezpośredniego podwładnego.
        /// Pracownicy powinny w ramach kolekcji być posortowani po nazwisku (rosnąco) i pensji (malejąco).
        /// </summary>
        public static IEnumerable<Emp> Task12()
        {
            return Emps.AtLeastOneEmp();
        }

        /// <summary>
        /// Poniższa metoda powinna zwracać pojedyczną liczbę int.
        /// Na wejściu przyjmujemy listę liczb całkowitych.
        /// Spróbuj z pomocą LINQ'a odnaleźć tę liczbę, które występuja w tablicy int'ów nieparzystą liczbę razy.
        /// Zakładamy, że zawsze będzie jedna taka liczba.
        /// Np: {1,1,1,1,1,1,10,1,1,1,1} => 10
        /// </summary>
        public static int Task13(int[] arr)
        {
            int result = arr.GroupBy(x => x)
                .Where(group => group.Count() % 2 != 0)
                .Select(group => group.Key)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Zwróć tylko te departamenty, które mają 5 pracowników lub nie mają pracowników w ogóle.
        /// Posortuj rezultat po nazwie departament rosnąco.
        /// </summary>
        public static IEnumerable<Dept> Task14()
        {
            
            // method syntax
            var methodSyntax = Depts.GroupJoin(Emps,
                dept => dept.Deptno,
                emp => emp.Deptno,
                (dept, emp) => new
                {
                    Dept = dept,
                    EmpCount = emp.Count()
                }).Where(de => de.EmpCount == 5 || de.EmpCount == 0)
                .Select(de => de.Dept)
                .OrderBy(de => de.Dname);;
            

            
            IEnumerable<Dept> result = methodSyntax;
            //result =
            return result;
        }
    }

    public static class CustomExtensionMethods
    {
        public static IEnumerable<Emp> AtLeastOneEmp(this IEnumerable<Emp> emps)
        {
            return emps
                .Where(emp => emps.Any(e => e.Mgr == emp)) 
                .OrderBy(emp => emp.Ename)
                .ThenByDescending(emp => emp.Salary);
        }
        
    }
}