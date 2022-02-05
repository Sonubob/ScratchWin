using System;

namespace ScratchWin.Models
{
    public class Item
    {
        [SQLite.PrimaryKey]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public bool IsOpened { get; set; }
        public DateTime DateOpened { get; set; }
    }
}