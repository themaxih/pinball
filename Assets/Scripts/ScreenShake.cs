using UnityEngine;
using System.Collections;

public class ScreenShake
{
    private readonly Camera camera;
    private readonly float shakeDuration;
    private readonly float shakeMagnitude;

    private MonoBehaviour coroutineRunner;

    public ScreenShake(Camera targetCamera, float magnitude, float duration)
    {
        camera = targetCamera;
        shakeMagnitude = magnitude;
        shakeDuration = duration;

        // On a besoin d’un MonoBehaviour pour lancer une coroutine
        if (camera != null)
        {
            coroutineRunner = camera.GetComponent<MonoBehaviour>();
            if (coroutineRunner == null)
            {
                coroutineRunner = camera.gameObject.AddComponent<ScreenShakeRunner>();
            }
        }
    }

    public void StartShake()
    {
        if (coroutineRunner != null)
            coroutineRunner.StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPos = camera.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            camera.transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        camera.transform.localPosition = originalPos;
    }
}

// Permet d'exécuter des coroutines depuis une classe non-MonoBehaviour.
public class ScreenShakeRunner : MonoBehaviour { }

