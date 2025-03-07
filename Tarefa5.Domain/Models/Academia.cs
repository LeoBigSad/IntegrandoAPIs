using Tarefa5.Domain.Entity;

namespace Tarefa5.Domain.Models
{
    public class Academia : Base
    {
        public string Name { get; set; }
        public ICollection<Aparelho>? aparelho { get; set; }
    }
}
