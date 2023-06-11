namespace TineMCEDemo;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnHybridWebViewRawMessageReceived(object sender, HybridWebView.HybridWebViewRawMessageReceivedEventArgs e)
    {
        await Dispatcher.DispatchAsync(async () =>
        {
            if (e.Message.StartsWith("PAGE_LOADING"))
                _ = await myHybridWebView.EvaluateJavaScriptAsync($"SendToJs('{DescriptionHiddenEntry.Text}')");
            // _ = await myHybridWebView.EvaluateJavaScriptAsync($"SendToJs('<p>Some Random text by <b>Adin</b></p>')");
            if (e.Message.StartsWith("NEW_CONTENT"))
                DescriptionHiddenEntry.Text = e.Message.Substring("NEW_CONTENT".Length);
            //await DisplayAlert("JavaScript message", e.Message, "OK");//At this point I would fill a hidden field that is linked to a Model in VIEWModel class
        });
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }














    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

