using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform _radar;
    [SerializeField] private Transform[] _targets;
    [SerializeField] private RadarUI _radarUI;
    [SerializeField] private float _radarMaxDistance;

    void Update()
    {
        foreach(var target in _targets)
        {
            var distance = Vector3.Distance(_radar.position, target.position);
            var direction = target.position - _radar.position;
            float angle = Vector3.SignedAngle(direction, _radar.forward, Vector3.up);

            if (angle > -45f && angle <= 45f)
                _radarUI.DisplayTargetDirection("Up", distance);

            else if (angle > 45f && angle <= 135f)
                _radarUI.DisplayTargetDirection("Left", distance);

            else if (angle > -135f && angle <= -45f)
                _radarUI.DisplayTargetDirection("Right", distance);

            else
                _radarUI.DisplayTargetDirection("Down", distance);
        }
    }
}
