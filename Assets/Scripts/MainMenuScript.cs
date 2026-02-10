using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        UIDocument doc = GetComponent<UIDocument>();
        Button start = doc.rootVisualElement.Q<Button>();
        start.clicked += Start_clicked;
    }

    private void Start_clicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
