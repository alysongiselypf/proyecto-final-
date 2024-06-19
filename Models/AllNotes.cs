using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Notes.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        
        public AllNotes() => LoadNotes();
        public void LoadNotes()
        {
            Notes.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            // Enumera todos los archivos con la extensión '.notes.txt' en el directorio de datos de la aplicación.
            IEnumerable<Note> notes = Directory
                        .EnumerateFiles(appDataPath, "*.notes.txt")
                        .Select(filename => new Note()
                        {
                            // Crea un objeto 'Note' para cada archivo, estableciendo sus propiedades.
                            FileName = filename,
                            Text = File.ReadAllText(filename),
                            Date = File.GetLastWriteTime(filename)
                        })
                        // Ordena las notas por la fecha de última modificación.
                        .OrderBy(note => note.Date);

            foreach (var note in notes)
                Notes.Add(note);
        }
    
    }

}
