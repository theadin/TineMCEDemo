using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TineMCEDemo;
public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string myDescription;

    public MainPageViewModel()
    {
        MyDescription = "Hello, <b>World</b>!";
    }
}
