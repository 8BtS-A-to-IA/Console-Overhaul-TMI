![console overhaul](https://github.com/8BitShadow/media-resources/blob/main/console%20overhaul.png?raw=true)
# Too Much Information, a "player stats" API.
## About
The "Too Much Information" mod, or the "Player Stats" API, is mod which provides users and modders reliable in-game immediate access to a players' character statistics, such as health, shield, armor and even hitbox count.
<br><br>

T.M.I. achieves this by providing multiple generically interfaced methods for other mods to use and a (currently non-<abbr title="Multi-User Targeting">M.U.T.</abbr> compatible) console command `COGetPlayersStat` for in-game server owners/admins.<br>
The methods provided allow a mod to query for a statistic based on its specific type, or--otherwise--query for a statistic with any type which returns the statistic as an object.
<br><br>
The mod is not intended to, but may, be used outside of defining new console commands, the mod was specifically created so that it is possible to use a characters' statistic as a console command argument - broadening the capabilities of the console command. While it *is* possible to use the mod outside of a new console command context, it is *very heartedly recommended to not do so* and instead reference whatever statistic needed directly as the mod is--naturally--considerably slower than a direct reference.
<br><br>
It is hoped that when this mod is completed it will be able to provide both read **and** write capabilities instead of just read, further broadening the capabilities of the console command.

## Usage
The system uses a generic interface allowing retrieval of any data from just a single method called `GetVariableFromString()`, requiring only the name of the variable, the body to target and an object of the return type. To help with finding what the type of a specific stat is (dynamically), a method exists which allows you to retrieve the type of any of the fetchable data; `GetVariableTypeFromString()`, requiring only the name of the variable and the body to target.

As an alternative to `GetVariableFromString()`, you can use `GetVariableObjectFromString()` with just the variables' name, body and optionally the type if it's already known and it will return the stat in object form.
**It is, however, recommended to define the type if possible as the runtime will spend much less time searching for the object.**

## due to an issue with uploading files directly into the repo via the github website, the files have been temporarily placed into a .zip file.

## development
### How can I develop for this project?
After cloning the repository and ensuring you have any version of [VS 2017/2019](https://visualstudio.microsoft.com/) installed, you should be able to simply open the `.snl` file to open the project in VS.
<br><br>
Before posting a merge request, please ensure you've:
- Adequately checked for 'top level' bugs
- Provided enough commenting/sudo-code for other contributers to quickly understand the process (if necessary)

For the sake of documenting bugfixes, when posting a merge request, please ensure you detail any changes by:
- Describing what was changed (in the head)
- How the changes where made (in the 'extended description')
  - If the merge request only adds new code and does not edit any pre-existing code, feel free to only fill the head.

### How do I compile and run this?
There are no special steps to building and compiling the code, simply press 'run' in <abbr title="Visual Studio">VS</abbr>.<br>
If you do not have the [export helper (todo)]() installed; simply press 'Ok' if an error appears saying "A project with an Output Type of Class Library cannot be started directly". Visual Studio will have the `.dll` file you need generated in `bin>Debug` for VS 2017 or `bin>Debug>netstandard2.0` for VS 2019, simply copy the `.dll` file into the BepInEx `plugins` folder and start RoR2.<br>
If you have the exporter helper tool setup correctly; after pressing 'run' in VS, simply start <abbr title="Risk of Rain 2">RoR2</abbr>.

### How can I help without any programming 'know-how'?
Simply install the mod/modpack from [the modpacks main page](https://github.com/8BtS-A-to-IA/Console-Overhaul) and play. If you encounter any issues make sure to log it and provide as much relevant detail as possible in the relevant mods' `issue` page--or the main page if you don't know which mod is the problem--after checking if the same issue has not already been encountered, you can use the [formatting guide (todo)]() to help with this.<br>
Don't worry about if you predict the wrong mod as the cause, it's more important to just have the report out there.

## Changelog:
<details>
    <summary>V1.0.0 (unreleased):</summary>
  
  - Added 5 new "GetAll...String" methods which allow you to fetch a string array of all **usable**: items, buffs, equipment, tiers and teams. Some things where automatically skipped as being temporary/unusable.
  - Fixed COList..., they now all use the newly added "GetAll...String" methods.
  - Fixed "bodyindex" and all buff, item and equipment API key's methods.
  - Removed a duplicate case of "bodyIndex" API key in the floats.
</details>
