# Windows client for home-dashboard

This windows client is used on [home-dashboard](https://github.com/Hekku2/home-dashboard)

## What is it
Purpose of the client is to report sensor values to Home Dashboard-backend.

## Usage
This program has has 2 modes, service mode and single-run mode.
In service mode, program is installed as windows service.

For help, see ```WindowsSensorClient.exe --help```

### Service install
```
WindowsSensorClient.exe --install-service
```
Service is installed with name ```Home Dashboard Monitor```
Start service from ```service.msc``` or other way.

### Service unistall
```
WindowsSensorClient.exe --uninstall-service
```

### Single run mode
```
WindowsSensorClient.exe --single-run
```
or
```
WindowsSensorClient.exe -s
```

In this mode, temperature is read and sent once and then program exits.

## Configuration
Change values in .config file when running the softare (App.config when compiling)

* **BackEndAddress** Address of backend server root (ex. http://localhost:1337)
* **Username** Credentials for backend
* **Password** Credentials for backend
* **SensorId** Identification so values can be added for right sensor.

## License
The MIT License (MIT)
