using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSunController : MonoBehaviour
{

    [SerializeField] private SORotarion Rotation;

    private void Start()
    {
        Rotation.GetTransform(transform);
    }
    private void FixedUpdate()
    {
        Rotation.rotation();
        
    }
    
}
