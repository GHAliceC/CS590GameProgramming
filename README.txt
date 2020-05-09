Project Name: The Escape of Soul

Authors: Yuwei Chen, Yueying Liu

Description: This is a room break game(strategy). Our story is about the soul of the mausoleum owner struggling to get out of the mausoleum and re-enter the human world. We use Unity as our tool to design and implement game features.The mausoleum owner’s soul (1st person view) would be one key element throughout the game, and mice (3rd person view) in the mausoleum would be the other key element as a carrier for soul to manipulate complicated puzzles.

A backdoor: if it is hard to embody a mouse, press Space. It is a backdoor we used for testing. We did not remove this feature. But it is not a designed key input.


Distribution of work:
 -------------------------------------------------------------------
 +          Yuwei Chen            +          Yueying Liu          +
 ——-----------------------------------------------------------------
 + 1.Build and decorate           + 1.Switch between first-person +
 +   the Mausoleum                +   and third-person            +
 + 2.Construction of windmill's   + 2.Instructions, warnings      +
 +   mechanism                    +   and other panels control    +
 + 3.Mice random wandering        + 3.Props and explosion effect  +
 + 4.Mausuleum exit effect        + 4.Win and Dead effect         +
 +                                +                               +
 +-----------------------------------------------------------------
 +  FanRotate.cs                  +  CameraController.cs          +
 +  FireShoot.cs                  +  CanvasController.cs          +
 +  MoveScript.cs                 +  HallControl.cs               +
 +  RatScript.cs                  +  PlayerController.cs          +
 +  SeesawRotate.cs               +  SoundController.cs           +
 +                                +                               +
 +-----------------------------------------------------------------
 