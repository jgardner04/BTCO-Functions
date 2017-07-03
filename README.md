# Image Resize Functions
This is a tool that runs on Azure Functions to resize images.

## ImageResize Function
This Function uses the [ImageResizer](//www.nuget.org/packages/ImageResizer) package to perform the image resizing based on files added to Azure Blob storage. Once the image is uploaded to the source gallery it resizes it based on an array of sizes and distributes it to Azure Blob Storage containers based on the size. This process is currently a manual change to the code but at some point in the future I may change it to be more dynamic. With the files converted, the content type of the file is set to the appropriate content type based on the file extension. This allows for media files to be displayed correctly when accessed, as from a website.

## SmartThumbs Function
This function is also for resizing an image but takes advantage of the [Microsoft Cognitive Services Computer Vision API](//docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/home) and its ability to do smart cropping of the image. When a file is added to a storage container, the Function sends the image to the Computer Vision API and smart crops the image.

To use this function you must set the API key in the App Settings of the Functions App. Information on setting them can be found on the [Azure Functions documentation](//docs.microsoft.com/en-us/azure/azure-functions/functions-how-to-use-azure-function-app-settings)

**NOTE: This does not set the content type yet and may not display correctly when accessed via a browser**

## Code of Conduct
This project has adopted the Microsoft Open Source Code of Conduct. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.