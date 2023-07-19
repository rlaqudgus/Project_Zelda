namespace classDesign
{
    class MaterialInventory : ZeldaInventory
    {
        public MaterialInventory(string explain)
        {
            ZeldaLog(explain);
            SetItem();
        }
        public override void ZeldaSelect()
        {
            //UI
            SetItem();
            ZeldaChoice(itemList, "아이템을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            ZeldaLogic(itemList, ZeldaInput());
            //로직
            //인풋에 따라 다른 인벤토리 아이템 분기가 나타나게

        }

        public override void ZeldaLogic(string input)
        {

        }

        void SetItem()
        {
            itemList.Clear();

            foreach (var item in ZeldaManager.currentLink.itemList)
            {
                if (item.type==ZeldaItem.Type.Material)
                {
                    itemList.Add(item);
                }
            }
        }

    }

    class WeaponInventory : ZeldaInventory
    {
        public WeaponInventory(string explain)
        {
            ZeldaLog(explain);
            SetItem();
        }

        public override void ZeldaSelect()
        {
            //UI
            SetItem();
            ZeldaChoice(itemList, "아이템을 선택하십시오.");
            ZeldaLogic(itemList, ZeldaInput());
            //로직
            //인풋에 따라 다른 인벤토리 아이템 분기가 나타나게

        }

        void SetItem()
        {
            itemList.Clear();

            foreach (var item in ZeldaManager.currentLink.itemList)
            {
                if (item.type == ZeldaItem.Type.Weapon)
                {
                    itemList.Add(item);
                }
            }

            //if (itemList.Count==0)
            //{
            //    ZeldaLog("인벤토리가 비어 있습니다.");
            //}
        }
    }

    class ShieldInventory : ZeldaInventory
    {
        public ShieldInventory(string explain)
        {
            ZeldaLog(explain);
            SetItem();
        }
            

        public override void ZeldaSelect()
        {
            //UI
            SetItem();
            ZeldaChoice(itemList, "아이템을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            ZeldaLogic(itemList, ZeldaInput());
            //로직
            //인풋에 따라 다른 인벤토리 아이템 분기가 나타나게

        }

        void SetItem()
        {
            itemList.Clear();

            foreach (var item in ZeldaManager.currentLink.itemList)
            {
                if (item.type == ZeldaItem.Type.Shield)
                {
                    itemList.Add(item);
                }
            }

            //if (itemList.Count == 0)
            //{
            //    ZeldaLog("인벤토리가 비어 있습니다.");
            //}
        }
    }

    class FoodInventory : ZeldaInventory
    {
        public FoodInventory(string explain)
        {
            ZeldaLog(explain);
            SetItem();
        }
        public override void ZeldaSelect()
        {
            //UI
            SetItem();
            ZeldaChoice(itemList, "아이템을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            ZeldaLogic(itemList, ZeldaInput());
            //로직
            //인풋에 따라 다른 인벤토리 아이템 분기가 나타나게

        }

        void SetItem()
        {
            itemList.Clear();

            foreach (var item in ZeldaManager.currentLink.itemList)
            {
                if (item.type == ZeldaItem.Type.food)
                {
                    itemList.Add(item);
                }
            }

            //if (itemList.Count == 0)
            //{
            //    ZeldaLog("인벤토리가 비어 있습니다.");
            //}
        }
    }

    class ClothesInventory : ZeldaInventory
    {
        public ClothesInventory(string explain)
        {
            ZeldaLog(explain);
            SetItem();
        }
        public override void ZeldaSelect()
        {
            //UI
            SetItem();
            ZeldaChoice(itemList, "아이템을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            ZeldaLogic (itemList, ZeldaInput());
            //로직
            //인풋에 따라 다른 인벤토리 아이템 분기가 나타나게

        }

        void SetItem()
        {
            itemList.Clear();

            foreach (var item in ZeldaManager.currentLink.itemList)
            {               
                if (item.type == ZeldaItem.Type.Clothes)
                {
                    itemList.Add(item);
                }
            }

           
        }
    }
}
