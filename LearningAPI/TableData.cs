using System.ComponentModel.DataAnnotations;

namespace LearningAPI
{
    public class TableData
    {
        [Key]
        public int TableId { get; set; }

        public string TableName { get; set; }

        public string TablePKName { get; set; }
        public string TableColumns { get; set; }

        public string SchemaName { get; set; }
        public bool IsActive { get; set; }
    }
}
