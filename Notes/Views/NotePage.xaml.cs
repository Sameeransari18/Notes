namespace Notes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
        await Shell.Current.DisplayAlert("Notes", "Your notes has been saved", "OK");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {

        bool answer = await DisplayAlert("Are you sure?", "Do you want to delete?", "Yes", "No");
        
        if (answer)
        {
            if (BindingContext is Models.Note note)
            {
                // Delete the file.
                if (File.Exists(note.Filename))
                    File.Delete(note.Filename);
            }
            await Shell.Current.GoToAsync("..");
        }
       
    }

    private void LoadNote(string fileName)
    {
        Models.Note noteModel = new Models.Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }

}