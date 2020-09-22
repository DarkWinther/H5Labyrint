# WEB

## Debugging
Visual Studio 2019 skal have Node Js development workload installeret.
Hvis den ikke er installeret, så gå til "Tools" menuen og vælg "Get tools and features"

Node.js og Npm skal også være installeret på forhånd, og deres executables bør findes i PATH.
Visual Studio 2019 understøtter bedst nodejs 14.4.0 og under.

1. Åben H5Labyrint.sln i Visual Studio 2019
2. I Visual Studios "Solution explorer" - højreklik på solution og vælg "properties"
3. Sæt "Startup project" til "multiple startup projects", og sørg for at både API og WEB er sat til "Start"
4. Sørg for at WEB afhænger af API i "Startup dependencies"
5. Tilbage i "solution explorer", åbn WEB og højreklik på "npm"-mappen
6. Vælg "Install npm packages"
7. Klik "Start" eller tryk på "F5" for at debugge projektet

## Troubleshooting
Visual Studio kan have problemer med at loade gulp tasks ordentligt, sådan at f.eks css ikke compiles rigtigt.

Du kan fortælle Visual Studio hvilken version af Node den skal bruge ved at gå til
Tools > Options > Project and Solutions > Web Package Management > External Web Tools
og sørge for at `${PATH}` ligger oven over `${VSInstalledExternalTools}`

Så vil den bruge din version af Node i stedet for den indbyggede version.