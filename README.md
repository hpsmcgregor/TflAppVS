# TflAppVS
App for fetching TFL line status data for a raspberry pi application

Initial fetch tfl data api based off Volkan Paksoy's [tfl apps](https://volkanpaksoy.com/archive/2015/11/13/playing-with-tfl-api-with-csharp-xamarin-and-swift/).

Currently displays line status on a console app.
Gui is under development.

Requires a local.settings.json file with app_id and app_key string values (available from the tfl api) in the TflAppVs.Functions root and currently needs to be copied to output directory.
