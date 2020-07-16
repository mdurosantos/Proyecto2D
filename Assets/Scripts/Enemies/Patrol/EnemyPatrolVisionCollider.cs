using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrolVisionCollider : MonoBehaviour
{
    private EnemyPatrol patrol;
    private Transform player;
    private PlayerVisibility visibility;
    private Slider slider;
    private bool caught;
    private bool outside;
    private GameFlowController gfc;

    [SerializeField] [Range(0.1f, 3f)] private float catchDelay = 0.25f;
    [SerializeField] [Range(0.3f, 30f)] private float pursueTime = 3f;
    private float catchAmount;

    // Start is called before the first frame update
    void Start()
    {
        slider = transform.parent.Find("EnemyAnimator/Canvas/Slider").gameObject.GetComponent<Slider>();
        player = LevelAccess.GetPlayerPos();
        patrol = GetComponent<EnemyPatrol>();
        visibility = player.GetComponent<PlayerVisibility>();
        catchAmount = 0f;
        caught = false;
        outside = true;
        slider.gameObject.SetActive(false);
        gfc = GameObject.FindGameObjectWithTag("GameFlowController").GetComponent<GameFlowController>();
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && visibility.getPlayerVisible())
        {
            CheckForPlayer();
        }
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && visibility.getPlayerVisible() && !gfc.GetGameOver())
        {
            CheckForPlayer();
        }
    }

    private void Update()
    {
        if (outside)
        {
            if (caught)
            {
                if (catchAmount <= 0f)
                {
                    slider.gameObject.SetActive(false);
                    patrol.SetPlayerDetected(false);
                    catchAmount = 0f;
                    caught = false;
                }
                else
                {
                    //slider.gameObject.SetActive(true);
                    catchAmount -= Time.deltaTime;
                    slider.value = catchAmount / pursueTime;
                }
            }
            else if (catchAmount > 0)
            {
                slider.gameObject.SetActive(false);
                catchAmount = 0f;
            }
        }
    }


    private void CheckForPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        RaycastHit2D[] hits = new RaycastHit2D[3];
        Physics2D.Raycast(transform.position, direction, new ContactFilter2D(), hits);
        Debug.DrawRay(transform.position, direction, Color.red);
        if (hits[0].collider.gameObject.transform.Equals(player.transform))
        {
            outside = false;
            if (!caught)
            {
                if (catchAmount >= catchDelay)
                {
                    patrol.SetPlayerDetected(true);
                    catchAmount = pursueTime;
                    caught = true;
                }
                else
                {
                    slider.gameObject.SetActive(true);
                    catchAmount += Time.deltaTime;
                    slider.value = catchAmount / catchDelay;
                }
            }
            else if (catchAmount <= catchDelay) catchAmount += Time.deltaTime;
        }
        else outside = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            outside = true;
        }
    }
}
