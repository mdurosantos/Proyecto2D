using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchedCollider : MonoBehaviour
{
    private Transform player;
    private PlayerVisibility visibility;
    //private PlayerPos resetPlayerPosition;
    //private GameObject [] resetEnemiesPosition;
    //private EnemyPatrol enemyPatrol;
    private GameFlowController gameFlowController;

    void Start()
    {
        player = LevelAccess.GetPlayerPos();
        visibility = player.GetComponent<PlayerVisibility>();
        //resetPlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        //resetEnemiesPosition = GameObject.FindGameObjectsWithTag("Enemy");
        gameFlowController= GameObject.FindGameObjectWithTag("GameFlowController").GetComponent<GameFlowController>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && visibility.getPlayerVisible())
        {
            //SceneController.LoadCurrentScene();
            
            
            gameFlowController.GameOver();
            /*foreach (GameObject enemy in resetEnemiesPosition)
            {
                enemyPatrol= enemy.GetComponent<EnemyPatrol>();
                enemyPatrol.SetPlayerDetected(false);
                enemyPatrol.ResetPosition();
            }
            resetPlayerPosition.GoToCheckPoint();*/

        }
    }

}
