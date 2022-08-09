using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class TorchLight : MonoBehaviour
{
    [SerializeField] private float min = 0.5f;
    [SerializeField] private float max = 1f;
    [SerializeField] private float step = 0.1f;
    [SerializeField] private float duration = 0.1f;
    private Light pointLight;

    private void Awake()
    {
        pointLight = GetComponent<Light>();
        pointLight.intensity = min;

    }

    private IEnumerator Start()
    {
        var increase = true;
        while (true)
        {
            if (pointLight.intensity <= max && increase)
            {
                pointLight.intensity += step;
                increase = pointLight.intensity <= max;
            }

            if (pointLight.intensity >= min && !increase)
            {
                pointLight.intensity -= step;
                increase = pointLight.intensity <= min;
            }

            yield return new WaitForSeconds(duration);
        }
    }
}
