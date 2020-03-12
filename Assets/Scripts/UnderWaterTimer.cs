using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnderWaterTimer : MonoBehaviour
{
    Image fillImg;
    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] Text time;
    // Start is called before the first frame update
    void Start()
    {
        fillImg = this.GetComponent<Image>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        fillImg.fillAmount = currentTime / startingTime;
        time.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
