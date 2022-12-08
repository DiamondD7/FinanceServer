using System.ComponentModel.DataAnnotations;

namespace server.Model
{
    public class FinanceTracker
    {
        //data associated with the MS SQL values

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

    }
}
