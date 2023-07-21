using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new BRANCH DATA", menuName = "BranchData")]
public class BranchInfo : ScriptableObject
{
    public List<GameObject> branchPrefab;
    public float beBranchProbability;
}