using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

public static void Run(Stream myBlob, Stream outputBlob, TraceWriter log)
{
    int width = 320;
    int height = 320;
    bool smartCropping = true;
    string _apiKey = ConfigurationManager.AppSettings["ComputerVisionKey"];
    string _apiUrlBase = "https://api.projectoxford.ai/vision/v1.0/generateThumbnail";
    Stream stream = new MemoryStream();

    using (var httpClient = new HttpClient())
    {
        httpClient.BaseAddress = new Uri(_apiUrlBase);
        httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
        using (HttpContent content = new StreamContent(myBlob))
        {
            //get response
            content.Headers.ContentType.Add = new MediaTypeWithQualityHeaderValue("application/octet-stream");
            var uri = $"{_apiUrlBase}?width={width}&height={height}&smartCropping={smartCropping.ToString()}";
            var response = httpClient.PostAsync(uri, content).Result;
            var responseBytes = response.Content.ReadAsByteArrayAsync().Result;
            
            //write to output thumb
            outputBlob.Write(responseBytes, 0, responseBytes.Length);
        }
    }    
}
