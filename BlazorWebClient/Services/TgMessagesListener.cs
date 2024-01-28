using BlazorWebClient.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using TL;
using WTelegram;

namespace BlazorWebClient.Services
{
    public class TgMessagesListener : BackgroundService
    {
        private readonly ITranslateService _translateService;
        private Client tgClient;
        private User My;

        public TgMessagesListener(ITranslateService translateService)
        {
            _translateService = translateService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            tgClient = new Client(GetConfig);

            My = await tgClient.LoginUserIfNeeded();
            tgClient.OnUpdate += OnUpdate;
        }

        string GetConfig(string key)
        {
            string result = string.Empty;

            switch (key)
            {
                case "phone_number":
                    {
                        result = "380953243078";

                        break;
                    }
                case "api_id":
                    {
                        return "20624831";
                    }
                case "api_hash":
                    {
                        return "4743b71494e7925b554b5175750d8eab";
                    }
                case "verification_code":
                    {
                        return "72190";
                    }
                case "password":
                    {
                        return "Lol23334";
                    }
                default:
                    {
                        return null!;
                    }
            }

            return result;
        }

        async Task OnUpdate(UpdatesBase updates)
        {
            if (updates != null)
            {
                foreach (var item in updates.UpdateList)
                {
                    try
                    {
                        switch (item)
                        {
                            case UpdateNewMessage unm:
                                {
                                    var message = unm.message as Message;

                                    if(message != null && !string.IsNullOrEmpty(message.message) && message.Peer is PeerUser)
                                    {
                                        var peer = message.Peer as PeerUser;

                                        string translatedText = await _translateService.TranslateTextAsync(message.message);

                                        var dialogs = await tgClient.Messages_GetAllDialogs();
                                        await tgClient.SendMessageAsync(dialogs.users[peer.user_id], translatedText);
                                    }

                                    break;
                                }
                            case UpdateEditMessage uem:
                                {
                                    var message = uem.message as Message;

                                    if (message != null && !string.IsNullOrEmpty(message.message) && message.Peer is PeerUser)
                                    {
                                        var peer = message.Peer as PeerUser;

                                        string translatedText = await _translateService.TranslateTextAsync(message.message);

                                        var dialogs = await tgClient.Messages_GetAllDialogs();
                                        await tgClient.SendMessageAsync(dialogs.users[peer.user_id], translatedText);
                                    }

                                    break;
                                }
                        }
                    }
                    catch (Exception exception)
                    {

                    }
                }
            }
        }
    }
}
