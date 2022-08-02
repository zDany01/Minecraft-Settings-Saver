<div align="center">

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

</div>


<br />
<div align="center">
  <a href="https://github.com/zDany01/Minecraft-Settings-Saver">
    <img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Logo.png?raw=true" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Minecraft Settings Saver</h3>

  <p align="center">
    A program that allows you to save your minecraft game settings and reapply them when needed.
    <br />
    ·
    <a href="https://github.com/zDany01/Minecraft-Settings-Saver/issues">Report Bug</a>
    ·
  </p>
</div>



<!-- ABOUT THE PROJECT -->
## About The Project

![Product Name Screen Shot][product-screenshot]
<br>
This application was made to make it possible switching Minecraft versions without always having to reconfigure all the keybindings.

It is known that playing an older Minecraft version can reset all the settings but using this app you can create a profile for each Minecraft version where to save its settings and then apply them before launching Minecraft, so the only thing that you need to worry about is that **creeper near your house**.


For more information about using this app, go to the [How to use](#how-to-use) section.
<br><br>

## Installation
You can download the latest precompiled version of the program [here](https://github.com/zDany01/Minecraft-Settings-Saver/releases/download/v2/MinecraftSettingsSaver-Setupx64.exe) or you can compile the application by yourself following these instruction.

1. Download Microsoft [Visual Studio Community](https://visualstudio.microsoft.com) Edition
2. Check the ***.NET Desktop Developer*** box and click install
3. Clone(or [download](https://github.com/zDany01/Minecraft-Settings-Saver/archive/refs/heads/main.zip)) this repository:
   ```sh
   git clone https://github.com/zDany01/Minecraft-Settings-Saver.git
   ```
4. Open the project directory and run the `MinecraftSettingsSaver.sln` file, this will fire up Visual Studio and automatically open the project
5. Now you can compile or review the source code and make any modification you want within Visual Studio

<br><br>

## How to use
***NOTE: Saving and Loading profiles should be done ONLY when minecraft is closed!***
<div align=center>

![AppInterface](https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/AppInterface.png?raw=true)
</div>


The interface is composed of:
- A List where all saved profiles will be shown
- a "Saving Area"(marked in green) where you can input the profile name, select the Minecraft version, choose if include or not Optifine settings and a final button to save all into a profile.
- a "Managing Area"(marked in blue) that consists of 4 buttons with different functions

<br>


### Save a profile
Let's say that I want to save all my settings for my Minecraft vanilla world, the first thing that I need to do is to choose a name for this new profile in this case I'll use _Vanilla_, after select my Minecraft version, in my case 1.14 and, if possible, include the Optifine Settings.
In my case, since this is a vanilla world, I don't use optifine so I don't check that.<br>
Following my steps you should have something similar to this:
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Addingpt1.png?raw=true"></div>

At this point, all I need to do is to save the profile by clicking the **Save current settings** button.
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Added1.png?raw=true"></div>

Now our new profile is saved and we can see it in the list, also since now at least one profile has been added, most of the option in the Managing Area has been unlocked.

After that let's make that I open instead my new modded world in 1.19 and I want to save all my options including keybindings from the mod.<br>
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Addingpt2.png?raw=true">"</div>

Simply I repeat all previous steps but this time, since I'm in a modded world, I will **include** Optifine settings.

After saving, the result shoud be something like this:
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Added2.png?raw=true"></div>
<br><br>

### Load a profile
Now that I've played my modded world, I want to go back to my Vanilla without having to reconfigure all settings, all I need to do is select the Vanilla profile and then click the **Load saved profile** button
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Load1.png?raw=true"></div>

After that a popup will appear asking if you are sure to apply the settings
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Load2.png?raw=true"></div>

After clicking yes your profile settings will be successfully restored.
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Load3.png?raw=true"></div>
<br><br>

### Delete a profile
Select the profile that you want to delete from the list and right-click it, a menu will pop out where you can see the **Delete** option.
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Delete.png?raw=true"></div>
<br><br>

### Export Profiles
You can export all saved profiles by clicking the **Export all saved profiles** button, a window will show up asking where to save the file.<br>
If you have done all correctly, the exported file will have the application icon and will be similar to this
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/File.png?raw=true"></div>

>_Note: if you're using the portable version of the app, the icon will not appear_

<br>

## Import Profiles
You can import profiles by clicking the **Import profiles from file** button, a window will show up asking to select the file containing the profiles.<br>
After selecting the file, the program will analyze it and will show a message containing the number of profiles found in that file, asking for permission to import them
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Import.png?raw=true"></div>
Select yes and the profiles will be imported
<div align="center"><img src="https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/Imported.png?raw=true"></div>

>Note: If you're **not** using the portable version, you can also double-click the exported file to automatically import it.<br>

<br><br><br>
## License

Distributed under the MIT License. See `LICENSE` for more information.

[contributors-shield]: https://img.shields.io/github/contributors/zDany01/Minecraft-Settings-Saver.svg?style=for-the-badge
[contributors-url]: https://github.com/zDany01/Minecraft-Settings-Saver/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/zDany01/Minecraft-Settings-Saver.svg?style=for-the-badge
[forks-url]: https://github.com/zDany01/Minecraft-Settings-Saver/network/members
[stars-shield]: https://img.shields.io/github/stars/zDany01/Minecraft-Settings-Saver.svg?style=for-the-badge
[stars-url]: https://github.com/zDany01/Minecraft-Settings-Saver/stargazers
[issues-shield]: https://img.shields.io/github/issues/zDany01/Minecraft-Settings-Saver.svg?style=for-the-badge
[issues-url]: https://github.com/zDany01/Minecraft-Settings-Saver/issues
[license-shield]: https://img.shields.io/github/license/zDany01/Minecraft-Settings-Saver.svg?style=for-the-badge
[license-url]: https://github.com/zDany01/Minecraft-Settings-Saver/blob/main/LICENSE
[product-screenshot]: https://github.com/zDany01/zDany01/blob/main/Assets/Minecraft-Settings-Saver/TextLogo.png?raw=true