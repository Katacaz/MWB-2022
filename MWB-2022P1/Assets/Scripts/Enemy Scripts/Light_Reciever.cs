using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Light_Reciever : MonoBehaviour
{

    public UnityEvent onLightHit;

    public void OnLightHit()
    {
        onLightHit.Invoke();
    }
}
