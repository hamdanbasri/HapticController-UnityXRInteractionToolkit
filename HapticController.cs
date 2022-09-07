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
