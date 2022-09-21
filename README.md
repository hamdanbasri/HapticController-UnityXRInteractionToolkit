<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<div align="center">
<a href="https://github.com/hamdanbasri/HapticController-UnityXRInteractionToolkit/blob/main/HapticController.cs">
<img src="images/XITHCLogo.png" alt="Logo">
</a>
<br>
<br>
<p align="center">
Custom Haptic Controller to assign haptic feedback on gameobjects.
</p>
<br>
</div>
<hr>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about">About</a></li>
    <li><a href="#functions">Functions</a></li>
    <li><a href="#getting-started">Getting Started</a></li>
    <li><a href="#codes">Code</a></li>
    <li><a href="#example">Example</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity3d.com)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
</br>
> Do you want each specific object to have their own custom haptic feedback when interacted in VR?
>> These <a href="#codes">codes</a> are here just to do that.
>>> For and in-depth video Justin P Barnett has that covered https://www.youtube.com/watch?v=-5tiV-lyYP8&ab_channel=JustinPBarnett

<hr>



  <h3>Project Requirements</h3>
    <ol>
      <li>Unity project is set up for VR Games.</li>
      <li>Or follow along this tutorial > (https://www.youtube.com/watch?v=yxMzAw2Sg5w&ab_channel=JustinPBarnett) on how to setup.</li> 
    </ol>


<hr>

  <h3>Package Manager Requirements</h3>
    <td>
      <ol>
        <li>Open XR Plugin [Tested on 1.4.2]</li>
        <li>XR Interaction Toolkit [Tested on 2.1.1]</li>
        <li>XR Plugin Management [Tested on 4.2.0]</li>
      </ol>  
    </td>

<div align="center">
<img src="images/OpenXRPluginVersionImage.png" alt="OpenXRPluginVersionImage">
<img src="images/XRInteractionToolkitVersionImage.png" alt="XRInteractionToolkitVersionImage">
<img src="images/XRPluginManagementVersionImage.png" alt="XRPluginManagementVersion">
</div>
<hr>

<!-- FUNCTIONS -->
## Functions


* Control the haptic feedback's amplitude and duration on any gameobject.  

<!-- GETTING STARTED -->
## Getting Started
![Visitors](https://api.visitorbadge.io/api/visitors?path=https%3A%2F%2Fgithub.com%2Fhamdanbasri%2FHapticController-UnityXRInteractionToolkit&label=Visitors&countColor=%23263759&style=flat)
* Add <strong>XROrigin</strong> to the scene.
* Attach the <strong>HapticController.cs</strong> script on both the LeftHand Controller and RightHand Controller
[XR Origin > Camera Offset > LeftHand Controller & RightHandController].
* Add a <strong>SphereCollider</strong> on both the LeftHand Controller and RightHand Controller and set the <strong>trigger to true</strong>.
* Create a Cube in the scene and rename it to <strong>HapticCube</strong>.
* Add a <strong>Rigidbody</strong> component to the HapticCube, <strong>disable the gravity and enable the isKinematic</strong>.
* Create a <strong>tag called HapticObject</strong> and assign the tag to the HapticCube.
* Add a <strong>XR Simple Interactable</strong> component to the HapticCube.
* Add the <strong>HapticObject.cs</strong> script to the HapticCube.
* Adjust the <strong>Amplitude and Duration</strong>.
* Press Play, put on your headset, reach out towards the HapticCube using your controller and test the feedback.

<hr>

<h2>Pro-Tip:</h2>
You can <strong>right click</strong> on the HapticController component and select Haptic Test when playing. This will give you a sense of how strong do you want the feedback to be.

<h2>Known-Issues:</h2>
Duration of the haptic feedback is <strong>limit to 2 seconds</strong>. Let me know if there is a way to increase the duration.

<hr>

<!-- CODE -->
## Codes

Haptic Controller
``` C
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticController : MonoBehaviour
{
    public XRBaseController vrController;
    [Header("Right Click on this component and select Haptic Test to the feedback strength and duration.")]
    [RangeAttribute(0f,1f)]
    public float defaultAmplitude = 0.5f;
    public float defaultDuration = 0.3f;

    private void Start() {
        vrController = GetComponent<XRBaseController>();
    }

    [ContextMenu("Haptic Test")]
    public void SendHaptics()
    {
        vrController.SendHapticImpulse(defaultAmplitude, defaultAmplitude);
    }

    public void SendHaptics(XRBaseController controller, float amplitude, float duration)
    {
        controller.SendHapticImpulse(amplitude, duration);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("HapticObject"))
        {
            other.GetComponent<HapticObject>();
            SendHaptics(vrController, other.GetComponent<HapticObject>().amplitude, other.GetComponent<HapticObject>().duration);
        }
    }
}
```

Haptic Object
``` C
using UnityEngine;

public class HapticObject : MonoBehaviour
{    
    [RangeAttribute(0f,1f)]
    public float amplitude = 0.5f;
    public float duration = 0.3f;
}

```


<!-- USAGE EXAMPLES -->
## Example

<div align="center">
<img src="images/HapticControllerExampleImage.png" alt="Sample">
<p align="center">
Attached on both the LeftHand Controller and RightHand Controller.
</p>
</br>
        <table>
        <tr>
            <td>Variable</td>
            <td>Annotation</td>
        </tr>
        <tr>
            <td>VR Controller</td>
            <td>Automatically find the XR Base Controller in your GameObject component</td>
        </tr>
        <tr>
            <td>Default Amplitude</td>
            <td>Set the default strength of the haptic feedback</td>
        </tr>
        <tr>
            <td>Default Duration</td>
            <td>Set the default duration of the haptic feedback</td>
        </tr>
        </table>
</div>

<br>

<div align="center">
<img src="images/HapticObjectExampleImage.png" alt="Sample">
<p align="center">
Attached to the Haptic object.
</p>
</br>
        <table>
        <tr>
            <td>Variable</td>
            <td>Annotation</td>
        </tr>
        <tr>
            <td>Amplitude</td>
            <td>Set the strength of the haptic feedback on this GameObject</td>
        </tr>
        <tr>
            <td>Duration</td>
            <td>Set the duration of the haptic feedback</td>
        </tr>
        </table>
</div>


<!-- CONTACT -->
## Contact

[![Twitter](https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/its_danisauraus)
[![LinkedIn][linkedin-shield]][linkedin-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/hamdanbasri

