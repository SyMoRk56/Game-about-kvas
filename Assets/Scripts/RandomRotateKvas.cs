using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateKvas : MonoBehaviour
{
    public float rot;
    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
        rot = Random.Range(50f, 151f);
    }
    private void Update()
    {
        transform.Rotate(0, 0, rot * Time.deltaTime);
        Invoke("Dead", 5f);
    }
    private void OnMouseDown()
    {
        var a = Instantiate(MainMenu.instance.DeadPartSyst,gameObject.transform.position, Quaternion.identity);
        a.SetActive(true);
        a.GetComponent<ParticleSystem>().Play();
        MainMenu.instance.sound.Play();
        Dead();
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
