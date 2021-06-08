using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Хранит в себе цель и выбрасывает событие когда она изменена
/// </summary>
public class TargetKeeper : MonoBehaviour
{
    public UnityEvent targetChanged;
    [SerializeField] private GameObject target;
    
    public GameObject Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
            targetChanged.Invoke();
        }
    }
}
