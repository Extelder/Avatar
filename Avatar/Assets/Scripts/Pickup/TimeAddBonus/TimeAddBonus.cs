using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TimeAddBonus : MonoBehaviour
{
    [field:SerializeField] public int Seconds { get; private set; }

    private void Awake()
    {
        Seconds = Random.Range(1, 5);
    }
}
