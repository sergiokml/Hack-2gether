# Hack-2gether

## Introduction

Console application .Net 7.0 with DI
User with authentication "App-only access (access without a user)"

Upload file to default site of SharePoint Site (Shared Documents), and then download it.

###### Step 1 : Register the app in Azure with a "basic" user of AD organization.
[recording-2023-03-13-16-51-44.webm](https://user-images.githubusercontent.com/6364350/224755469-f903ce04-7f3a-4e89-9ac3-c8115cba5831.webm)



###### Step 2 : Apply "Admin consent required" with the "admin" user of AD organization.
[recording-2023-03-13-16-58-44.webm](https://user-images.githubusercontent.com/6364350/224757632-682a209c-5e7e-4a0d-a28f-e70d728afc1b.webm)


###### Step 3 : Login through the console application:
```C#
string[] scopes = { "https://graph.microsoft.com/.default" };
      ClientSecretCredential clientSecretCredential =
            new(
             "695cecd9-6b4e057a....", // TENANT ID
             "267a56e2-cbe82623.....", // CLIENT ID
             "BbJ8Q~Ttv8lMxYIs.....", // SECRET
              new() { AuthorityHost = AzureAuthorityHosts.AzurePublicCloud }
               );
GraphServiceClient graphClient = new(clientSecretCredential, scopes);
```

###### Step 4 : Callig Api Graph:
```C#
await graphClient.Drives[id!.Id].Root
           .ItemWithPath("Hack Together Microsoft Graph and .NET Calendar.ics")
           .Content.PutAsync(stream, null, new CancellationToken());
```


------

[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)
