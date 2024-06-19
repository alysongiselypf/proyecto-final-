using System;

namespace MAUI.Notes.Models
{
    internal class Note
    {
        //nombre
        public string FileName { get; set; } = string.Empty;
        //texto
        public string Text { get; set; } = string.Empty;
        //fecha
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

