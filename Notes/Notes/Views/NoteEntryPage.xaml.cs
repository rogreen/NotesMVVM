using Notes.ViewModels;
using System;
using Xamarin.Forms;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        NoteViewModel viewModel;

        public NoteEntryPage(NoteViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            viewModel.SaveNoteCommand.Execute(null);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            viewModel.DeleteNoteCommand.Execute(null);
            await Navigation.PopAsync();
        }
    }
}