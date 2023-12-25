namespace IntuitClientes.CrossCutting.Base
{
    public class BaseRestResponse
    {
        //
        // Summary:
        //     HTTP response status code
        public System.Net.HttpStatusCode StatusCode { get; set; }

        // Summary:
        //     Description of HTTP status returned
        public string StatusDescription { get; set; } = string.Empty;
    }
}