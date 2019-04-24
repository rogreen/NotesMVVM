using Notes.Models;
using Notes.ViewModels;
using System;
using Xamarin.Forms;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        private NotesViewModel viewModel;

        public NotesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NotesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadNotesCommand.Execute(null);
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage(
                new NoteViewModel(
                    new Note())
                    ));
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage(
                    new NoteViewModel(
                        (Note)e.SelectedItem)
                        ));
            }
        }
    }
}