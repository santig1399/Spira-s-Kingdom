using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{

    public float maxHealth;
    public float armor;
    public int damage;
    public float speedAttack;
    public float movementSpeed;
    public float attackRange;
    public int level;


    public virtual void Attack() {
        Debug.Log("base attack");
    }

    public virtual void Move() {
        Debug.Log("Base movement");
    }
}
