using System.ComponentModel.DataAnnotations;

namespace LearningAPI
{
    public class SPData
    {
        [Key]
        public int SPId { get; set; }

        public string SPName { get; set; }

        public string SchemaName { get; set; }
        public bool IsActive { get; set; }
    }
}
