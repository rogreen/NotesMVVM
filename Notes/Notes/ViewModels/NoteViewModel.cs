using Notes.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public Command SaveNoteCommand { get; set; }
        public Command DeleteNoteCommand { get; set; }

        public NoteViewModel(Note note = null)
        {
            Title = note?.Text;
            Note = note;

            SaveNoteCommand = new Command(async () => await ExecuteSaveNoteCommand());
            DeleteNoteCommand = new Command(async () => await ExecuteDeleteNoteCommand());
        }

        async Task ExecuteSaveNoteCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Note.Date = DateTime.UtcNow;
                await App.Database.SaveNoteAsync(Note);
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

        async Task ExecuteDeleteNoteCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await App.Database.DeleteNoteAsync(Note);
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
