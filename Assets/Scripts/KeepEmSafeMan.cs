using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepEmSafeMan : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
