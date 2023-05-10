using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _gold;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Goldmine>(out Goldmine goldmine))
            goldmine.OnActivate();
    }

    private void Update()
    {
    }
}
