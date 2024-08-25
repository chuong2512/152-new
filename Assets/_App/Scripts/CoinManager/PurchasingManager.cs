using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasingManager : MonoBehaviour
{
   public void OnPressDown(int i)
   {
      switch (i)
      {
         case 1:
            MenuScript.Instance.AddCoin(30000);
             IAPManager.Instance.BuyProductID(IAPKey.PACK1);
            break;
         case 2:
            MenuScript.Instance.AddCoin(90000);
            IAPManager.Instance.BuyProductID(IAPKey.PACK2);
            break;
         case 3:
            MenuScript.Instance.AddCoin(150000);
            IAPManager.Instance.BuyProductID(IAPKey.PACK3);
            break;
         case 4:
            MenuScript.Instance.AddCoin(300000);
            IAPManager.Instance.BuyProductID(IAPKey.PACK4);
            break;
      }
   }

   public void Sub(int i)
   {
      GameDataManager.Instance.playerData.SubDiamond(i);
   }
}
