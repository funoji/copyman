using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObjectSEScript : MonoBehaviour
{
    public void PlayObjectSE(GameObject pasteobj)
    {
        //  バリケード、フェンス
        if (pasteobj.name == "Barricade")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Barricade);
            return;
        }

        //  爆弾ちゃん
        if(pasteobj.name == "BOM2")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Bom);
            return;
        }

        //  ボタン、スイッチ
        if (pasteobj.name == "Button" || pasteobj.name == "Button_Blue")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Switch);
            return;
        }

        //  アルミ缶
        if (pasteobj.name == "Can")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Can);
            return;
        }

        //  鎖、チェーン
        if (pasteobj.name == "Chain")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Chain);
            return;
        }

        //  コーンバー  
        if (pasteobj.name == "CornBar")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Cornbar);
            return;
        }

        //  ドラム缶(通常)
        if (pasteobj.name == "drum")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Drum);
            return;
        }

        //  ドラム缶(危険表示)
        if (pasteobj.name == "drum_fire")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Drumdanger);
            return;
        }

        //  ゴミ箱
        if (pasteobj.name == "Dustbox")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Trashbox);
            return;
        }

        //  扇風機、送風機
        if (pasteobj.name == "Fan")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Fan);
            return;
        }

        //  消火栓
        if (pasteobj.name == "Hydrant")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Firehydrant);
            return;
        }

        //  テントウムシ
        if (pasteobj.name == "Ladybug")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Ladybug);
            return;
        }

        //  蛍光灯、ライト
        if (pasteobj.name == "lamp")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Lamp);
            return;
        }

        //  的、ターゲット
        if (pasteobj.name == "mato")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Target);
            return;
        }

        //  鏡、ミラー
        if (pasteobj.name == "Mirror")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.mirror);
            return;
        }

        //  お金
        if (pasteobj.name == "Money")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Money);
            return;
        }

        //  釘
        if (pasteobj.name == "Nail")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Nail);
            return;
        }

        // 葉っぱ、観葉植物
        if (pasteobj.name == "Leaf" || pasteobj.name == "Plant")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Foliageplant);
            return;
        }

        //  ポケット(スマートボール)
        if (pasteobj.name == "Pocket 5"||pasteobj.name=="Pocket 10" || pasteobj.name == "Pocket15")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Poket);
            return;
        }

        //  ポスター、フライヤー
        if (pasteobj.name == "Poster"||pasteobj.name=="poster_Camera"||pasteobj.name=="Poster_Copy"
            || pasteobj.name == "Poster_Jump" || pasteobj.name == "Poster_Move" || pasteobj.name == "poster_Paste" || pasteobj.name == "poster_ShotPaste")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Flyer);
            return;
        }

        //  ポテチ、ポテトチップス
        if (pasteobj.name == "poteto2")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.PotatoChips);
            return;
        }

        //  三角コーン、やしろあずき
        if (pasteobj.name == "Pylon")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Pylon);
            return;
        }

        //  岩石、いわ
        if (pasteobj.name == "rock1" || pasteobj.name == "rock2")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Rock);
            return;
        }

        //  花火、ロケット
        if (pasteobj.name == "Rocket")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Rocketfireworks);
            return;
        }

        //  ひつじ
        if (pasteobj.name == "Sheep")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Sheep);
            return;
        }

        //  スマートボール、玉
        if (pasteobj.name == "SmaertBall 1" || pasteobj.name == "SmartBall" || pasteobj.name == "SmartBall(Clone)")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Smartball);
            return;
        }

        //  サッカーボール
        if (pasteobj.name == "soccerball" || pasteobj.name == "soccerball(Clone)")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Soccerball);
            return;
        }

        //  テーブル、机
        if (pasteobj.name == "table")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Table);
            return;
        }

        //  トロフィー、優勝トロフィー
        if (pasteobj.name == "Trophy 1" || pasteobj.name == "Trophy")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Trophy);
            return;
        }

        //  自動販売機
        if (pasteobj.name == "VendingMacine")
        {
            ObjectSEManager.Instance.PlaySE(ObjectSESoundData.Object.Vendingmachine);
            return;
        }
    }
}
