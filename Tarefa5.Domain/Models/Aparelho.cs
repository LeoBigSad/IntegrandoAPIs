using Tarefa5.Domain.Entity;

namespace Tarefa5.Domain.Models
{
    public class Aparelho : Base
    {
        public string Name { get; set; }
        public Academia? Academia { get; set; }
    }
}
