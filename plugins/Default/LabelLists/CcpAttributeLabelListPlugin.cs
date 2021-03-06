using System.Collections.Generic;
using System.Globalization;

namespace Turbo.Plugins.Default
{

    public class CcpAttributeLabelListPlugin : BasePlugin, IInGameTopPainter
    {

        public HorizontalTopLabelList LabelList { get; private set; }

        public CcpAttributeLabelListPlugin()
            : base()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            var expandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, false, false, true);
            var expandedHintWidthMultiplier = 3;

            LabelList = new HorizontalTopLabelList(hud);

            LabelList.LeftFunc = () =>
            {
                var ui = Hud.Render.InGameBottomHudUiElement;
                return ui.Rectangle.Left + ui.Rectangle.Width * 0.267f;
            };
            LabelList.TopFunc = () =>
            {
                var ui = Hud.Render.InGameBottomHudUiElement;
                return ui.Rectangle.Top + ui.Rectangle.Height * 0.318f;
            };
            LabelList.WidthFunc = () =>
            {
                var ui = Hud.Render.InGameBottomHudUiElement;
                return Hud.Window.Size.Height * 0.0621f;
            };
            LabelList.HeightFunc = () =>
            {
                var ui = Hud.Render.InGameBottomHudUiElement;
                return Hud.Window.Size.Height * 0.025f;
            };

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => ValueToString(Hud.Game.Me.Defense.EhpCur, ValueFormat.ShortNumber),
                HintFunc = () => "EHP current",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.70f,
                TextFunc = () => ValueToString(Hud.Game.Me.Defense.EhpMax, ValueFormat.ShortNumber),
                HintFunc = () => "EHP max",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.drCombined * 100).ToString("F1", CultureInfo.InvariantCulture),
                        HintFunc = () => "能量消耗降低",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => Hud.Game.Me.Defense.Armor.ToString("#,0", CultureInfo.InvariantCulture),
                        HintFunc = () => "护甲",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => Hud.Game.Me.Defense.ResAverage.ToString("F0", CultureInfo.InvariantCulture),
                        HintFunc = () => "平均抗性",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.DRElite * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "精英减伤",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.DRMelee * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "近战减伤",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.DRRanged * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "远程减伤",
                    }
                }
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => Hud.Game.Me.Offense.AttackSpeed.ToString("F2", CultureInfo.InvariantCulture) + "/s",
                HintFunc = () => "攻击速度",
//                ExpandedHintFont = expandedHintFont,
//                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
//                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
//                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
//                BackgroundTextureOpacity2 = 0.5f,
//                TextFunc = () => ValueToString(Hud.Game.Me.Offense.SheetDps, ValueFormat.ShortNumber),
//                HintFunc = () => "sheet DPS",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => ValueToString(Hud.Game.Me.Offense.MainHandIsActive ? Hud.Game.Me.Offense.WeaponDamageMainHand : Hud.Game.Me.Offense.WeaponDamageSecondHand, ValueFormat.ShortNumber),
                        HintFunc = () => "武器伤害",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.AttackSpeed.ToString("F2", CultureInfo.InvariantCulture) + "/s",
                        HintFunc = () => "攻击速度",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.CriticalHitChance.ToString("F1", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "暴击几率",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.CritDamage.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "爆击伤害",
                    }
                }
            });

             LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
             {
                 TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 128, 255, 255, true, false, true),
                 BackgroundTexture1 = Hud.Texture.BuffFrameTexture,
                 BackgroundTexture2 = Hud.Texture.Button2TextureGray,
                 BackgroundTextureOpacity2 = 1f,
                 TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Damage.CurrentDps, ValueFormat.LongNumber),
                 HintFunc = () => "当前秒伤",
             });

             LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
             {
                 TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 255, 255, 255, true, false, true),
                 BackgroundTexture1 = Hud.Texture.BuffFrameTexture,
                 BackgroundTexture2 = Hud.Texture.Button2TextureBrown,
                 BackgroundTextureOpacity2 = 1f,
                 TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Damage.RunDps, ValueFormat.LongNumber),
                 HintFunc = () => "平均秒伤",
             });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 255, 255, 128, true, false, true),
                BackgroundTexture1 = Hud.Texture.BuffFrameTexture,
                BackgroundTexture2 = Hud.Texture.Button2TextureGray,
                BackgroundTextureOpacity2 = 1f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Damage.TotalDamage, ValueFormat.LongNumber),
                HintFunc = () => "总伤害",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
//                TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 200, 200, 255, false, false, true),
//                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
//                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
//                BackgroundTextureOpacity2 = 0.75f,
//                TextFunc = () => Hud.Game.Me.Offense.AreaDamageBonus.ToString("F0", CultureInfo.InvariantCulture) + "%",
//                HintFunc = () => "区域伤害奖励 %",
                  TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                  ExpandedHintFont = expandedHintFont,
                  BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                  BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                  BackgroundTextureOpacity2 = 0.75f,
                  TextFunc = () => (Hud.Game.Me.Offense.BonusToElites * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                  HintFunc = () => "精英伤害",
            });
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => (Hud.Game.Me.Stats.CooldownReduction * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "冷却时间效果缩短%",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => (Hud.Game.Me.Stats.ResourceCostReduction * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "能耗降低",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Defense.LifeRegen.ToString("F0", CultureInfo.InvariantCulture) + "/秒",
                        HintFunc = () => "每秒恢复",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Stats.MoveSpeed.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "移动速度",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.AreaDamageBonus.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "范围伤害",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => (Hud.Game.Me.Stats.PickupRange - 5).ToString("F0", CultureInfo.InvariantCulture) + "码",
                        HintFunc = () => "拾取距离",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Stats.GoldFind.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "金币加成",
                    }
                }
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 200, 200, 255, false, false, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => Hud.Game.Me.Offense.AreaDamageBonus.ToString("F0", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "区域伤害奖励 %",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
//                TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 255, 200, 200, false, false, true),
//                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
//                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
//                BackgroundTextureOpacity2 = 0.75f,
//                TextFunc = () => ValueToString(Hud.Game.ExperiencePerHourToday, ValueFormat.ShortNumber) + "/h",
//                HintFunc = () => "今日每小时经验",
                  TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 200, 200, false, false, true),
                  BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                  BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                  BackgroundTextureOpacity2 = 0.75f,
                  TextFunc = () => Hud.Game.Me.Stats.MoveSpeed.ToString("F0", CultureInfo.InvariantCulture) + "%",
                  HintFunc = () => "移动速度",
            });
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;

            LabelList.Paint();
        }

    }

}