using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private bool _destroyAfterEndOfHealth = true; //Указывает уничтоать ли объект после окончания здоровья

    public int MaxHealth
    {
        get { return _maxHealth; }
    }
    public int CurrentHealth
    {
        get { return _currentHealth; }
    }

    public UnityEvent healthEndedEvent;
    public UnityEvent gettingDamageEvent;

    private int _currentHealth;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damageValue)
    {
        _currentHealth -= damageValue;//отнимаем пришедший урон
        gettingDamageEvent.Invoke();//вызываем событие получения урона

        if(_currentHealth <= 0)
        {
            healthEndedEvent.Invoke();
            
            if(_destroyAfterEndOfHealth)
            {
                Destroy(gameObject);
            }
        }
    }
}
