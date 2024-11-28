namespace HomeWork9
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            var first = true;
            while (true)
            {
                if (first)
                {
                    // var tree = ManualEntering();
                    tree = AutoCreate();
                    BinaryTree.TraverseTree(tree);
                    FindEmployeeBySalary(tree);
                    first = false;
                }
                else
                {
                    Console.WriteLine("Please enter 0 to go to the beginning of the program or 1 to search for salary");
                    var input = Console.ReadLine();
                    if (input == "0")
                    {
                        tree = AutoCreate();
                        BinaryTree.TraverseTree(tree);
                        FindEmployeeBySalary(tree);
                    } else if (input == "1")
                    {
                        FindEmployeeBySalary(tree);
                    }
                }
            }
        }

        public static BinaryTree ManualEntering()
        {
            var tree = new BinaryTree();
            while (true)
            {
                Console.WriteLine("Please enter the employee's name");
                String employee = Console.ReadLine();
                if (employee == "") break;
                while (true)
                {
                    Console.WriteLine("Please enter the salary");
                    String salaryText = Console.ReadLine();
                    if (!int.TryParse(salaryText, out int salary))
                    {
                        Console.WriteLine("this is not integer");
                        continue;
                    }
                    tree.Add(employee, salary);
                    break;
                }

            }
            return tree;
        }

        public static BinaryTree AutoCreate()
        {
            var tree = new BinaryTree();
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(i.ToString(), random.Next(100));
            }
            return tree;
        }

        public static void FindEmployeeBySalary(BinaryTree tree)
        {
           Console.WriteLine("enter salary to search");
           var input = Console.ReadLine();
           if (input == "") return;
           if (int.TryParse(input, out int salary))
           {
               var result = BinaryTree.FindNode(tree, salary);
               if (result != null)
               {
                   Console.WriteLine($"employee with the specified salary : {result.TextValue}");
               }
               else
               {
                   Console.WriteLine("employee doesn't exist");
               }
           }
        }
    }
}
