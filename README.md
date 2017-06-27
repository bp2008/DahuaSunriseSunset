# DahuaSunriseSunset
A Windows Service which changes the profile of dahua cameras between Night and Day at each sunset and sunrise.

## Requirements

1) Windows OS
2) One or more Dahua IP cameras to control, accessible by http.  Http

## Usage

1) Download from here: https://github.com/bp2008/DahuaSunriseSunset/releases
2) Run `DahuaSunriseSunset.exe` to open the service manager GUI.

![Service Manager](http://i.imgur.com/qIJZPOT.png)

3) Click `Configure Service`.  Your location (latitude and longitude) is used to determine the time of sunrise and sunset.  In this example, two (imaginary) cameras located in Denver, CO will be switched to day profile one hour before sunrise.  Night profile will be enabled one hour after sunset.

![Configuration](http://i.imgur.com/a9cKsuO.png) ![Add Camera](http://i.imgur.com/jqELba5.png)

4) Install and Start the service, using the buttons in the service manager.

If the service is running when you modify configuration, then for best results you should stop and restart the service.  If you forget to restart the service, the new configuration will be learned at the next profile switch.
