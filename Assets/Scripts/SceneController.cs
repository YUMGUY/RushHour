using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Image BlackFade;
    public Animator fadeAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fading() {
        fadeAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => BlackFade.color.a == 1);
        SceneManager.LoadScene(1);
    }

    public void transitionToGame() {
        StartCoroutine(Fading());
    }
}
