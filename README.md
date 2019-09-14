# TflAppVS
App for fetching TFL line status data for a raspberry pi application

Initial fetch tfl data api inspired by Volkan Paksoy's [tfl apps](https://volkanpaksoy.com/archive/2015/11/13/playing-with-tfl-api-with-csharp-xamarin-and-swift/).

TflAppVs.Functions project currently displays line status on a console app when run.

Gui is still under development in the form of TflAppVs.WebApp - displays a table but line colours not fully functional.

Requires a local.settings.json file with app_id and app_key string values (available from the tfl api) in the TflAppVs.Functions and the TflAppVs.WebApp roots and currently needs to be copied to output directory for the functions project.
