# WEB

## Installation
Visual studio skal have Node Js development workload installeret.
Hvis den ikke er installeret, så gå til "Tools" menuen og vælg "Get tools and features" 

1. Åben H5Labyrint.sln i Visual Studio
2. I Visual Studios "Solution explorer" - højreklik på solution og vælg "properties"
3. Sæt "Startup project" til "multiple startup projects", og sørg for at både API og WEB er sat til "Start"
4. Sørg for at WEB afhænger af API i "Startup dependencies"
5. Tilbage i "solution explorer", åbn WEB og højreklik på "npm"-mappen
6. Vælg "Install npm packages"
7. Klik "Start" eller tryk på "F5" for at debugge projektet
