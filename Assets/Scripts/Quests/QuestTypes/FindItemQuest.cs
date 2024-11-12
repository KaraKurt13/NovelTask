using Assets.Scripts.Items;
using Assets.Scripts.Locations;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class FindItemQuest : QuestBase
    {
        protected override string _name => Engine.GetService<ITextManager>().GetRecordValue("Type.FindItem.Name", "Quests");

        protected override string _description => Engine.GetService<ITextManager>().GetRecordValue("Type.FindItem.Description", "Quests");

        protected override List<ExecutableActionBase> _onCompleteActions { get; set; } = new();

        private LocationEnum _itemLocation;

        private ItemTypeEnum _itemType;

        public override string GetDescription()
        {
            return string.Format(_description, _itemType, _itemLocation);
        }

        public override string GetName()
        {
            return string.Format(_name, _itemType);
        }

        public FindItemQuest(ItemTypeEnum item, LocationEnum itemLocation, List<ExecutableActionBase> actions = null)
        {
            _itemType = item;
            _itemLocation = itemLocation;
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    _onCompleteActions.Add(action);
                }
            }
        }
    }
}