using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private string level;
    private LevelChanger levelChanger;
    /*private SpriteRenderer loading;*/

    private void Start()
    {
        levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
    }

    void Update()
    {
        if (Input.GetButton("Interact")) {
            //loading.enabled = true;
            levelChanger.FadeToLevel(level);
            //SceneController.LoadScene(level);
        }
    }


}
