using Assets.Scripts.Items;
using Assets.Scripts.Locations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class FindItemQuest : QuestBase
    {
        protected override string _name => "Find {0}.";

        protected override string _description => "Find {0} somwhere in the {1}";

        protected override List<OnQuestCompleteActionBase> _onCompleteActions { get; set; } = new();

        private LocationEnum _itemLocation;

        private ItemTypeEnum _itemType;

        public override string GetDescription()
        {
            return string.Format(_description, _itemType, _description);
        }

        public override string GetName()
        {
            return string.Format(_name, _itemType);
        }

        public FindItemQuest(ItemTypeEnum item, LocationEnum itemLocation, List<OnQuestCompleteActionBase> actions = null)
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