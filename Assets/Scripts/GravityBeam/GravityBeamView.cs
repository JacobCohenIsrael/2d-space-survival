using UnityEngine;

namespace GravityBeam
{
    public class GravityBeamView : MonoBehaviour
    {
        [SerializeField] private GameObject beam;

        public void ToggleBeam(bool shouldShow)
        {
            beam.SetActive(shouldShow);
        }
    }
}
