Jessie Archer
Brandon Lo
Noel M. Paredes 
Group 9
ICS 167/GDIM 32
Zoo Boss
Final Playtest
March 19, 2023

=Objective=
The player has the ability to design their own zoo. As the ticket booth accumulates money, the player will have the option to visit empty spots and place animals, decorations, restaurants, shops, and attractions. This game is open-ended, so the player decides how large they want to expand their zoo. 

=Controls=
WASD - movement (forward-sideways)
X - open menu
Z - cycle left
C - cycle right
Escape - Menu

=AI Note (From Second Playtest)=
-Animals will begin Idle, move to a random spot in pen, and then wait for the player to approach the pen. 
-Animals will wander again after the player leaves the pen radius. 
-After some time, newly spawned animals may not move due to what is believed to be a memory-issue. This is not gamebreaking, but it is worth noting. 

=Important Note=
-Players have to buy the expansion separately from each other. This was due to an RPC issue that prevented players from both being able to access it. 

=Bugs=

=Second Playtest Bugs (Believed to be resolved)=
-The visitor occasionally jitters if it hits a corner of a pen. We believe this was fixed, but it may occur.
-The visitor also may appear to "float" due to jagged parts of the NavMesh pushing it off the ground.
-Visitors colliding with large buildings may shake violently afterwards.
-Animals may randomly have issues with pathfinding to players in a specific orientation. 

=Final Playtest Bugs=
-Money may not sync up during gameplay, but players can still build and place animals.
-After buying a building, the pen may still be there. This occurs randomly, as sometimes the pen may be destroyed as intended.
-Visitors may pile up in front of the ticket booth and not leave. Players can push them into the booth to destroy them.
-If the master client leaves, the zoo may become empty if they built multiple pens. The main solution to this has been creating a new room. 


=Unity Asset Store Assets=

-5 animated Voxel animals by VoxelGuy
https://assetstore.unity.com/packages/3d/characters/animals/5-animated-voxel-animals-145754

-Free! Low Poly Boxy-Stylized Trees #0 by VoxelCraft
https://assetstore.unity.com/packages/3d/vegetation/trees/free-low-poly-boxy-stylized-trees-0-67258

-Low Poly Fence Pack by Broken Vector
https://assetstore.unity.com/packages/3d/props/exterior/low-poly-fence-pack-61661

-Low Poly Wind by Nicrom
https://assetstore.unity.com/packages/vfx/shaders/low-poly-wind-182586

-Low Poly Mini Village Free by Ioan Stan
https://assetstore.unity.com/packages/3d/environments/low-poly-mini-village-free-131677

-Animals! by Olan
https://assetstore.unity.com/packages/audio/sound-fx/animals/animals-95444

-Mini Low Poly Pack by Have Fun with Developing
https://assetstore.unity.com/packages/3d/environments/mini-low-poly-pack-185471

-Low poly City Assets by Paulina Sroka
https://assetstore.unity.com/packages/3d/environments/urban/low-poly-city-assets-234586

-Low Poly Luna Park by Justiplay
https://assetstore.unity.com/packages/3d/environments/low-poly-luna-park-191731

-Free Casual Music Pack by mk.matheusklein
https://assetstore.unity.com/packages/audio/music/free-casual-music-pack-242591

