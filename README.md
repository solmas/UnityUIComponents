# UnityUIComponents

This is a repo to put components that I create that might be useful for others.  Feel free to grab and use them if they're helpful for you, and if you have any feedback or suggestions I'd love to hear them.  Thank you!

Component Description:

IconAutoAnimation: 
 -  Requires free asset LeanTween ( or can be replaced with any tween type asset with code changes in SetNewVectorsAndAnimate() method and timing variables) on the asset store
 -  Requires call or input event that passes (string id) and (bool isReversed) to call correct component id and if it is animating in reverse
 -  id variable example:  DPad Up/Down and Left/Right set to function as icon selection input.  Input Event DPad.Up id = "up", DPad.Down id = "down"
 -  Once wiring is set up, you can place as many icons within a parent panel, move and scale them as desired, and they will animate and transform in sequence with each other at runtime
