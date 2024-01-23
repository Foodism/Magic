using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<Spells> spellList = new List<Spells>
        {
            new Spells() { title = "Fireball", id = 0, description = "Good for damaging", damage = 15f, keybind = KeyCode.E },
            new Spells() { title = "IceSpike", id = 1, description = "Good for Ice", damage = 15f,  keybind = KeyCode.R },

            //Leave as last element in case of err
            new Spells() { title = "Error", id = -2, description = "Error with fetch", damage = 0f, keybind = KeyCode.F12 }
        };
    public Spells GetSpellIdByName(string spellName)
    {
        var result = spellList.FirstOrDefault(s => s.title == spellName);
        if (result == null) result = spellList.Last();
        return result;
    }
    public Spells GetSpellById(int spellName)
    {
        var result = spellList.FirstOrDefault(s => s.id == spellName);
        if (result == null) result = spellList.Last();
        return result;
    }

}
public class Spells
{
    public string title { get; set; }
    public int id { get; set; }
    public string description { get; set; }
    public float damage { get; set; }
    public KeyCode keybind { get; set; }
}
