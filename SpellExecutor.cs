using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellExecutor : MonoBehaviour
{
    [HideInInspector]
    public SpellManager spellManager;
    public LineRenderer lr;

    private GameObject mCam;
    Ray ray;

    private void Awake()
    {
        spellManager = GameObject.FindGameObjectWithTag("spellManager").GetComponent<SpellManager>();
        mCam = GameObject.FindGameObjectWithTag("MainCamera");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        lr = GameObject.FindGameObjectWithTag("FireLine").GetComponent<LineRenderer>();
        //lr = lr.GetComponent<LineRenderer>();

    }
    private void FixedUpdate()
    {
        for (int i = 0; i < spellManager.spellList.Count; i++)
        {
            if (Input.GetKeyDown(spellManager.GetSpellById(i).keybind))
            {
                CastSpell(spellManager.GetSpellById(i));
            }
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    void CastSpell(Spells currSpell)
    {
        switch (currSpell.id)
        {
            case 0:
                //Fireball
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddRelativeForce(ray.direction * currSpell.damage * 100f);
                    }
                }
                lr.SetPosition(0, new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z));
                lr.SetPosition(1, hit.point);

                break;
            default:
                break;
        }
    }


}
