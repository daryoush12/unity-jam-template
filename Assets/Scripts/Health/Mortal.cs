using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public abstract class Mortal : MonoBehaviour
{
    [SerializeField] private IntVariable _maximumHealth;
    [SerializeField] private IntGameEvent onMortalHealthChanged;
    [SerializeField] private IntGameEvent onMortalDamaged;
    [SerializeField] private MortalGameEvent onMortalDeath;

    public abstract void Damage();

    public abstract void Heal();
}

[System.Serializable]
public class MortalGameEvent: GameEventBase<Mortal> { }