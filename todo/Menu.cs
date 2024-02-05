namespace todo
{
    public class Menu
    {
        TaskManager _manager = new TaskManager();
        public void MainMenu(){
            Console.WriteLine("Todo List");
            bool cont = true;
            while(cont){
                Console.WriteLine("1. Add Tasks");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Edit Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("0. Exit");

                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                    AddTask();
                    break;
                    case 2:
                    ViewTask();
                    break;
                    case 3:
                    Edit();
                    break;
                    case 4:
                    break;
                    case 0:
                    cont =  false;
                    break;
                    default:
                    Console.WriteLine("Invalid Input");
                    break;
                };
            }

        }

        private void AddTask(){
            Console.Write("Enter Task: ");
            string name = Console.ReadLine();

            Console.Write("Enter Date to carry out task (yyyy-MM-dd): ");
            string input = Console.ReadLine();  
            if (DateTime.TryParse(input, out DateTime date))
            {
                Task task = new Task(_manager.GetAll().Count+1, name, date);
                if(_manager.Add(task) != null){
                    Console.WriteLine($"Task {task.Name} successfully Added!");
                }
                else{
                    Console.WriteLine("An error occured while adding Task!");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a date in yyyy-MM-dd format.");
            }
        }

        private void ViewTask(bool isView = true){
            var tasks = _manager.GetAll();
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i+1}. {tasks[i].Name}\t-\t{tasks[i].Date.ToString("dddd d, MMMM, yyyy")}");
            }

            if(isView){
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void Edit(){
            ViewTask(false);
            Console.Write("Enter No. of Task to Edit: ");
            int input = int.Parse(Console.ReadLine());

            if(input > _manager.GetAll().Count){
                Console.WriteLine("Invalid Input");
                return;
            }

            Console.Write("Enter new Task: ");
            string name = Console.ReadLine();

            Console.Write("Enter new Date to carry out task (yyyy-MM-dd): ");
            string dateString = Console.ReadLine();  

            
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                var task = _manager.GetAll()[input-1];
                task.Name = name;
                task.Date = date;
                
                if(_manager.Edit(task.Id, task) != null){
                    Console.WriteLine($"Task {task.Name} successfully Edited!");
                }
                else{
                    Console.WriteLine("An error occured while editing Task!");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a date in yyyy-MM-dd format.");
            }
        }
    }
}