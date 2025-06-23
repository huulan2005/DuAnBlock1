using UnityEngine;

public class obstacie : MonoBehaviour
{
    public float dichuyentrai = -10;
    
   
    void Update()
    {
        Moveobstacie();
    }
    public void Moveobstacie()
    {
        transform.position += Vector3.left * Gamemanager.instance.GetGammespeed()* Time.deltaTime;
        if(transform.position.x < dichuyentrai)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Gamemanager.instance.GameOver();
        }
    }
}
