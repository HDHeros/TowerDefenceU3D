using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour//изменяет ХПБар, у родителя должен быть компонент Health
{
    private Health _parentHealthComponent;
    private Transform _currentHealthBar;
    private Transform _maxHealthBar;

    private void Start()
    {
        _parentHealthComponent = gameObject.GetComponentInParent<Health>();
        _currentHealthBar = GetComponentsInChildren<Transform>()[1];
        _maxHealthBar = GetComponent<Transform>();
        print(GetComponentInChildren<Transform>());
    }

    public void OnHealthChange()//необходимо подписать на событие изменения здоровья у родителя
    {
        if (_parentHealthComponent.CurrentHealth <= 0) return;

        float percentHealthRemaining = (float)_parentHealthComponent.CurrentHealth / _parentHealthComponent.MaxHealth;

        _currentHealthBar.localScale = new Vector3(_maxHealthBar.localScale.x * percentHealthRemaining,
                                        _maxHealthBar.localScale.y, _maxHealthBar.localScale.z);

    }
}
