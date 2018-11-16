# LearnPhotoApp
in PhotoManagerApi.cs please change following strings

CloudStorageAccount storage = CloudStorageAccount.Parse(@"YOUR_KEY");
CloudBlobContainer container = blobClient.GetContainerReference("YOUR_BLOB_CONTAINER_NAME");

in Constants.cs change web api url

public static string MobileAppUrl = @"YOUR_WEB_API";
