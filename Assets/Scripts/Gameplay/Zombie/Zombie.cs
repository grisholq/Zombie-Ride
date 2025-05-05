using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class Zombie : MonoBehaviour, IPoolInstance<Zombie>
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Collider collider;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;

    private Transform persuitTarget;
    private bool persuit = false;
    private bool dead = false;
    private Pool<Zombie> pool;
    private Tween deathAnimation;

    private void Start()
    {
        ToIdleAnimation();
    }

    private void ToIdleAnimation()
    {
        animator.SetBool("Moving", false);
    }    
    
    private void ToWalkAnimation()
    {
        animator.SetBool("Moving", true);
    }

    private void Update()
    {
        if (persuit)
        {
            var moveDirection = persuitTarget.position - transform.position;
            moveDirection.y = 0;
            rigidbody.velocity = moveDirection.normalized * speed;
            var eulers = transform.eulerAngles;
            eulers.y = - Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg + 90;
            transform.eulerAngles = eulers;
        }
    }

    public void Dispose()
    {
        deathAnimation.Kill();
        collider.enabled = true;
        dead = false;
        persuitTarget = null;
        persuit = false;
        pool.Return(this);
    }

    public void SetPool(Pool<Zombie> pool)
    {
        this.pool = pool;
    }

    private void OnTriggerEnter(Collider other)
    {
        var car = other.GetComponentInParent<Car>();
        if (car != null)
        {
            StartPersuit(car.transform);
        }
    }

    private void StartPersuit(Transform target)
    {
        if(dead) return;
        persuitTarget = target;
        persuit = true;
        ToWalkAnimation();
    }

    public void DieIn(float seconds)
    {
        collider.enabled = false;
        var movePos = transform.position + new Vector3(0, 10f, 3);
        deathAnimation =  transform.DOMove(movePos, seconds).SetEase(Ease.InOutQuad);
        dead = true;
        persuit = false;
        ToIdleAnimation();
        Observable.Timer(TimeSpan.FromSeconds(seconds)).Subscribe(_ => Dispose());
    }
}
