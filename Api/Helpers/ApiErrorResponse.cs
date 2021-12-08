

using Newtonsoft.Json;

namespace Api.Helpers
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
        public object ArrayMessage { get; }
        public ApiErrorResponse(int statusCode, string message = null, object arrayMessage = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            ArrayMessage = arrayMessage;
        }
        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return "Não autorizado (não autenticado)";
                case 404:
                    return "Recurso não encontrado";
                case 405:
                    return "Método não permitido";
                case 500:
                    return "Um erro não tratado ocorreu no request";
                default:
                    return null;
            }
        }
    }
}
