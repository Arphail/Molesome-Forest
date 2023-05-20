using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Treasure : MonoBehaviour
{
    public abstract event UnityAction Acquired;
    public abstract void AcquireTreasure();
    public abstract void SetPosition(Transform transform);
}
