namespace Webdemo.Models
{
    public class Repository
    {
        private static List<Employee>allemployees = new List<Employee>();

        public static IEnumerable<Employee> AllEmployees
        {
            get { return allemployees; }
        }

        public static void  Create(Employee employee)
        {
            allemployees.Add(employee);
        }

        public static void Delete(Employee employee)
        {
            allemployees.Remove(employee);
        }
    }
}
