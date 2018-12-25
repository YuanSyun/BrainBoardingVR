/*******************************************************
 * Copyright (C) 2016 3lbGames - Chris Castaldi
 * 
 * VRTouchMoveVive
 * 
 * VRTouchMoveVive can not be copied and/or distributed without the express
 * permission of 3lbGames - Chris Castaldi.

 For additional Information or unity development services please contact services@3lbgames.com
 
 For technical support contact support@3lbgames.com

 *******************************************************/

---- IMPORTANT-----

You must Import the SteamVR Plugin from the Asset store in order to use these scripts correctly.



http://u3d.as/cjo

DoTween is being included to help with easing and simulator sickness reduction.
http://dotween.demigiant.com/ Thanks for making such a great Tweener! Please support him

Update DoTween Here https://www.assetstore.unity3d.com/en/#!/content/27676

Copyright (C) 2016 3lbGames - Chris Castaldi

VRViveMove is a comprehensive movement System which contains the following features

-Teleportation
-Blink
-RubberBand Movement 
-Flight / FPS Mode
-Point and Shoot Rotation
-Fading System
-Line Renderer/Arc

Instructions for use:
1) Import SteamVR
2) Apply a Charactor controller to the [Camera Rig]
3) Drag the Left or Right Controller into the Tracked Controller
4) Your Rig = [CameraRig]
5) Head Rig = Camera (eye) 
6) Selected Controller = Controller Choice
7) (Optional) Teleport Point = What you want to use a Teleport Point 
8) (Optional) Teleport Line
9) (Optional) Apply Camera Fade script to center Eye camera and drag into myFade
10)(Optional) Apply Drag Point
11)(Optional) Apply RubberBand Line 

This is a comprehensive movement system for the HTC Vive, though it can be modified for other VR headsets. It includes the following modes: 

Hand-Guided Movement Mode:

Your movement follows the direction you point the controller. Point forward to go forward; point left and you drift that direction.

Point-and-Shoot Rotation Mode:

This rotation mode is best for quick player turns in VR. Simply point the controller in the direction you want to face and press the button.

Teleportation Mode:

This simple teleportation scheme can work with a NavMesh, Tagged Colliders, or any other Colliders.

FPS Mode:

Standard FPS movement system - ie, the camera is moving along the ground, rather than flying. 

Forward-Blink Mode:

The character blinks to a determinable point. 
