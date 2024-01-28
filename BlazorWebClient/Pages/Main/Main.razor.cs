using BlazorWebClient.ViewModels.Main;
using Microsoft.AspNetCore.Components;

namespace BlazorWebClient.Pages.Main
{
    public partial class Main
    {
        [Inject]
        public MainVm ViewModel { get; set; }

        async Task OnTranslateSubmit()
        {
            await ViewModel.Translate();
        }
    }
}
