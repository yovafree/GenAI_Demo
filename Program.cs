using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

string keyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

AzureOpenAIClient azureClient = new(
    new Uri("https://genaitcd24.openai.azure.com"),
    new AzureKeyCredential(keyFromEnvironment));
ChatClient chatClient = azureClient.GetChatClient("gpt-4o");

ChatCompletion completion = chatClient.CompleteChat(
    [
        // Los mensajes del sistema representan instrucciones u otra orientación sobre cómo debe comportarse el asistente.
        new SystemChatMessage("Eres un asistente útil que habla como un pirata."),
        // Los mensajes de usuario representan la entrada del usuario, ya sea histórica o la entrada más reciente.
        new UserChatMessage("Hola, ¿puedes ayudarme?"),
        // Los mensajes del asistente en una solicitud representan el historial de conversación para respuestas.
        new AssistantChatMessage("¡Arrr! ¡Por supuesto, compañero! ¿Qué puedo hacer por ti?"),
        new UserChatMessage("¿Cuál es la mejor manera de entrenar a un loro?"),

    ]);

Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");