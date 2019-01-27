using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{ 
    public bool IsStompDamage = false;
    public bool IsFireDamage = true; 
    private void OnTriggerEnter(Collider other)
    {
        Gnome g = other.GetComponentInParent<Gnome>(); 
        if (g) // if this is a gnome\player
        {
            if (IsStompDamage) { g.OnDeathStomp();  return;  }
            if (IsFireDamage) { g.OnDeathFire(); return; }
        }
    }
}
