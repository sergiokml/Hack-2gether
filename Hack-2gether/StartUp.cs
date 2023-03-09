using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;

namespace Hack_2gether
{
    internal class StartUp
    {
        public async Task Start()
        {
            try
            {
                // CLIENT
                GraphServiceClient? graphClient = new Auth().TokenAuth()!;

                // UPLOAD FILE
                DriveCollectionResponse? drives = await graphClient!.Drives.GetAsync();
                FileStream stream = File.Open(@"C:\Users\DevPc\Downloads\Hack Together Microsoft Graph and .NET Calendar.ics", FileMode.Open);
                Drive? id = drives!.Value!.FirstOrDefault();
                await graphClient.Drives[id!.Id].Root
                   .ItemWithPath("Hack Together Microsoft Graph and .NET Calendar.ics")
                   .Content.PutAsync(stream, null, new CancellationToken());

            }
            catch (ODataError odataError)
            {
                Console.WriteLine(odataError.Error!.Code);
                Console.WriteLine(odataError.Error.Message);
                throw;
            }
        }
    }
}
