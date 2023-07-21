using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public int branchAge;
    int bornedWeek;

    int branchNodeCnt;
    int canBeBranchAge;   //성장만기 : 이만큼 지나야 랜덤하게 브랜치를 만들 수 있음

    bool isCheckBeBranch;
   
    public List<GameObject> joints = new List<GameObject>();
    public List<Leaf> leafs;

    void Start()
    {
        StartCoroutine(GetJoints());

        leafs = new List<Leaf>(GetComponentsInChildren<Leaf>());
        GameManager.Instance.branches.Add(this);

        branchAge = 0;
        bornedWeek = 0;
        branchNodeCnt = 3;
        canBeBranchAge = 3;
    }

    IEnumerator GetJoints()
    {
        Transform stdTransform = transform;

        while (stdTransform != null)
        {
            for (int i = 0; i < stdTransform.childCount; i++)
            {
                if (stdTransform.GetChild(i).CompareTag("Joint") == true)
                {
                    joints.Add(stdTransform.GetChild(i).gameObject);
                    stdTransform = stdTransform.GetChild(i);

                    //자식이 없으면 종료
                    if (stdTransform.childCount == 0)
                    {
                        yield break;
                    }
                }   
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckCondition_BeBranch()
    {
        branchAge++;
        if (bornedWeek + canBeBranchAge <= branchAge)
        {
            //be branch
            for (int i = 0; i < leafs.Count; i++)
            {
                if (Random.Range(0, 1) < GameManager.Instance.BranchInfo.beBranchProbability)
                {
                    leafs[i].BeBranch();
                }
                else
                {
                    Debug.Log("failed");
                }
            }
        }
    }

    public void SetBranchInfo(int _branchNodeCnt)
    {
        branchNodeCnt = _branchNodeCnt;

        //노드 개수에 따라 성장만기를 설정
        if (branchNodeCnt < 4) canBeBranchAge = 3;
        else canBeBranchAge = 4;

        bornedWeek = GameManager.Instance.elapsedWeek;
    }
}
