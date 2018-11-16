using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LearnPhotoApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace LearnPhotoApp.Managers
{
    public class PhotoManagerApi : IPhotoManagerApi
    {
        private readonly MobileServiceClient _client;
        public PhotoManagerApi()
        {
            _client = new MobileServiceClient(Constants.MobileAppUrl);
        }

        public async Task<IEnumerable<Photo>> GetMyPhotos()
        {
            return await _client.InvokeApiAsync<IEnumerable<Photo>>("PhotoModels", HttpMethod.Get, null);
        }

        public async Task<bool> PutPhotoToStorage(string photoPath)
        {
            try
            {
                var fileName = Path.GetFileName(photoPath);
                CloudStorageAccount storage = CloudStorageAccount.Parse(@"YOUR_KEY");
                CloudBlobClient blobClient = storage.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("YOUR_BLOB_CONTAINER_NAME");

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                await blockBlob.UploadFromFileAsync(photoPath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task<int> InsertPhoto(string fileName)
        {
            var file = Path.GetFileName(fileName);
            Photo p = new Photo
            {
                PhotoName = file
            };           
            return await _client.InvokeApiAsync<Photo, int>("PhotoModels", p, HttpMethod.Post, null);
        }
    }
}
