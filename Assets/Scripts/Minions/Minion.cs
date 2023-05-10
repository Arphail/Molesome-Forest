using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _minePosition;
    private bool _goingToMine;

    private void Update()
    {
        if (_goingToMine)
            transform.position = Vector3.MoveTowards(transform.position, _minePosition, _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Goldmine goldmine))
            _goingToMine = false;
    }

    public void FarmGold()
    {

    }

    public void GoToGoldMine(Goldmine goldmine)
    {
        _goingToMine = true;
        _minePosition = goldmine.transform.position;
    }
}
