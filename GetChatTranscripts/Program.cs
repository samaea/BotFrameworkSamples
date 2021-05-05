using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure.Blobs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GetChatTranscripts
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var conversationId = "";
            var channelId = "directline";
            ITranscriptStore store = new BlobsTranscriptStore(ConfigurationManager.AppSettings["AzureStorageConnectionString"], ConfigurationManager.AppSettings["AzureBlobStorageContainer"]);
            var transcripts = await store.GetTranscriptActivitiesAsync(channelId,
conversationId);
            Transcript transcript = new Transcript(transcripts.Items.ToList().ConvertAll(o => (Activity)o));

            // Displaying list of activities into a string

            foreach (var transcriptEntity in transcript.Activities)
            {
                Console.WriteLine("From:- " + transcriptEntity.From.Name + " Message:- " + transcriptEntity.Text);  
            }

            Console.ReadKey();
        }
        

    }
}
