using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoldTreasure : Treasure
{
    [SerializeField] private Base _base;
    [SerializeField] private float _gold;

    public override event UnityAction Acquired;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            AcquireTreasure();
            gameObject.SetActive(false);
        }
    }

    public override void AcquireTreasure()
    {
        Acquired?.Invoke();
        _base.AddGold(_gold);
    } 

    public override void SetPosition(Transform transform) => gameObject.transform.position = transform.position;
}
