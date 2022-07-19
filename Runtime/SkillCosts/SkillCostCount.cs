﻿using System;
using Match3.Core.GameActions;
using UnityEngine.Scripting.APIUpdating;

namespace Match3.Persistence.SkillCosts
{
    [MovedFrom(false, "BoardCores.Data.GameActions.Actions")]
    [Serializable]
    public class SkillCostCount : SkillCostBase
    {
        public override bool CanExecuteSkill(Skill skill)
        {
            return SkillsCountPersistent.GetSkillCount(skill) > 0;
        }

        public override void ApplySkillCost(Skill skill)
        {
            SkillsCountPersistent.ConsumeSkill(skill);
        }

        public int GetRemainingCount(Skill skill)
        {
            return SkillsCountPersistent.GetSkillCount(skill);
        }
    }
}