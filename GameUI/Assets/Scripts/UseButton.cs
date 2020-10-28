using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseButton : MonoBehaviour
{
    public Button button;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _taskOne;
    [SerializeField] private Transform _taskTwo;
    [SerializeField] private Transform _taskThree;
    public GameObject task1board;
    public GameObject task2board;
    public GameObject task3board;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnCLick);
    }

    void TaskOnCLick()
    {
        IsTaskInRange();
    }
    void IsTaskInRange()
    {
        if (Vector3.Distance(_player.position, _taskOne.position) < 10f)
        {
            task1board.GetComponent<Animator>().Play("floatDown");
        }
        else if (Vector3.Distance(_player.position, _taskTwo.position) < 10f)
        {
            task2board.GetComponent<Animator>().Play("floatDown");
        }
        else if(Vector3.Distance(_player.position, _taskThree.position) < 10f)
        {
            task3board.GetComponent<Animator>().Play("floatDown");
        }
    }
}
