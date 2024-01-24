using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellExecutor : MonoBehaviour
{
    [HideInInspector]
    public SpellManager spellManager;
    public LineRenderer firelr;
    public LineRenderer icelr;

    private GameObject mCam;
    Ray ray;

    private void Awake()
    {
        spellManager = GameObject.FindGameObjectWithTag("spellManager").GetComponent<SpellManager>();
        mCam = GameObject.FindGameObjectWithTag("MainCamera");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        firelr = GameObject.FindGameObjectWithTag("FireLine").GetComponent<LineRenderer>();
        icelr = GameObject.FindGameObjectWithTag("IceLine").GetComponent<LineRenderer>();
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
                firelr.SetPosition(0, new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z));
                firelr.SetPosition(1, hit.point);

                break;

            case 1:
                //Ice
                RaycastHit hitr;

                if (Physics.Raycast(ray, out hitr))
                {
                    if (hitr.rigidbody != null)
                    {
                        hitr.rigidbody.AddRelativeForce(ray.direction * currSpell.damage * 100f);
                    }
                }
                icelr.SetPosition(0, new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z));
                icelr.SetPosition(1, hitr.point);
                break;
            default:
                break;
        }
    }


}
