using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform _radar;
    [SerializeField] private RadarUI _radarUI;
    [SerializeField] private float _radarMaxDistance;

    private List <Transform> _targets = new List<Transform>();

    void Update()
    {
        print(_targets.Count);
        
        if (_targets != null)
        {
            foreach (var target in _targets)
            {
                var distance = Vector3.Distance(_radar.position, target.position);
                var direction = target.position - _radar.position;
                float angle = Vector3.SignedAngle(direction, _radar.forward, Vector3.up);

                if (angle > -45f && angle <= 45f)
                    _radarUI.DisplayTargetDirection(RadarUI.Up, distance);

                else if (angle > -135f && angle <= -45f)
                    _radarUI.DisplayTargetDirection(RadarUI.Right, distance);

                else if (angle > 45f && angle <= 135f)
                    _radarUI.DisplayTargetDirection(RadarUI.Left, distance);

                else
                    _radarUI.DisplayTargetDirection(RadarUI.Down, distance);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Goldmine goldmine) && _targets.Contains(goldmine.transform) == false)
            _targets.Add(goldmine.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Goldmine goldmine))
            _targets.Remove(goldmine.transform);
    }
}
