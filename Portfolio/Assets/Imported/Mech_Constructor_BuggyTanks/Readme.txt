Hello! Thank you for the purchase. Hope the assets work well.
If they don't, please contact me slsovest@gmail.com.




Assembling the units:


Chassis, shoulders, cockpits and backpacks contain containers for mounting other parts, their names start with "Mount_".
(In some cases they may be deep in bone hierarchy).
Just drop the part in the corresponding container, and It'll snap into place.

- Start with chassis. 
- Find the "Mount_top" or "Mount_cockpit" in the chassis hierarchy. 
- Put the cockpit into this object.
- Find other containers inside shoulders and cockpit.

After the assembly, units consist of many separate parts and, even with batching, can produce high number of draw calls.
You may want to combine non-animated parts into a single mesh for the sake of optimization.

All weapons contain locators at their barrel ends (named "Barrel_end", or "Barrel_end_[number]" in case there are multiple barrels).


The buggies:

The assembly process is the same as for the robots. Start with the "Mount_Cockpit" container inside the chassis.
- Buggies' wheels can be detached or changed (just drop the wheel prefabs into the "Mount_Wheel" container).
- There are no snapping points for the spoiler parts, you'll have to eyeball it.
You can make a simple suspension with the skinned chassis. Just move the joints named "Wheel_".
Not sure if the suspension is organized in the best way, just tried to make it simple.
If you have any recommendations, please write, will try to improve it.




Scripts:


There are two scripts in the pack. The scripts roll each of the tracks (or wheels) depending on their translation in the global coordinates.
All the tracks and wheels are separate, you should add the script component directly to them to animate.

Not a great coder myself, decided not to overcomplicate the scripts and stop on this stage.
So there are a couple of issues left: script doesn't change the roll direction when mechs move backwards, 
and the it keeps on working when the mechs are simply walking.




Textures:


PBR:
To create the material in Unity 5, just plug in the textures from the "Materials/PBR_Maps/Unity_5_Standard_Shader (Specular)"
into corresponding inputs of Unity 5 standard shader (Specular workflow).

Decided not to include the PBR source PSD's directly in the package - they weigh a lot and not sure if they're needed by many people.
Here's the link:
https://drive.google.com/file/d/0B2mY9IjHMQLbNjZOU0FBdlB5Uzg/view?usp=sharing
The .rar contains DDo 2.0 project, which consists of several PSD files that you can edit manually as well.
To create new mech colors, edit the Albedo one (mostly the layers under Body_Paint group).


Hand-painted:
The source .PSD can be found in the "Materials" folder.
For a quick repaint, adjust the layers in the "COLOR" folder. You can drop your decals and textures (camouflage, for example) in the folder as well. Just be careful with texture seams.
You may want to turn off the "FX_Rust" and "FX_Chipped_paint" layers for more cartoony look.
The baked occlusion and contours may be found in the "BKP" folder.




I'm fairly new to Unity, and if you have any ideas how I could organize the assets any better way, please, write.
I'm planning to develop the Mech Construstor assets further. Will try to add the progress images here: https://www.behance.net/slava_zhuravlev/wip
If you have any ideas for the ongoing assets, if you think of a certain module or a weapon type which should be made, please write me via slsovest@gmail.com.
I will try to include it in the future assets.
