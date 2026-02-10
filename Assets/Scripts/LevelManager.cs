using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int levelNumber = 0;

    public Transform Player;

    public GameObject BallPrefab;
    public GameObject PillarPrefab;
    public int LevelHeight = 10;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (Player == null)
        {
            Debug.LogError("No player linked in level");
            return;
        }
        StartLevel();
    }

    public void StartLevel()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        GameObject folder = new();
        folder.transform.parent = transform;
        Transform pillar = Instantiate(PillarPrefab, Vector3.zero, Quaternion.identity, folder.transform).transform;
        pillar.localScale = new Vector3(1, LevelHeight, 1);
        Player.position = pillar.position + (LevelHeight - pillar.GetComponent<PillarLevelGenerator>().minimumHeight) * Vector3.up;
        Player.GetComponent<PlayerController>().Ball = Instantiate(BallPrefab, new Vector3(0, LevelHeight, -1), Quaternion.identity).transform;
        Player.rotation = Quaternion.identity;
    }

    public static void RestartLevel(bool incrementLevel)
    {
        if (!incrementLevel || instance.levelNumber < 2)
        {
            if (incrementLevel)
            {
                instance.levelNumber++;
            }
            instance.StartLevel();
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerController>().input.Player.Disable();
            SceneManager.LoadScene("MenuScene");
            Destroy(instance.gameObject);
            return;
        }
    }
}
