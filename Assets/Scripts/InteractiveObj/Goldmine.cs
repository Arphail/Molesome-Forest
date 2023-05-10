using UnityEngine;
using UnityEngine.Events;

public class Goldmine : MonoBehaviour
{
    public UnityAction<Goldmine> Activated;

    public void OnActivate()
    {
        Activated?.Invoke(this);
    } 
}
