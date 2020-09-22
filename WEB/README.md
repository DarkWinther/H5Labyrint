# WEB

## Debugging
Visual Studio 2019 skal have Node Js development workload installeret.
Hvis den ikke er installeret, s� g� til "Tools" menuen og v�lg "Get tools and features"

Node.js og Npm skal ogs� v�re installeret p� forh�nd, og deres executables b�r findes i PATH.
Visual Studio 2019 underst�tter bedst nodejs 14.4.0 og under.

1. �ben H5Labyrint.sln i Visual Studio 2019
2. I Visual Studios "Solution explorer" - h�jreklik p� solution og v�lg "properties"
3. S�t "Startup project" til "multiple startup projects", og s�rg for at b�de API og WEB er sat til "Start"
4. S�rg for at WEB afh�nger af API i "Startup dependencies"
5. Tilbage i "solution explorer", �bn WEB og h�jreklik p� "npm"-mappen
6. V�lg "Install npm packages"
7. Klik "Start" eller tryk p� "F5" for at debugge projektet

## Troubleshooting
Visual Studio kan have problemer med at loade gulp tasks ordentligt, s�dan at f.eks css ikke compiles rigtigt.

Du kan fort�lle Visual Studio hvilken version af Node den skal bruge ved at g� til
Tools > Options > Project and Solutions > Web Package Management > External Web Tools
og s�rge for at `${PATH}` ligger oven over `${VSInstalledExternalTools}`

S� vil den bruge din version af Node i stedet for den indbyggede version.