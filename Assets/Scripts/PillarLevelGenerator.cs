using UnityEngine;

public class PillarLevelGenerator : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public GameObject DangerPrefab;
    public GameObject WinPrefab;

    private float height;
    readonly public int minimumHeight = 4;
    private int startingIndex;

    private void Start()
    {
        height = 2f * transform.localScale.y;
        startingIndex = Mathf.CeilToInt(height) - minimumHeight;

        if (PlatformPrefab != null && DangerPrefab != null && WinPrefab != null && height > minimumHeight)
        {
            for (int i = startingIndex; i > 0; i -= minimumHeight - 1)
            {
                float randomYRotation = GetRandomPlatformRotation(i);
                Transform platform = Instantiate(PlatformPrefab, new Vector3(0, i - height / 2f, 0), Quaternion.Euler(0, randomYRotation, 0), transform.parent).transform;

                int dangerCount = Random.Range(0, 4);
                for (int j = 0; j < dangerCount; j++)
                {
                    float dangerYRotation = randomYRotation + GetRandomDangerRotation(i);
                    Instantiate(DangerPrefab, new Vector3(0, i - height / 2f, 0), Quaternion.Euler(0, dangerYRotation, 0), platform);
                }
            }
            Instantiate(WinPrefab, new Vector3(0, -height / 2f, 0), Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("Doesn't have the necessary prefabs for level generation");
        }
    }

    public float GetRandomPlatformRotation(int platformIndex)
    {
        float random = Random.Range(0, 8) * 45f;
        if (platformIndex == startingIndex && random == 0f)
        {
            random = 45f;
            if (Random.value < .5f)
            {
                random = -45f;
            }
        }
        return random;
    }

    public float GetRandomDangerRotation(int platformIndex)
    {
        float random = Random.Range(0, 16) * 22.5f;
        if (random == 0f)
        {
            random = 45f;
            if (Random.value < .5f)
            {
                random = -45f;
            }
        }
        else if (random == 22.5f)
        {
            random += 22.5f;
        }
        else if (random == 15 * 22.5f)
        {
            random -= 22.5f;
        }
        if (platformIndex == startingIndex && random == 45f)
        {
            random += 45f;
        }
        return random;
    }
}