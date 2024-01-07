using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputBat : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody ball;
    [SerializeField] Transform Bat;

    [SerializeField] ParticleSystem Impact;

    public Vector3 dir;
    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        Impact.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reload the current scene
            ReloadScene();
        }
    }
    public void ReloadScene()
    {
        // Get the current active scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void calculateDir(Vector3 start, Vector3 end)
    {
        dir = (end - start).normalized;
        distance = Vector3.Distance(start, end);
        animator.SetBool("Play", true);
        Debug.Log(distance);
        Debug.Log(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball" && distance != 0)
        {
            GetComponent<MeshCollider>().enabled = false;
            ball.velocity = Vector3.zero;
            dir += (-transform.up);
            dir.Normalize();
            Impact.Play();
            Impact.gameObject.transform.position = collision.transform.position;
            ball.AddForce(dir * distance / 10, ForceMode.Impulse);
            Debug.DrawLine(collision.transform.position ,collision.transform.position + dir * distance , Color.red);
            BatControllerScript.instance.isBatSwinged = true;
        }
    }
}
