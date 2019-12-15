using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public GameObject Player;
    public GameObject cube;
    public float movementSpeed = 1;
    public bool updateOn = true;
    private bool IsMoved = false;
    private bool clicked = false;
    void Start()
    {
       // StartCoroutine(moveCheck());
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (updateOn == true)
        {
            
            if(distance > 1 && distance < 3)
            {
                transform.LookAt(Player.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                animator.SetBool("ismove", true);
            }
            if(distance >3)
            {
                transform.LookAt(cube.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                animator.SetBool("ismove", true);
            }
            if(distance < 1) { animator.SetBool("ismove", false); }
            
            StartCoroutine(updateOff());

        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "hamsterCage") 
        {

            SceneManager.LoadScene("Win");
        }
        if (other.gameObject.name == "Cube")
        {

            SceneManager.LoadScene("Lose");
        }
    }
    void OnMouseDown()
    {
        if (clicked == false) { animator.SetBool("Roar", true); clicked = true; }
        //  animator.SetBool("Roar", false);
        //  StartCoroutine(sec());
        else { animator.SetBool("Roar", false); clicked = false; }
        //   animator.ResetTrigger("Roar");
    }


    IEnumerator moveCheck()
    {
        var p1 = transform.position;
        yield return new WaitForSeconds(0.5f);
        var p2 = transform.position;

        IsMoved = (p1 != p2);
        // or : IsMoved = (p1 == p2);
    }

    IEnumerator updateOff()
    {
        
        yield return new WaitForSeconds(2.0f);
        updateOn = false;
        yield return new WaitForSeconds(2.0f);
        updateOn = true;
    }

    IEnumerator sec()
    {

        yield return new WaitForSeconds(2.0f);
  
    }
}
