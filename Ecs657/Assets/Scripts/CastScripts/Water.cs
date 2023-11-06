using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Spell
{
    [SerializeField] Transform waterProj;
    [SerializeField] private float projSpeed;
    [SerializeField] private float cooldown;

    [SerializeField] private int damage;
    [SerializeField] private int duration;
    [SerializeField] private int interval;

    // Start is called before the first frame update
    void Start()
    {
        base.SetPlayer(GameObject.FindGameObjectWithTag("MainCamera"));
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        base.setStats(player.GetComponent<PlayerStats>());
    }

    public Water(Sprite i, Spell[] c) : base(i, "Water", "Shoots ball of water. Damages and slows enemy.", c) 
    {
    }

    public override void Cast()
    {
        float dmgMul = playerStats.dmgMul;
        int dmg = Mathf.RoundToInt(damage * dmgMul);

        GameObject currentprojectile = Instantiate(waterProj, player.transform.position + player.transform.forward, Quaternion.identity).gameObject;
        currentprojectile.GetComponent<Rigidbody>().AddForce(player.transform.forward * projSpeed, ForceMode.Impulse);
        currentprojectile.GetComponent<Waterball>().setData(dmg, duration, interval);
    }
}
