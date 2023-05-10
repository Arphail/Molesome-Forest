using UnityEngine;

public class RadarUI : MonoBehaviour
{
    public const string Up = "Up";
    public const string Left = "Left";
    public const string Right = "Right";
    public const string Down = "Down";

    [SerializeField] private RadarQuarter _quarterUp;
    [SerializeField] private RadarQuarter _quarterRight;
    [SerializeField] private RadarQuarter _quarterDown;
    [SerializeField] private RadarQuarter _quarterLeft;

    public void DisplayTargetDirection(string direction, float distance)
    {
        switch (direction)
        {
            case Up:
                _quarterUp.ShowDistance(distance);
                break;

            case Right:
                _quarterRight.ShowDistance(distance);
                break;

            case Left:
                _quarterLeft.ShowDistance(distance);
                break;

            case Down:
                _quarterDown.ShowDistance(distance);
                break;
        }
    }
}
