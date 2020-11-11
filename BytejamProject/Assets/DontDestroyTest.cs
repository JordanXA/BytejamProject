using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyTest : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
