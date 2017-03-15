using UnityEngine;
using System.Collections;

public class ControlHero : MonoBehaviour
{
    public float speed = 6.0F;
    CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public float maxX, maxY, minX, minY;
    public Animator animator;
    public GameObject muzzeLight;
    public GameObject hero;
    private bool flipped = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") ,0 );
            moveDirection *= speed;
            if (checkBound(moveDirection * Time.deltaTime))
            {
                controller.Move(moveDirection * Time.deltaTime);
                if (moveDirection.x > 0 && hero.transform.localScale.x == -1)
                {
                    hero.transform.localScale = new Vector3(1, 1, 1);
                }
                if (moveDirection.x < 0 && hero.transform.localScale.x == 1)
                {
                    hero.transform.localScale = new Vector3(-1, 1, 1);
                }
                
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetBool("isRun", true);
            }
            if (Input.GetKeyDown(KeyCode.F)){
                animator.SetBool("isFire", true);
                muzzeLight.GetComponent<SpriteRenderer>().enabled = true;
               
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
                Input.GetKeyUp(KeyCode.F))
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isFire", false);
                muzzeLight.GetComponent<SpriteRenderer>().enabled = false;
            }
            
	}
    bool checkBound(Vector3 move)
    {
        if (controller.transform.position.x + move.x < minX)
            return false;
        if (controller.transform.position.x + move.x > maxX)
            return false;
        if (controller.transform.position.y + move.y < minY)
            return false;
        if (controller.transform.position.y + move.y > maxY)
            return false;
        return true;
    }

    public void PrintFloat(float theValue)
    {
        Debug.Log("PrintFloat is called with a value of " + theValue);
    }
}
