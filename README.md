# TflAppVS
App for fetching TFL line status data for a raspberry pi application

Initial fetch tfl data api for tube statuses inspired by Volkan Paksoy's [tfl apps](https://volkanpaksoy.com/archive/2015/11/13/playing-with-tfl-api-with-csharp-xamarin-and-swift/).

TflAppVs.Functions project currently displays line status on a console app when run.

TflAppVs.WebApp project currently displays a table with tfl line and status.

Requires a local.settings.json file with string values for app_id and app_key (available from the tfl api), and station naptanId and tfl transport type for departure board. This file needs to be placed in the TflAppVs.Functions and the TflAppVs.WebApp roots and currently needs to be copied to output directory for the functions project.

example for local.settings.json:
```
{
    "app_id": "",
    "app_key": "",
    "stationId": "",
    "tflType":  ""
}
```
