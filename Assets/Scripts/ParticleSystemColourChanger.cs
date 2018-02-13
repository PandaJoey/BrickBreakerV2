using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemColorChanger : MonoBehaviour
{
    void SetColor(object value)
    {
        if (value.GetType() != typeof(Color))
        {
            Debug.LogError("Incorrect value has been passed to ParticleSystemColorChanger:SetColor");
            return;
        }

        var ps = gameObject.GetComponent<ParticleSystem>();
        if (ps == null)
        {
            Debug.LogError("ParticleSystemColorChanger script has not been attached to a GameObject with a ParticleSystem");
            return;
        }

        var main = ps.main;
        main.startColor = (Color)value;
    }
}