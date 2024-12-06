using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    GameObject Bullet { get; set; }
    Transform SpawnPoint { get; set; }

    // เปลี่ยนให้ FacingRight มีแค่ get เท่านั้น
    bool FacingRight { get; }

    float ReloadTime { get; set; }
    float WaitTime { get; set; }

    void Shoot();
}