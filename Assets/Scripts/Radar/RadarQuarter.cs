using UnityEngine;
using UnityEngine.UI;

public class RadarQuarter : MonoBehaviour
{
    [SerializeField] private float _longDistance;
    [SerializeField] private float _midDistance;
    [SerializeField] private float _shortDistance;
    [SerializeField] private RawImage _longDistanceImage;
    [SerializeField] private RawImage _midDistanceImage;
    [SerializeField] private RawImage _shortDistanceImage;

    public void ShowDistance(float distance)
    {
        if (distance <= _shortDistance)
        {
            _longDistanceImage.color = Color.red;
            _midDistanceImage.color = Color.red;
            _shortDistanceImage.color = Color.red;
        }

        if (distance > _shortDistance && distance < _midDistance)
        {
            _longDistanceImage.color = Color.red;
            _midDistanceImage.color = Color.red;
            _shortDistanceImage.color = Color.white;
        }

        if (distance > _midDistance && distance < _longDistance)
        {
            _longDistanceImage.color = Color.red;
            _midDistanceImage.color = Color.white;
            _shortDistanceImage.color = Color.white;
        }

        if(distance > _longDistance)
        {
            _longDistanceImage.color = Color.white;
            _midDistanceImage.color = Color.white;
            _shortDistanceImage.color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        _longDistanceImage.color = Color.white;
        _midDistanceImage.color = Color.white;
        _shortDistanceImage.color = Color.white;
    }
}
