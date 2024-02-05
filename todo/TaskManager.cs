namespace todo
{
    public class TaskManager
    {
       static List<Task> Tasks = new List<Task>();

        public Task Add(Task task){
            Tasks.Add(task);
            return task;
        }

        public List<Task> GetAll(){
            return Tasks;
        }

        public Task Get(int id){
            foreach(var task in Tasks){
                if(task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        public Task Edit(int id, Task editedTask){
            foreach(var task in Tasks){
                if(task.Id == id)
                {
                    task.Name = editedTask.Name;
                    task.Date = editedTask.Date;
                    return task;
                }
            }
            return null;
        }

        public bool Delete(int id){

            var task = Get(id);
            if(task != null){
                Tasks.Remove(task);
                return true;
            }
            return false;
        }
    }
}