using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamefather
{
    public class MobileController : MonoBehaviour
    {
        private void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            gameObject.SetActive(true);
#else
            gameObject.SetActive(false);
#endif
        }
    }
}
