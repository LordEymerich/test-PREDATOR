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
* ***4***: for EM vision
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

# Future Improvements

# Authors
* **SinCity** -*Design, Art and Scene Development*-
* **Marco Camponeschi** -*Shaders Development*-
