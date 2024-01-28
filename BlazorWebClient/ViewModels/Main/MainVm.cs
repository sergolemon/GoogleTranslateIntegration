using BlazorWebClient.Interfaces;

namespace BlazorWebClient.ViewModels.Main
{
    public class MainVm
    {
        private readonly ITranslateService _translateService;

        public MainVm(ITranslateService translateService)
        {
            _translateService = translateService;
        }

        public string SourceText { get; set; } = string.Empty;
        public string TranslatedText { get; set; } = string.Empty;

        public async Task Translate()
        {
            TranslatedText = await _translateService.TranslateTextAsync(SourceText);
        }
    }
}
