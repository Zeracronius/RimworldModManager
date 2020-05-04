# Rimworld mod manager

Originally inspired by ModSorter by Mehni  
https://github.com/Mehni/ModSorter
  
  
  
This tool is designed to be very light weight; A single executable file with no dependencies or resources.

![Layout image](Layout.jpg "Interface layout")

1. The list on the left is all the inactive mods available.
    - All mods available but not currently active is listed here.
    - Can be sorted by clicking the column headers.
    - Mods can be activated by either double clicking or dragging them into the list on the right. 
    - Multiple mods can be dragged at once.
2. The center list contains the enabled/active mods
    - All currently active mods are listed here in the current load order.
    - Load order can be changed using drag and drop inside the list.
    - Similar to the list of inactive mods, mods can be disabled by either double clicking or dragging them back into the inactive list.
    - Multiple mods can be dragged at once.
    - Because the active mods are listed by load order, this list does not support sorting by column.
3. The right side shows information about the selected mod.
    - The 'Directory' button opens the mod's local folder in a file browser.
    - The 'Steam Workshop' button is only visible for steam-workshop mods, and attempts to open the mod's workshop page in steam.

The Save button in the bottom right overwrites rimworld's mod list config with the new list as defined in the program.  
The Reload button reloads both available and active mods.  
  
Mods displayed in red are incompatible with the current version of core, while mods displayed in orange are warnings.  
Hover the cursor over a colored mod to see a description of the issue(s).

*Note that there is no functionality to auto-sort load order.*
