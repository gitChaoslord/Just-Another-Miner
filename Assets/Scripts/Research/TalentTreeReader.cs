using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
 
public class TalentTreeReader : MonoBehaviour {
 
    private static TalentTreeReader _instance;
 
    public static TalentTreeReader Instance
    {
        get
        {
            return _instance;
        }
        set
        {
        }
    }
 
    // Array with all the skills in our skilltree
    private Talent[] _talentTree;
 
    // Dictionary with the skills in our skilltree
    private Dictionary<int, Talent> _talents;
 
    // Variable for caching the currently being inspected skill
    private Talent _talentInspected;
 
    public int availablePoints = 100;
 
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            SetUpTalentTree();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
 
	// Use this for initialization of the skill tree
	void SetUpTalentTree ()
    {
        _talents = new Dictionary<int, Talent>();
 
        LoadTalentTree();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
 
    public void LoadTalentTree()
    {
        string path = "Assets/TalentTree/Data/talenttree.json";
        string dataAsJson;
        if (File.Exists(path))
        {
            // Read the json from the file into a string
            dataAsJson = File.ReadAllText(path);
 
            // Pass the json to JsonUtility, and tell it to create a SkillTree object from it
            TalentTree loadedData = JsonUtility.FromJson<TalentTree>(dataAsJson);
 
            // Store the SkillTree as an array of Skill
            _talentTree = new Talent[loadedData.talenttree.Length];
            _talentTree = loadedData.talenttree;
 
            // Populate a dictionary with the skill id and the skill data itself
            for (int i = 0; i < _talentTree.Length; ++i)
            {
                _talents.Add(_talentTree[i].Talent_ID, _talentTree[i]);
            }
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }        
    }
 
    public bool IsTalentUnlocked(int id_skill)
    {
        if (_talents.TryGetValue(id_skill, out _talentInspected))
        {
            return _talentInspected.unlocked;
        }
        else
        {
            return false;
        }
    }
 
    public bool CanTalentBeUnlocked(int id_skill)
    {
        bool canUnlock = true;
        if(_talents.TryGetValue(id_skill, out _talentInspected)) // The skill exists
        {
            if(_talentInspected.cost <= availablePoints) // Enough points available
            {
                int[] dependencies = _talentInspected.Talent_Dependencies;
                for (int i = 0; i < dependencies.Length; ++i)
                {
                    if (_talents.TryGetValue(dependencies[i], out _talentInspected))
                    {
                        if (!_talentInspected.unlocked)
                        {
                            canUnlock = false;
                            break;
                        }
                    }
                    else // If one of the dependencies doesn't exist, the skill can't be unlocked.
                    {
                        return false;
                    }
                }
            }
            else // If the player doesn't have enough skill points, can't unlock the new skill
            {
                return false;
            }
            
        }
        else // If the skill id doesn't exist, the skill can't be unlocked
        {
            return false;
        }
        return canUnlock;
    }
 
    public bool UnlockTalent(int id_Skill)
    {
        if(_talents.TryGetValue(id_Skill, out _talentInspected))
        {
            if (_talentInspected.cost <= availablePoints)
            {
                availablePoints -= _talentInspected.cost;
                _talentInspected.unlocked = true;
 
                // We replace the entry on the dictionary with the new one (already unlocked)
                _talents.Remove(id_Skill);
                _talents.Add(id_Skill, _talentInspected);
 
                return true;
            }
            else
            {
                return false;   // The skill can't be unlocked. Not enough points
            }
        }
        else
        {
            return false;   // The skill doesn't exist
        }
    }
}