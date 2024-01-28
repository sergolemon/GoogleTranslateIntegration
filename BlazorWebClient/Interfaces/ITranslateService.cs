namespace BlazorWebClient.Interfaces
{
    public interface ITranslateService
    {
        Task<string> TranslateTextAsync(string text);
    }
}
