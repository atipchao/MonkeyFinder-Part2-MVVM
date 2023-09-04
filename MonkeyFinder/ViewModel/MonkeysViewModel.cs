using MonkeyFinder.Services;
namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    //Getting list of monkey(s) from the internet - DB access, File access, or Internet web-service call
    //Basically, we are gonna call a service - we need to give  collection-view some sort of DataType to do DataBinding into..
    
    MonkeyService monkeyService;
    // Basically, this is an Obserable List of Monkey
    public ObservableCollection<Monkey> Monkeys { get; } = new(); 
    
    //we inject monkeyService into viewModel here... 
    public MonkeysViewModel(MonkeyService  monkeyService_from_DI)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService_from_DI;        
    }

    [RelayCommand] // this turns  GetMonkeyAsync() into a Command
    async Task GetMonkeyAsync()
    {
        if (IsBusy) // if someone jams on button so many times... AS
            return;
        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();
            // Now we put the Monkeys into the LIST
            if(Monkeys.Count != 0)
            {
                Monkeys.Clear();
            }
            foreach(var monkey in monkeys)
            {
                //Monkeys.Add(monkey);
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", 
                $"Unable to get Monkeys: {ex.Message}", "OK");
            //throw;
        }
        finally
        {
            IsBusy = false;
        }
    }
}
