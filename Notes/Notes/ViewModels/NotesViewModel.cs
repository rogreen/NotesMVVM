using Notes.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes.ViewModels
{
    class NotesViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }

        public Command LoadNotesCommand { get; set; }

        public NotesViewModel()
        {
            Title = "Notes";
            Notes = new ObservableCollection<Note>();

            LoadNotesCommand = new Command(async () => await ExecuteLoadNotesCommand());
        }
        async Task ExecuteLoadNotesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notes.Clear();
                var notes = await App.Database.GetNotesAsync();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
