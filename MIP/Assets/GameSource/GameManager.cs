using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] BranchInfo branchInfo;
    public BranchInfo BranchInfo
    {
        get
        {
            return branchInfo;
        }
    }

    public int elapsedWeek;

    public List<Branch> branches = new List<Branch>();

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            elapsedWeek++;

            foreach (var item in branches)
            {
                item.CheckCondition_PerWeek();
            }
        }
    }
}
