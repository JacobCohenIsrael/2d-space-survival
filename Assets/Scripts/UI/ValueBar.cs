using JCI.Core.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Gamefather.UI
{
    public class ValueBar : MonoBehaviour
    {
        [SerializeField] private IntVar currentValue;
        [SerializeField] private Slider slider;
        [SerializeField] private int maxValue = 100;
        private void Awake()
        {
            slider.minValue = 0;
            slider.maxValue = maxValue;
            slider.wholeNumbers = true;
            currentValue.Updated += OnCurrentValueUpdated;
        }

        private void OnDestroy()
        {
            currentValue.Updated -= OnCurrentValueUpdated;
        }

        private void OnCurrentValueUpdated(int value)
        {
            slider.value = Mathf.Min(value, maxValue);
        }
    }
}
