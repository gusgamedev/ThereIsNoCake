using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
// Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineImpulseSource>().GenerateImpulse();        
    }

    
}
