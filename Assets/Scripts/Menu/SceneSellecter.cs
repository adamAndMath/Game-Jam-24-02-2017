using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSellecter : MonoBehaviour
{
    public int nextScene;
    public float timeToNext;
    public float fadeTime;
    public Image image;
    private float time;
    private Color c;

    void Start()
    {
        time = timeToNext;
        c = image.color;
    }

    void Update()
    {
        if (time > fadeTime && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Destroy(gameObject);
            return;
        }

        time -= Time.deltaTime;

        c.a = 2 - (Mathf.Min(fadeTime, timeToNext - time) + Mathf.Min(fadeTime, time)) / fadeTime;
        image.color = c;
        if (time > 0) return;

        time = timeToNext;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(nextScene);
    }
}
