# Introduction 
This solution contains two different Azure Function projects, one triggered by an Azure Storage Queue, the other by an HTTP request (think API).

In the Storage Queue project, I've also demonstrated setting up dependency injection and injecting custom options for use in services.

# Overview Video
Checkout a full walkthrough of the solution [on Youtube](https://www.youtube.com/watch?v=nBMO4-TWeBA).

# Getting started
The solution should run basically as-is. Note that you will need to install the Azure SDK or use the standalone installer to get the Azure Storage Emulator on your machine (also note that this emulator is being replaced, but that the new emulator doesn't fully work as-is yet).

The notes on getting the emulator working are here:  
https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator

Alternatively, you can specify real connection strings in `local.settings.json` and `appsettings.json` to use a real Azure Storage instance.

# Build Status

### AzureFunctionHttpTrigger Build Status:  
[![Build Status](https://dev.azure.com/FitzyCodesThings/AzureFunctionTemplates/_apis/build/status/AzureFunctionTemplates?branchName=master)](https://dev.azure.com/FitzyCodesThings/AzureFunctionTemplates/_build/latest?definitionId=1&branchName=master)

### AzureFunctionQueueTrigger Build Status:
[![Build Status](https://dev.azure.com/FitzyCodesThings/AzureFunctionTemplates/_apis/build/status/AzureFunctionTemplates%20(1)?branchName=master)](https://dev.azure.com/FitzyCodesThings/AzureFunctionTemplates/_build/latest?definitionId=2&branchName=master)

# Thanks

My many, many thanks to IAmTimCorey on YouTube (and he also has some FANTASTIC courses) for his overviews/demos of [Azure Functions](https://www.youtube.com/watch?v=zIfxkub7CLY) and [Azure DevOps CI/CD](https://www.youtube.com/watch?v=H-R2bCXfz8I). Both were HUGELY helpful getting me started.

Big thanks to Layla of [LaylaCodesIt](https://www.twitch.tv/LaylaCodesIt) for inspiring me to give Functions a whirl to begin with. 😁

Thanks, too, to Microsoft for the great docs on [adding DI to functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection).
