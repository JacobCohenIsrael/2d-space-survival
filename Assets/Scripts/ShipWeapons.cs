using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    [SerializeField] private List<WeaponModule> weaponModules;
    
    private void Start()
    {
        gameInput.FireEvent += OnFire;
    }

    private void OnDestroy()
    {
        gameInput.FireEvent -= OnFire;
    }

    private void OnFire(object sender, EventArgs e)
    {
        weaponModules.ForEach(weapon => weapon.Fire());
    }
}
