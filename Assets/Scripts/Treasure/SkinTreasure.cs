using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkinTreasure : Treasure
{
    public override event UnityAction Acquired;

    public override void AcquireTreasure()
    {
        Acquired?.Invoke();
        gameObject.SetActive(false);
    }

    public override void SetPosition(Transform transform) => gameObject.transform.position = transform.position;
}
