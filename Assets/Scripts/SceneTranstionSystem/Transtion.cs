using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene�J�ڂ̃X�N���v�g
public class Transtion : MonoBehaviour
{
    //�^�C�g���ֈڍs
    public void Trasn_ToTitle()
    {
        SceneManager.LoadScene("S-01_Title_Scene");
    }

    //�Q�[���I���ֈڍs
    public void Trans_ToGameEnd()
    {
        Application.Quit();
    }

    //���j���[�ֈڍs
    public void Trans_ToMenu()
    {
        SceneManager.LoadScene("S-02_Menu_Scene");
    }

    //�I�v�V�����ֈڍs
    public void Trans_ToOption()
    {
        SceneManager.LoadScene("S-03_Option_Scene");
    }

    //�A�C�e���}�ӂֈڍs
    public void Trans_ToCatalog()
    {
        SceneManager.LoadScene("Item_Dictionary");
    }

    //�X�e�[�W�I���ֈڍs
    public void Trans_ToSelect()
    {
        SceneManager.LoadScene("S_04_Stage_Select");
    }

    //�`���[�g���A���ֈڍs
    public void Trans_ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    //�X�e�[�W�P�ֈڍs
    public void Trans_ToStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    //�X�e�[�W�Q�ֈڍs
    public void Trans_ToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    //�X�e�[�W�R�ֈڍs
    public void Trans_ToStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    //�X�e�[�W�S�ֈڍs
    public void Trans_ToStage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    //���Ȃ���
    public void Trans_ToRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
