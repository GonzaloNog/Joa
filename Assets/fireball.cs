using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private Transform target;
    private bool destroyTimer;
    private float timer;
    public AnimationClip destroy; 
    private Animator anim;
    [SerializeField] private float speed = 1.5f;
    public void StartFireBall(Transform _target)
    {
        anim = GetComponent<Animator>();
        target = _target;
        transform.position = Vector2.MoveTowards(target.transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UpdateAnim();
    }
    private void UpdateAnim()
    {
        anim.SetBool("destroy", true);
        destroyTimer = true;
    }
    private void Update()
    {
        if (destroyTimer)
        {
            timer += Time.deltaTime;
            if (timer >= destroy.length)
            {
                Destroy(gameObject);
            }
        }
    }
}
