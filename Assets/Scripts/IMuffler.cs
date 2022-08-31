using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IMuffler
{
    AudioClip AudioClipMuffler { get; }
    float VolumeFireOnMuffler { get; }
    Transform BarrelPositionMuffler { get; }
    GameObject MufflerInstance { get; }
}
