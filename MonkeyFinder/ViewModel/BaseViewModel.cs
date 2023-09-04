namespace MonkeyFinder.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {
        //this.i
        //SetProperty(ref isBusy, true);
    }
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    

    public bool IsNotBusy => !IsBusy;
}
