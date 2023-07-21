using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] Transform leafPos;
    [SerializeField] bool isRight;


    void Update()
    {
        transform.position = leafPos.position;

        
        if(isRight == true)
        {
            Vector3 std = leafPos.parent.eulerAngles;
            Vector3 res = new Vector3(-std.x, std.y, -std.z);
            transform.eulerAngles = res;
        }
        else
        {
            transform.eulerAngles = leafPos.parent.eulerAngles;
        }
    }

    public void BeBranch()
    {
        int nodeCnt = Random.Range(2, 6);


        GameObject go = Instantiate(GameManager.Instance.BranchInfo.branchPrefab[nodeCnt - 2]);
        go.GetComponent<Branch>().SetBranchInfo(nodeCnt);           //브랜치에 노드 정보입g

        go.transform.localScale = Vector3.one / 3;
        go.transform.position = transform.position;
        go.transform.eulerAngles = -transform.right;

        
    }

}
