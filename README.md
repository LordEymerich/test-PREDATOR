# test-PREDATOR
This is a test for the new chapter for the Aliens vs Predator game series. Here the focus is on implementing all the different Alien vision modes:
* Normal vision
* Night vision
* Thermal vision
* EM vision.
* Combined vision (normal vision with night, thermal and EM visions as thumbnails)
# Running the test
Load the main scene (main.unity), execute it and press:
* ***1***: for normal vision (by default this is the one already active)
* ***2***: for night vision
* ***3***; for thermal vision
* ***4***: for EM vision (missing at the moment)
* ***0***: for combined vision
# Project Managment
In this project there are 3 branches:
* **master**: It contains a working version of the project.

* **Development**: the branch in which the features braches are merged. This is used for integration tests between different features. After a set of features have been deveoped and successfully tested, this is merged in master branch.

* "***Feature***": the feautre that is currently under development (eg NightVision, ThermalVision, ecc...)

# Implementation
**Night Vision**

The night vision is obtained using an image effect. There are 3 parameters that can be adjusted to obtain different results:
* Luminance Amplifier: multiply RGB components of the scene's color.
* Noise Intensity: how much of the noise texture is applied to the final color.
* Noise Texture: grayscale image. At the moment it's s a Perlin noise texture.

**Thermal Vision**

The Thermal vision is obtained using an image effect to simulate the cold scene elements and a material ("Thermal Body") to represent scene elements that have a significant temperature. This material is activated and deactivated based on the thermal vision image effect script that is on the main camera. To apply the Thermal body material on a game object the designer must only add the ThermaVisionEventReceiver script on it and choose the average temeprature of the body. This script will magane the material swap when the thermal vision is activated.
The image effect script has 2 parameters that can be adjusted to obtain different results:
* Noise Intensity: how much of the noise texture is applied to the final color.
* Noise Texture: grayscale image. At the moment it's s a Perlin noise texture.

**Combined Vision**

The combined vision is obtained using different cameras where the cameras using the vision image effects have a smaller viewport size.
At the moment only normal and night vision can be used in the combined mode.

# Known Issues
*Major* issues have more priority than *minor* ones so must be solved first.

**Combined Vision**

* (Major) In the combined view the thermal vision is broken. This is happening because the Thermal Body material should be rendered only in the thumbnail thermal camera and not in the normal vision camera.

**Thermal Vision**

* (Minor) The designer should have a preview of the temperature when it is changed in the ThermalVisionEventReceiver script.

# Future Improvements
**Night Vision**

* If a light in turned on or off, the night vision effect should adapt with time to the new situation and not instantly.

**Thermal Vision**

* It would be more realistic to have an heat map for every interesting object or at least some points with an associated intensity to represent the temperature distribution.

**EM Vision**

* This vision mode at the moment is not present.
* It can be developed usign the Thermal Vision as a starting point and changing the gradient map to something more uniform (from light blue to white)
* As the thermal vision it would be more realistic to have a EM map for every interesting object.

# Authors
* **SinCity** -*Design, Art and Scene Development*-
* **Marco Camponeschi** -*Shaders Development*-
