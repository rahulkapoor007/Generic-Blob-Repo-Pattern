
# Generic Blob Repository

This project contain a generic Repository which is very helpfull while connecting with single as well as multiple blob storage using ASP.NET 6.

## What?

This contain a generic helper class for uploading files, meta data and tags to blob storage.



## Azure Blobs
Azure Blob storage is Microsoft's object storage solution for the cloud. Blob storage is optimized for storing massive amounts of unstructured data. Unstructured data is data that doesn't adhere to a particular data model or definition, such as text or binary data.

<img src="https://docs.microsoft.com/en-us/azure/storage/blobs/media/storage-blobs-introduction/blob1.png" />

## Features

- Generic Repository for blob
- Maintaing blob credentials using appsettings.json
- Maintaing multiple blob container uploads.


## Installation

First Installation, clone this repository and open it in a terminal. Then restore all the dependencies and run the project.


```sh
$ git clone https://github.com/rahulkapoor007/Generic-Blob-Repo-Pattern.git
$ cd GenericBlobStorage
$ dotnet restore
$ dotnet run
```

## Usage/Examples

There is an API endpoints with which you can test:

 - `POST:` `http://localhost:5154/api/Blob/UploadContent`: 
 Payload :
 ```
 {
     "FileName" : "",
     "File" : IFormFile
 }
 ```

 This API upload the content to the particular container and gives the following response :
 ```
 {
     "Id":"",
     "FileName":"",
     "FilePath":"",
     "OriginalFileName":"",
     "ContentType":"",
     "FileUrl":""
 }
 ```