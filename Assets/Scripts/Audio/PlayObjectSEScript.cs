using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObjectSEScript : MonoBehaviour
{
    public void PlayObjectSE(GameObject pasteobj)
    {
        //  �o���P�[�h�A�t�F���X
        if (pasteobj.name == "Barricade")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Barricade);
            return;
        }

        //  ���e�����
        if(pasteobj.name == "BOM2")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Bom);
            return;
        }

        //  �{�^���A�X�C�b�`
        if (pasteobj.name == "Button" || pasteobj.name == "Button_Blue")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Switch);
            return;
        }

        //  �A���~��
        if (pasteobj.name == "Can")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Can);
            return;
        }

        //  ���A�`�F�[��
        if (pasteobj.name == "Chain")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Chain);
            return;
        }

        //  �R�[���o�[  
        if (pasteobj.name == "CornBar")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Cornbar);
            return;
        }

        //  �h������(�ʏ�)
        if (pasteobj.name == "drum")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Drum);
            return;
        }

        //  �h������(�댯�\��)
        if (pasteobj.name == "drum_fire")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Drumdanger);
            return;
        }

        //  �S�~��
        if (pasteobj.name == "Dustbox")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Trashbox);
            return;
        }

        //  ��@�A�����@
        if (pasteobj.name == "Fan")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Fan);
            return;
        }

        //  ���ΐ�
        if (pasteobj.name == "Hydrant")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Firehydrant);
            return;
        }

        //  �e���g�E���V
        if (pasteobj.name == "Ladybug")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Ladybug);
            return;
        }

        //  �u�����A���C�g
        if (pasteobj.name == "lamp")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Lamp);
            return;
        }

        //  �I�A�^�[�Q�b�g
        if (pasteobj.name == "mato")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Target);
            return;
        }

        //  ���A�~���[
        if (pasteobj.name == "Mirror")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.mirror);
            return;
        }

        //  ����
        if (pasteobj.name == "Money")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Money);
            return;
        }

        //  �B
        if (pasteobj.name == "Nail")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Nail);
            return;
        }

        // �t���ρA�ϗt�A��
        if (pasteobj.name == "Leaf" || pasteobj.name == "Plant")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Foliageplant);
            return;
        }

        //  �|�P�b�g(�X�}�[�g�{�[��)
        if (pasteobj.name == "Pocket 5"||pasteobj.name=="Pocket 10" || pasteobj.name == "Pocket15")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Poket);
            return;
        }

        //  �|�X�^�[�A�t���C���[
        if (pasteobj.name == "Poster"||pasteobj.name=="poster_Camera"||pasteobj.name=="Poster_Copy"
            || pasteobj.name == "Poster_Jump" || pasteobj.name == "Poster_Move" || pasteobj.name == "poster_Paste" || pasteobj.name == "poster_ShotPaste")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Flyer);
            return;
        }

        //  �|�e�`�A�|�e�g�`�b�v�X
        if (pasteobj.name == "poteto2")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.PotatoChips);
            return;
        }

        //  �O�p�R�[���A�₵�날����
        if (pasteobj.name == "Pylon")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Pylon);
            return;
        }

        //  ��΁A����
        if (pasteobj.name == "rock1" || pasteobj.name == "rock2")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Rock);
            return;
        }

        //  �ԉ΁A���P�b�g
        if (pasteobj.name == "Rocket")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Rocketfireworks);
            return;
        }

        //  �Ђ�
        if (pasteobj.name == "Sheep")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Sheep);
            return;
        }

        //  �X�}�[�g�{�[���A��
        if (pasteobj.name == "SmaertBall 1" || pasteobj.name == "SmartBall" || pasteobj.name == "SmartBall(Clone)")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Smartball);
            return;
        }

        //  �T�b�J�[�{�[��
        if (pasteobj.name == "soccerball" || pasteobj.name == "soccerball(Clone)")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Soccerball);
            return;
        }

        //  �e�[�u���A��
        if (pasteobj.name == "table")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Table);
            return;
        }

        //  �g���t�B�[�A�D���g���t�B�[
        if (pasteobj.name == "Trophy 1" || pasteobj.name == "Trophy")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Trophy);
            return;
        }

        //  �����̔��@
        if (pasteobj.name == "VendingMacine")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Vendingmachine);
            return;
        }
    }
}
