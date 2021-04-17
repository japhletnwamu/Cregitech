using System;
using static System.Environment;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Net;

namespace Face_Recognition
{
    static async class Main(){
        var faceClient = GetFaceClient();

        var url = "https://docs.microsoft.com/en-us/learn/data-ai-cert/identify-faces-with-computer-vision/media/clo19_ubisoft_azure_068.png";

        var attributes = new FaceAttributeType[] {
            FaceAttributeType.Emotion,
            FaceAttributeType.Glasses,
            FaceAttributeType.Smile
        };
        bool includeId = true;
        bool includeLandmarks = false;

        var result = await faceClient.Face.DetectWithUrlAsync(url, includeId, includeLandmarks, attributes);
        Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    }

    public static class GetFaceClient()
    {
        var serviceEndpoint = GetEnvironmentVariable("https://face-recog-demo.cognitiveservices.azure.com/");
        var subscriptionKey = GetEnvironmentVariable("4976d85b396545179b96455d76690c69");
        var credential = new ApiKeyServiceClientCredentials(subscriptionKey);
        return FaceClient(credential) { EndPoint = serviceEndpoint }
    }

}
    


