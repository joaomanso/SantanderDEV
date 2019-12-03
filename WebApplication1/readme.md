
Assignment Test for Santander Senior Backend Developer Application.

This application was developed without any dependencies other than Newtonsoft.JSON

in order to run it, just deploy to IIS or start a debug session on local IIS Express or similar 

if the default settings are used, it should launch directly to the implemented method as launchSettings.json is already pre-configured,

but it can be found in :

api/HackerAPI/GetTopTwenty

for example:

https://localhost:44347/api/HackerAPI/GetTopTwenty

Given time I would remake the methodology to accept a given number in order to filter by number and not have the fixed 20 mark,

I would also treat server Timeouts and possibly implement a methodology to limit calls to outside API as the Hacker API does not seem to 

implement any.


Also I would probably add a parameter to the "GetTopTwenty" method in order to provide what field to filter so it wouldn't only

filter by score.






